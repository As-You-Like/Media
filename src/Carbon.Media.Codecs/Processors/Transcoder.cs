using System;
using System.IO;
using System.Threading;

using Carbon.Media.Codecs;
using Carbon.Media.Formats;
using FFmpeg.AutoGen;

namespace Carbon.Media.Processing
{
    public class Transcoder
    {
        private readonly EncodingProfile profile;

        public Transcoder(EncodingProfile profile)
        {
            this.profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        public unsafe void Process(Uri url, Stream outputStream, CancellationToken ct = default)
        {
            using (var demuxer = Demuxer.Open(url))
            {
                Process(demuxer, outputStream, ct);
            }
        }

        public unsafe void Process(Stream inputStream, Stream outputStream, CancellationToken ct = default)
        {
            using (var demuxer = Demuxer.Open(inputStream))
            {
                Process(demuxer, outputStream, ct);
            }
        }

        public unsafe void Process(Demuxer demuxer, Stream outputStream, CancellationToken ct = default)
        {
            using (var packet = Packet.Allocate())
            using (var filteredPacket = Packet.Allocate())
            using (var muxer = new Muxer(profile.Format))
            {
                muxer.Open(outputStream); // + 50MB
                 
                var audioStream = (AudioStream)demuxer.GetStream(MediaType.Audio);
                var audioFormat = new AudioFormatInfo(audioStream.SampleFormat, audioStream.ChannelLayout, audioStream.SampleRate);
                var audioDecoder = (AudioDecoder)audioStream.Codec;
                var audioEncoder = GetAudioEncoder(audioStream); // 1.24GB per 1000

              
                /*
                Console.WriteLine(audioStream.SampleFormat 
                    + " " + audioStream.ChannelCount
                    + "|" + audioStream.SampleRate 
                    + "|" + audioStream.Duration.Value.TimeSpan.ToString()
                );
                */

                audioDecoder.Open(); // open the audio decoder

                muxer.Initialize(audioEncoder);
                
                audioEncoder.Stream.Index = 0;
                
                var audioGraph = FilterGraph.Create(
                    decoder: audioDecoder,
                    encoder: audioEncoder,
                    filterSpecification: audioEncoder.GetFilterGraph()
                );
                
                
                // Console.WriteLine(audioGraph.Dump());
                                
                // var options = new AvDictionary();
                // 
                // if (profile.Format == FormatId.M4a || profile.Format == FormatId.Mp4)
                // {
                //     // https://stackoverflow.com/questions/25688313/how-to-use-ffmpeg-faststart-flag-programmatically
                //     options.SetFlag("movflags", "faststart", 0);
                // }
                // 
                muxer.WriteHeader(); // options
                 
                var decodedAudioFrame = new Frame();
                var filteredAudioFrame = new Frame();
                
                int frameNumber = 0;
                
                while (demuxer.TryReadPacket(packet))
                {
                    ct.ThrowIfCancellationRequested();
                
                    if (packet.StreamIndex == audioStream.Index)
                    {
                        // rescale the packet timebase (todo: verify)
                       
                        ffmpeg.av_packet_rescale_ts(
                            packet.Pointer,
                            audioDecoder.Context.Pointer->time_base,
                            audioEncoder.Context.Pointer->time_base
                        );
                       
                        if (audioDecoder.TrySendPacket(packet) == OperationStatus.Ok)
                        {
                            while (audioDecoder.TryGetFrame(decodedAudioFrame) == OperationStatus.Ok)
                            {
                                audioGraph.PushFrame(decodedAudioFrame);
                
                                while (audioGraph.TryPullFrame(filteredAudioFrame) == OperationStatus.Ok)
                                {
                                    if (audioEncoder.TryEncode(filteredAudioFrame) == OperationStatus.Ok)
                                    {
                                        if (audioEncoder.TryReadPacket(filteredPacket) == OperationStatus.Ok)
                                        {
                                            muxer.WritePacket(filteredPacket);
                
                                            filteredPacket.Unref();
                                        }
                                    }
                
                                    filteredAudioFrame.Unref();
                
                                    frameNumber++;
                                }
                             
                
                                decodedAudioFrame.Unref();
                            }
                        }
                       
                    }
                

                    packet.Unref();
                }
                
                audioDecoder.Complete();
                audioEncoder.Complete();
                
                
                // Drain the remaining encoded packets
                while (audioEncoder.TryReadPacket(packet) == OperationStatus.Ok)
                {
                    // Console.WriteLine("- writing final audio packet");
                
                    muxer.WritePacket(packet);
                
                    packet.Unref();
                }
                
                muxer.WriteTrailer();
                
                filteredAudioFrame.Dispose();
                decodedAudioFrame.Dispose();
                 
                audioGraph.Dispose();
                
                Console.WriteLine("done");
            }
        }
      
        private AudioEncoder GetAudioEncoder(AudioStream stream)
        {
            // TODO: Match the input paramaters unless overwritten
            
            switch (profile.Format)
            {
                case FormatId.Opus:
                case FormatId.Ogg:
                    return new OpusEncoder(new OpusEncodingParameters {
                        BitRate = profile.Audio?.BitRate ?? BitRate.FromKbps(128),
                        SampleRate = stream.SampleRate,
                        ChannelLayout = stream.ChannelLayout
                    });
                case FormatId.M4a:
                case FormatId.Mp4:
                case FormatId.Aac:
                    return new AacEncoder(new AacEncodingParameters {
                        BitRate = profile.Audio?.BitRate ?? BitRate.FromKbps(128),
                        SampleRate = stream.SampleRate,
                        ChannelLayout = stream.ChannelLayout
                    });
                case FormatId.Mp3:
                    return new Mp3Encoder(new Mp3EncodingParameters(
                        bitRate       : profile.Audio?.BitRate ?? BitRate.FromKbps(128),
                        channelLayout : stream.ChannelLayout
                    ));
                default:
                    throw new Exception("Invalid format:" + profile.Format);
            }
        }
    }
}

// references
// https://gist.github.com/Ruslan-B/43d3a4219f39b99f0c9685290dcd23cc
// https://ffmpeg.org/doxygen/trunk/doc_2examples_2muxing_8c-example.html