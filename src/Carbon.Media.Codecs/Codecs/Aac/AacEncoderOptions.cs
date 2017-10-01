namespace Carbon.Media.Codecs
{
    public class AacEncoderOptions
    {
        public BitRate? BitRate { get; set; }

        public AacQuality? Quality { get; set; }

        public int Cutoff { get; set; }

        public string Codec { get; set; }

        public AacProfile Profile { get; set; }
    }

    public enum AacQuality
    {
        _1 = 1, // 20-32kbs
        _2 = 2, // 32-40kbs
        _3 = 3, // 48-56kbs
        _4 = 4, // 64-72kbs
        _5 = 5  // 96-112kbs
    }

    // VBR = Quality
    // CBR = BitRate
}