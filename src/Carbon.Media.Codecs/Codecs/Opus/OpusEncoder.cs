using System;

using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public sealed class OpusEncoder : AudioEncoder
    {
        public static readonly SampleFormat[] sampleFormats = { SampleFormat.Int16, SampleFormat.Float };
        public static readonly int[] sampleRates = { 48000, 24000, 16000, 12000, 8000 };

        private readonly OpusEncodingParameters parameters;

        public OpusEncoder(OpusEncodingParameters parameters)
           : base(CodecId.Opus)
        {
            this.parameters = parameters ?? throw new ArgumentNullException(nameof(parameters)); 
        }

        public override void Open()
        {
            SetFormat(parameters.GetFormatInfo());

            if (parameters.BitRate != null)
            {
                Context.BitRate = parameters.BitRate;
            }

            InternalOpen(parameters.ToOptions());
        }

        public override SampleFormat[] SampleFormats => sampleFormats;

        public override int[] SampleRates => sampleRates;

        public override string GetFilterGraph()
        {
            string sampleFormat = ffmpeg.av_get_sample_fmt_name(Context.SampleFormat.ToAVFormat());

            // 20ms @ 48000 = 960 samples
            int sampleCount = (Context.SampleRate / 1000) * 20;

            return $"aresample={Context.SampleRate},aformat=sample_fmts={sampleFormat}:channel_layouts=stereo,asetnsamples=n={sampleCount}:p=0";
        }
    }
}