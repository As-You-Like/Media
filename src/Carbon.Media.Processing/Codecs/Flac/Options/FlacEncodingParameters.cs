namespace Carbon.Media.Codecs
{
    public class FlacEncodingParameters
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
}