using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe sealed class AudioFrame : Frame
    {
        public AudioFrame() { }

        private readonly AudioFormatInfo format;
        private void* channelPlanePointers;

        public AudioFrame(AudioFormatInfo format, int sampleCount)
        {
            this.format = format ?? throw new ArgumentNullException(nameof(format));

            Memory = Buffer.Allocate(AudioFormatHelper.GetBufferSize(format, sampleCount));

            channelPlanePointers = ffmpeg.av_calloc((ulong)IntPtr.Size, 8);
            
            ffmpeg.av_samples_fill_arrays(
                audio_data  : (byte**)channelPlanePointers,
                linesize    : null,
                buf         : (byte*)Memory.Pointer,
                nb_channels : format.ChannelCount,
                sample_fmt  : format.SampleFormat.ToAVFormat(),
                nb_samples  : sampleCount,
                align       : 0
            );
            
            // Set the frame properties
            SampleFormat  = format.SampleFormat;
            SampleRate    = format.SampleRate;
            SampleCount   = sampleCount;
            ChannelCount  = format.ChannelCount;
            ChannelLayout = format.ChannelLayout;
            
            pointer->extended_data = (byte**)channelPlanePointers;
        }
        
        public int ChannelCount
        {
            get => pointer->channels;
            set => pointer->channels = value;
        }

        public ChannelLayout ChannelLayout
        {
            get => (ChannelLayout)pointer->channel_layout;
            set => pointer->channel_layout = (ulong) value;
        }

        public int SampleRate
        {
            get => pointer->sample_rate;
            set => pointer->sample_rate = value;
        }

        public SampleFormat SampleFormat
        {
            get => ((AVSampleFormat)pointer->format).ToFormat();
            set => pointer->format = (int)value.ToAVFormat();
        }

        /// <summary>
        /// # of audio samples (per channel)
        /// </summary>
        public int SampleCount
        {
            get => pointer->nb_samples;
            set => pointer->nb_samples = value;
        }
        
        // public int LineSize => pointer->linesize; // size in bytes of each plane
    
        // AppendSamples?

        
        internal void Resize(int sampleCount)
        {
            var newBufferSize = AudioFormatHelper.GetBufferSize(format, sampleCount);

            if (newBufferSize != Memory.Length)
            {
                Memory.Resize(newBufferSize);

                pointer->nb_samples = sampleCount;
                pointer->format = (int)format.SampleFormat.ToAVFormat();

                ffmpeg.av_samples_fill_arrays(
                    audio_data  : pointer->extended_data,
                    linesize    : null,
                    buf         : (byte*)Memory.Pointer,
                    nb_channels : format.ChannelCount,
                    sample_fmt  : format.SampleFormat.ToAVFormat(),
                    nb_samples  : sampleCount,
                    align       : 0
                );

                Console.WriteLine("resized audio frame:" + newBufferSize);
            }
        }
        /*
        public void Update(int sampleCount, byte** dataPlanes)
        {
            Resize(sampleCount);

            ffmpeg.av_samples_copy(
                dst         : pointer->extended_data,
                src         : dataPlanes,
                dst_offset  : 0,
                src_offset  : 0, 
                nb_samples  : sampleCount,
                nb_channels : ChannelCount,
                sample_fmt  : format.SampleFormat.ToAVFormat()
            );
        }
        */

        internal override void OnDisposing()
        {
            // Console.WriteLine("Disposing AudioFrame");

            ffmpeg.av_free(channelPlanePointers);

            channelPlanePointers = null;
        }
    }
}