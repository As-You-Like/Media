using System;

namespace Carbon.Media.Codecs
{
    public class AacEncoder : Encoder
    {
        private readonly AacEncoderOptions options;

        public AacEncoder(AacEncoderOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override CodecId Id => CodecId.Aac;
    }

    public class AacEncoderOptions
    {
        public BitRate BitRate { get; set; }

        public int Quality { get; set; }

        public int Cutoff { get; set; }
        
        public string Codec { get; set; }

        public string Profile { get; set; }
    }


    public enum AacCoder
    {
        TwoLoop = 1,
        Anmr    = 2,
        Fast    = 3
    }

    public enum AacProfile
    {
        Low = 1,
        LongTermPrediction = 2,
        Main = 3
    }
}