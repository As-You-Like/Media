namespace Carbon.Media.Codecs
{
    public class VideoEncodingParameters
    {
        /// <summary>
        /// Average bitrate
        /// </summary>
        public BitRate? BitRate { get; set; }

        public BitRate? MinimumBitRate { get; set; }

        public BitRate? MaximumBitRate { get; set; }

        public Rational? FrameRate { get; set; }

        public Rational? AspectRatio { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public PixelFormat PixelFormat { get; set; }

        public Rational? TimeBase { get; set; }
    }
}