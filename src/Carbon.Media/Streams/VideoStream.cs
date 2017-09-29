using System.Drawing;

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

        /// <summary>
        /// The coded size of the frame
        /// </summary>
        public Size FrameSize { get; set; }

        public Rational? FrameRate { get; set; }

        // Horizontal Aspect Ratio
        public Rational? AspectRatio { get; set; }

        public ExifOrientation? Orientation { get; set; }

        public PixelFormat PixelFormat { get; }

        public override MediaStreamType Type => MediaStreamType.Video;
    }
}