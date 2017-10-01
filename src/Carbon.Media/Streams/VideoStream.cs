using System.Drawing;

namespace Carbon.Media
{
    public class VideoStream : MediaStream
    {
        public VideoStream(
            int index, 
            ICodec codec, 
            PixelFormat pixelFormat, 
            int width, 
            int height)
            : base(index, codec)
        {
            PixelFormat = pixelFormat;
            Width       = width;
            Height      = height;
        }

        public PixelFormat PixelFormat { get; }

        public ColorSpace ColorSpace { get; set; }

        /// <summary>
        /// The frame width
        /// </summary>
        public int Width { get; }
        
        /// <summary>
        /// The frame height
        /// </summary>
        public int Height { get; }

        public Rational? PixelAspectRatio { get; set; }

        public Rational? FrameRate { get; set; }        

        public ExifOrientation? Orientation { get; set; }
        
        public override MediaType Type => MediaType.Video;
    }
}