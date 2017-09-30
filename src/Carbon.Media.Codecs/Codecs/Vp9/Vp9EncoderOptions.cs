namespace Carbon.Media.Codecs
{
    public class Vp9EncoderOptions
    {
        public BitRate BitRate { get; set; }

        public BitRate MinimumBitRate { get; set; }

        public BitRate MaximumBitRate { get; set; }

        public int MaximiumKeyframeDistance { get; set; }

        public Vp9Quality Quality { get; set; }

        // undershoot
        // overshoot

        // skipthreshhold
        // maxRate
    }
}