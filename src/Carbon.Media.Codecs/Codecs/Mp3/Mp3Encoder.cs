using System;

namespace Carbon.Media.Codecs
{
    public sealed class Mp3Encoder : AudioEncoder
    {
        private readonly Mp3EncodingParameters options;

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

        public Mp3Encoder(Mp3EncodingParameters options)
            : base(CodecId.Mp3)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));

            // Console.WriteLine(string.Join(',', AudioFormatHelper.GetSampleFormats(base.Context.Codec.Id)));
            // Console.WriteLine(string.Join(',', AudioFormatHelper.GetSupportedChannelLayouts(base.Context.Codec.Id)));
            // Console.WriteLine(string.Join(',', AudioFormatHelper.GetSupportedSampleRates(base.Context.Codec.Id)));

            SetFormat(options.GetFormatInfo());

            if (options.BitRate != null)
            {
                Context.BitRate = options.BitRate;
            }

            // requires global header?

            Open(options.ToOptions());
        }

        public override SampleFormat[] SampleFormats => sampleFormats;

        public override int[] SampleRates => sampleRates;
    }
}