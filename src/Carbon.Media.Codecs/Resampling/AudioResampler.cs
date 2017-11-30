using System;
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs.Resampling
{
    public unsafe class AudioResampler
    {
        private SwrContext* pointer;

        private readonly AudioFormatInfo inFormat;
        private readonly AudioFormatInfo outFormat;

        public AudioResampler(AudioFormatInfo inFormat, AudioFormatInfo outFormat)
        {
            this.pointer = ffmpeg.swr_alloc();
            this.inFormat = inFormat;
            this.outFormat = outFormat;

            // In
            ffmpeg.av_opt_set_int(pointer,        "in_channel_layout", (long)inFormat.ChannelLayout, 0);
            ffmpeg.av_opt_set_int(pointer,        "in_sample_rate", inFormat.SampleRate, 0);
            ffmpeg.av_opt_set_sample_fmt(pointer, "in_sample_fmt", inFormat.SampleFormat.ToAVFormat(), 0);

            // Out
            ffmpeg.av_opt_set_int(pointer,        "out_channel_layout", (long)outFormat.ChannelLayout, 0);
            ffmpeg.av_opt_set_int(pointer,        "out_sample_rate", outFormat.SampleRate, 0);
            ffmpeg.av_opt_set_sample_fmt(pointer, "out_sample_fmt", outFormat.SampleFormat.ToAVFormat(), 0);

            // filter_size
            // phase_shift
            // cutoff

            ffmpeg.swr_init(pointer).EnsureSuccess();
        }

        public void Convert(AudioFrame inFrame, AudioFrame outFrame)
        {
            int targetSamples = GetOutputSampleCount(inFrame.SampleCount);

            outFrame.Resize(targetSamples);
            
            var sampleCount = ffmpeg.swr_convert(
                s         : pointer,
                @out      : outFrame.Pointer->extended_data,
                out_count : targetSamples,
                @in       : inFrame.Pointer->extended_data, // pointer to the planes / data
                in_count  : inFrame.SampleCount
            );

            if (sampleCount < 0) throw new FFmpegException(sampleCount);

            outFrame.SampleCount      = sampleCount;
            outFrame.DecodingTime     = inFrame.DecodingTime;
            outFrame.PresentationTime = inFrame.PresentationTime;
            outFrame.ChannelCount     = outFormat.ChannelCount;
            outFrame.SampleRate       = outFormat.SampleRate;
            outFrame.ChannelLayout    = outFormat.ChannelLayout;
            outFrame.SampleFormat     = outFormat.SampleFormat;

            // TODO: Set the presentation time & duration

            Console.WriteLine($"resampled {inFrame.SampleFormat} {inFrame.SampleCount} -> {outFormat.SampleFormat} {outFrame.SampleCount} | {sampleCount} | {outFrame.ChannelCount} | {outFrame.Memory.Length}");
        }

        /*
        public void Convert(byte** input, byte** output, int frameSize)
        {
            ffmpeg.swr_convert(pointer, output, frameSize, input, frameSize);
        }
        */

        private int GetOutputSampleCount(int inSampleCount)
        {
            long delaySampleCount = ffmpeg.swr_get_delay(pointer, inFormat.SampleRate);

            return (int)ffmpeg.av_rescale_rnd(
                delaySampleCount + inSampleCount, 
                outFormat.SampleRate,
                inFormat.SampleRate,
                AVRounding.AV_ROUND_UP
            );
        }

        public void Dispose()
        {
          
        }
    }
}
