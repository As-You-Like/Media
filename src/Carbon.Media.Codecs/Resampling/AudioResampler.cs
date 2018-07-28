using System;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs.Resampling
{
    public unsafe sealed class AudioResampler : IDisposable
    {
        private SwrContext* pointer;

        private readonly AudioFormatInfo sourceFormat;
        private readonly AudioFormatInfo targetFormat;

        public AudioResampler(AudioFormatInfo sourceFormat, AudioFormatInfo targetFormat)
        {
            this.pointer = ffmpeg.swr_alloc();
            this.sourceFormat = sourceFormat;
            this.targetFormat = targetFormat;

            // In
            ffmpeg.av_opt_set_int(pointer,        "in_channel_layout",  (long)sourceFormat.ChannelLayout, 0);
            ffmpeg.av_opt_set_int(pointer,        "in_sample_rate",     sourceFormat.SampleRate, 0);
            ffmpeg.av_opt_set_sample_fmt(pointer, "in_sample_fmt",      sourceFormat.SampleFormat.ToAVFormat(), 0);

            // Out
            ffmpeg.av_opt_set_int(pointer,        "out_channel_layout", (long)targetFormat.ChannelLayout, 0);
            ffmpeg.av_opt_set_int(pointer,        "out_sample_rate",    targetFormat.SampleRate, 0);
            ffmpeg.av_opt_set_sample_fmt(pointer, "out_sample_fmt",     targetFormat.SampleFormat.ToAVFormat(), 0);

            // filter_size
            // phase_shift
            // cutoff

            ffmpeg.swr_init(pointer).EnsureSuccess();
        }

        public void Convert(AudioFrame source, AudioFrame target)
        {
            int targetSamples = GetOutputSampleCount(source.SampleCount);

            target.Resize(targetSamples);
            
            var sampleCount = ffmpeg.swr_convert(
                s         : pointer,
                @out      : target.Pointer->extended_data,
                out_count : targetSamples,
                @in       : source.Pointer->extended_data, // pointer to the planes / data
                in_count  : source.SampleCount
            );

            if (sampleCount < 0) throw new FFmpegException(sampleCount);

            target.SampleCount      = sampleCount;
            target.Dts              = source.Dts;
            target.Pts              = source.Pts;
            target.ChannelCount     = targetFormat.ChannelCount;
            target.SampleRate       = targetFormat.SampleRate;
            target.ChannelLayout    = targetFormat.ChannelLayout;
            target.SampleFormat     = targetFormat.SampleFormat;

            // TODO: Set the presentation time & duration

            Console.WriteLine($"resampled {source.SampleFormat} {source.SampleCount} -> {targetFormat.SampleFormat} {target.SampleCount} | {sampleCount} | {target.ChannelCount} | {target.Memory.Length}");
        }

        private int GetOutputSampleCount(int inSampleCount)
        {
            long delaySampleCount = ffmpeg.swr_get_delay(pointer, sourceFormat.SampleRate);

            return (int)ffmpeg.av_rescale_rnd(
                delaySampleCount + inSampleCount, 
                targetFormat.SampleRate,
                sourceFormat.SampleRate,
                AVRounding.AV_ROUND_UP
            );
        }

        public unsafe void Dispose()
        {
            fixed (SwrContext** p = &pointer)
            {
                ffmpeg.swr_free(p);
            }
        }
    }
}