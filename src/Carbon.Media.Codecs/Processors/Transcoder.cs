using System;
using System.IO;
using System.Threading;

using Carbon.Media.Codecs;
using Carbon.Media.Formats;
using Carbon.Media.IO;

namespace Carbon.Media.Processing
{
    public class Transcoder
    {
        private readonly EncodingProfile profile;

        public Transcoder(EncodingProfile profile)
        {
            this.profile = profile ?? throw new ArgumentNullException(nameof(profile));
        }

        public unsafe void Process(Stream inputStream, Stream outputStream, CancellationToken ct = default)
        {
            var filteredFrame = new AudioFrame();
            
            using (var packet = Packet.Allocate())
            using (var input = new IOContext(inputStream))
            using (var output = new IOContext(outputStream, true))
            using (var demuxer = Demuxer.Open(input))
            using (var muxer = new Muxer(profile.Format))
            {
                muxer.Open(output);

                var audioStream  = (AudioStream)demuxer.GetStream(MediaType.Audio);
                var audioFormat  = new AudioFormatInfo(audioStream.SampleFormat, audioStream.ChannelLayout, audioStream.SampleRate);
                var audioDecoder = (AudioDecoder)audioStream.Codec;
                var audioEncoder = GetAudioEncoder(audioStream);

                // var videoStream  = (VideoStream)demuxer.GetStream(MediaType.Video);
                // var videoDecoder = (VideoDecoder)videoStream.Codec;
                // var videoFrame   = new VideoFrame(videoStream.PixelFormat, videoStream.Width, videoStream.Height);
                // var videoEncoder = new H264Encoder(new H264EncodingParameters());

                /*
                Console.WriteLine(audioStream.SampleFormat 
                    + " " + audioStream.ChannelCount
                    + "|" + audioStream.SampleRate 
                    + "|" + audioStream.Duration.Value.TimeSpan.ToString()
                );
                */

                audioEncoder.Open();

                muxer.Initialize(audioEncoder);

                audioEncoder.Stream.Index = 0;

                var audioGraph = FilterGraph.Create(
                    decoder: audioDecoder,
                    encoder: audioEncoder,
                    filterSpecification: audioEncoder.GetFilterGraph()
                );

                // Console.WriteLine(audioGraph.Dump());

                audioDecoder.Open(); // open the audio decoder
                // videoDecoder.Open(); // open the video decoder

                var options = new AvDictionary();


                if (profile.Format == FormatId.M4a || profile.Format == FormatId.Mp4)
                {
                    // https://stackoverflow.com/questions/25688313/how-to-use-ffmpeg-faststart-flag-programmatically
                    options.SetFlag("movflags", "faststart", 0);
                }

                muxer.WriteHeader(); // options

                int frameNumber = 0;

                while (demuxer.TryReadPacket(packet))
                {
                    ct.ThrowIfCancellationRequested();

                    if (packet.StreamIndex == audioStream.Index)
                    {
                        // rescale the packet timebase
                        /*
                        ffmpeg.av_packet_rescale_ts(
                            packet.Pointer,
                            audioDecoder.Context.Pointer->time_base,
                            audioEncoder.Context.Pointer->time_base
                        );
                        */

                        if (audioDecoder.TrySendPacket(packet) == OperationStatus.Ok)
                        {
                            packet.Unref();

                            var af = new AudioFrame();

                            if (audioDecoder.TryGetFrame(af) == OperationStatus.Ok)
                            {
                                audioGraph.PushFrame(af);

                                while (audioGraph.TryPullFrame(filteredFrame) == OperationStatus.Ok)
                                {
                                    if (audioEncoder.TryEncode(filteredFrame) == OperationStatus.Ok)
                                    {
                                        // TODO: Do we need to set the stream index & update the timebase?

                                        // av_rescale_q(samples_count, (AVRational){1, c->sample_rate}, c->time_base)

                                        if (audioEncoder.TryGetPacket(packet) == OperationStatus.Ok)
                                        {
                                            muxer.WritePacket(packet);

                                            packet.Unref();
                                        }
                                    }

                                    filteredFrame.Unref();

                                    frameNumber++;
                                }
                            }

                            af.Dispose();
                        }
                    }

                    /*
                    else if (packet.StreamIndex == videoStream.Index)
                    {
                        if (videoDecoder.TrySendPacket(packet) == OperationStatus.Ok)
                        {
                            
                        }
                        
                    }
                    */

                    packet.Unref();
                }

                audioDecoder.Complete();
                audioEncoder.Complete();

                while (audioEncoder.TryGetPacket(packet) == OperationStatus.Ok)
                {
                    Console.WriteLine("- writing final audio packet");

                    muxer.WritePacket(packet);

                    packet.Unref();
                }

                muxer.WriteTrailer();

                audioGraph.Dispose();

                filteredFrame.Dispose();

                // audioDecoder.Dispose();
                // audioEncoder.Dispose();

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