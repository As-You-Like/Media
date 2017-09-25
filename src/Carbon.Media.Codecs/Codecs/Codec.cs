namespace Carbon.Media.Codecs
{
    public abstract class Codec : ICodec
    {
        public abstract CodecId Id { get; }
  
        // Profiles
    }

    public abstract class AudioCodec : Codec
    {
        public int[] SupportedSampleRates { get; set; }

        public ChannelLayout[] SupportedChannelLayouts { get; set; }

    }

    public abstract class VideoCodec : Codec
    {
        public Rational[] SupportedFrameRates { get; set; }

        public PixelFormat[] SupportedPixelFormats { get; set; }
    }
}