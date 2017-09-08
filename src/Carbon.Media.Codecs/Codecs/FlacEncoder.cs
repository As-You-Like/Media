using System;

namespace Carbon.Media.Codecs
{
    public class FlacEncoder : Encoder
    {
        private readonly AacEncoderOptions options;

        public FlacEncoder(AacEncoderOptions options)
        {
            this.options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public override CodecId Id => CodecId.Flac;
    }

    public class FlacEncoderOptions
    {
        // Valid values are from 0 to 12, 5 is the default.
        public int CompressionLevel { get; set; }

        public int FrameSize { get; set; }

        public int LpcCoefficientPrecision { get; set; }

        public LpcType LpcType { get; set; }

        public int LpcPasses { get; set; }

        public int MinimumPartitionOrder { get; set; }

        public int MaximiumPartitionOrder { get; set; }

        public PredictionOrderMethod PredictionOrderMethod { get; set; }

        public string ChannelMode { get; set; }
    }

    public enum ChannelMode
    {
        Auto = 1,
        Indepedent = 2,
        LeftSide = 3,
        RightSide = 4,
        MiddleSide = 5
    }
    public enum PredictionOrderMethod
    {
        Estimation,
        _2Level,
        _3Level,
        _8Level,
        Search
    }

    public enum LpcType
    {
        None = 0,
        Fixed = 1,
        Levinson = 2,
        Cholesky = 3
    }
  
}