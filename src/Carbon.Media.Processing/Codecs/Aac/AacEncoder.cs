using System;
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe sealed class AacEncoder : AudioEncoder
    {
        public static readonly SampleFormat[] sampleFormats = new[] { SampleFormat.F32p };

        public static readonly int[] sampleRates = {
            96000, 88200, 64000, 48000, 44100, 32000, 24000, 22050, 16000, 12000, 11025, 8000, 7350
        };

        private readonly AacEncodingParameters parameters;

        public AacEncoder(AacEncodingParameters parameters)
            : base(CodecId.Aac)
        {
            this.parameters = parameters ?? throw new ArgumentNullException();
        }

        public override void Open()
        {
            SetFormat(parameters.GetFormatInfo());

            if (parameters.BitRate != null)
            {
                Context.BitRate = parameters.BitRate;
            }

            /*
            Console.WriteLine(string.Join(',', AudioFormatHelper.GetSampleFormats(base.Context.Codec.Id)));
            Console.WriteLine(string.Join(',', AudioFormatHelper.GetSupportedChannelLayouts(base.Context.Codec.Id)));
            Console.WriteLine(string.Join(',', AudioFormatHelper.GetSupportedSampleRates(base.Context.Codec.Id)));
            */

            base.InternalOpen(parameters.ToOptions());
        }


        public override SampleFormat[] SampleFormats => sampleFormats;

        public override int[] SampleRates => sampleRates;

        public override string GetFilterGraph()
        {
            string sampleFormat = ffmpeg.av_get_sample_fmt_name(Context.SampleFormat.ToAVFormat());

            return $"aresample={Context.SampleRate},aformat=sample_fmts={sampleFormat}:channel_layouts=stereo,asetnsamples=n=1024:p=0";
        }
    }
}