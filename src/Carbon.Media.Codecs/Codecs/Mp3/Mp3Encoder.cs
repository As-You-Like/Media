using System;
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public sealed class Mp3Encoder : AudioEncoder
    {
        private readonly Mp3EncodingParameters parameters;

        private static readonly ChannelLayout[] channlLayouts = {
            ChannelLayout.Mono,
            ChannelLayout.Stereo
        };

        private static readonly SampleFormat[] sampleFormats = {
            SampleFormat.Int32Planar,
            SampleFormat.FloatPlanar,
            SampleFormat.Int16Planar
        };

        private static readonly int[] sampleRates = { 44100, 48000, 32000, 22050, 24000, 16000, 11025, 12000, 8000 };

        public Mp3Encoder(Mp3EncodingParameters parameters)
            : base(CodecId.Mp3)
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

            base.InternalOpen(this.parameters.ToOptions());

            // Console.WriteLine(string.Join(',', AudioFormatHelper.GetSampleFormats(base.Context.Codec.Id)));
            // Console.WriteLine(string.Join(',', AudioFormatHelper.GetSupportedChannelLayouts(base.Context.Codec.Id)));
            // Console.WriteLine(string.Join(',', AudioFormatHelper.GetSupportedSampleRates(base.Context.Codec.Id)));


            // requires global header?
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