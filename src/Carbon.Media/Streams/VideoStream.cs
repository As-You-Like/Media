namespace Carbon.Media
{
    public class VideoStream : MediaStream
    {
        public VideoStream(int index, ICodec codec, PixelFormat pixelFormat)
            : base(index, codec)
        {
            PixelFormat = pixelFormat;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public int CodedWidth { get; set; }

        public int CodedHeight { get; set; }

        public Rational? FrameRate { get; set; }

        // Horizontal Aspect Ratio
        public Rational? AspectRatio { get; set; }
        
        public ExifOrientation? Orientation { get; set; }

        public PixelFormat PixelFormat { get;  }

        public override MediaStreamType Type => MediaStreamType.Video;
    }
}