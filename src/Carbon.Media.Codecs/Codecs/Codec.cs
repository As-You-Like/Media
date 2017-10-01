namespace Carbon.Media.Codecs
{
    // Each codec may implement an Encoder & Decoder

    public abstract class Codec : ICodec
    {
        public abstract CodecId Id { get; }
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