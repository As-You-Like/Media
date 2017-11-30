using System;

namespace Carbon.Media
{
    public class VideoFormatInfo
    {
        public VideoFormatInfo(
            PixelFormat pixelFormat,
            int width,
            int height,
            int[] strides,
            int bufferSize)
            : this(pixelFormat, width, height, strides, bufferSize, Timebases.Ffmpeg, new Rational(1, 1)) { }

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

        public int[] Strides { get; }
        
        public int BufferSize { get; } // FrameSize?
        
        public Rational TimeBase { get; }

        public Rational AspectRatio { get; }

        public static VideoFormatInfo Create(PixelFormat format, int width, int height, int align = 8)
        {
            return new VideoFormatInfo(
                format,
                width,
                height,
                VideoFormatHelper.GetStrides(format, width, align),
                VideoFormatHelper.GetBufferSize(format, width, height, align),
                default, 
                new Rational(1, 1)
            );
        }
    }
}
