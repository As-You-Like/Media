using System;

namespace Carbon.Media
{
    public class VideoFormatInfo : IEquatable<VideoFormatInfo>
    {
        public VideoFormatInfo(
            PixelFormat pixelFormat,
            int width,
            int height,
            int[] strides,
            int bufferSize)
            : this(pixelFormat, width, height, strides, bufferSize, new Rational(1, 1), new Rational(1, 1)) { }

        public VideoFormatInfo(
            PixelFormat pixelFormat,
            int width, 
            int height, 
            int[] strides, 
            int bufferSize,
            Rational timeBase,
            Rational aspectRatio)
        {
            #region Preconditions

            if (pixelFormat == default)
                throw new ArgumentException("Required", nameof(pixelFormat));

            if (width <= 0)
                throw new ArgumentException("Must be > 0", nameof(width));

            if (height <= 0)
                throw new ArgumentException("Must be > 0", nameof(height));

            #endregion

            PixelFormat = pixelFormat;
            Width       = width;
            Height      = height;
            Strides     = strides;
            BufferSize  = bufferSize;
            TimeBase    = timeBase;
            AspectRatio = aspectRatio;
        }

        public PixelFormat PixelFormat { get; }

        public int Width { get; }

        public int Height { get; }

        // The strides & buffer size are determined by the height & width + pixelFormat

        public int[] Strides { get; }
        
        // Calcuate?
        public int BufferSize { get; }
        
        // Allows for variable rate...
        public Rational TimeBase { get; }

        public Rational AspectRatio { get; }

        // Check timebase & aspectRatio?

        public bool Equals(VideoFormatInfo other) =>
            PixelFormat == other.PixelFormat &&
            Width       == other.Width &&
            Height      == other.Height;
    }
}
