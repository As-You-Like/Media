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

        public PixelFormat PixelFormat { get; }

        /// <summary>
        /// The screen width
        /// </summary>
        public int Width { get; set; }
        
        /// <summary>
        /// The screen height
        /// </summary>
        public int Height { get; set; }
        
        /// <summary>
        /// The coded size of the frame
        /// </summary>
        public Size FrameSize { get; set; }

        public Rational? FrameRate { get; set; }        
        
        public Rational? PixelAspectRatio { get; set; }

        public ExifOrientation? Orientation { get; set; }
        
        public override MediaType Type => MediaType.Video;
    }
}