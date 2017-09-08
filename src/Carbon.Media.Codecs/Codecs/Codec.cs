namespace Carbon.Media.Codecs
{
    public abstract class Codec
    {
        // SupportedFrameRates
        // SupportedSampleRates

        public abstract CodecId Id { get; }

        public int[] SupportedSampleRates { get; set; }

        public Rational[] SupportedFrameRates { get; set; }

        public ChannelLayout[] SupportedChannelLayouts { get; set; }

        public PixelFormat[] SupportedPixelFormats { get; set; }
        

        // Profiles


    }
    
}