using System;

namespace Carbon.Media.Codecs
{
    public class OpusEncoder : AudioEncoder
    {
        public static readonly SampleFormat[] sampleFormats = { SampleFormat.Int16, SampleFormat.Float };
        public static readonly int[] sampleRates = { 48000, 24000, 16000, 12000, 8000 };

        public OpusEncoder(OpusEncodingParameters options)
           : base(CodecId.Opus)
        {
            SetFormat(options.GetFormatInfo());

            if (options.BitRate != null)
            {
                Context.BitRate = options.BitRate;
            }

            Open(); // options.ToOptions());
        }

        public override SampleFormat[] SampleFormats => sampleFormats;

        public override int[] SampleRates => sampleRates;
    }
}