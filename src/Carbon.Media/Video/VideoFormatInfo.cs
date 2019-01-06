using System;

namespace Carbon.Media
{
    public class VideoFormatInfo : IEquatable<VideoFormatInfo>
    {
        public VideoFormatInfo(
            PixelFormat pixelFormat,
            int width,
            int height)
            : this(pixelFormat, width, height,  new TimeBase(1, 1), new Rational(1, 1)) { }

        public VideoFormatInfo(
            PixelFormat pixelFormat,
            int width, 
            int height, 
            TimeBase timeBase,
            Rational aspectRatio)
        {
            if (pixelFormat == default)
                throw new ArgumentException("Required", nameof(pixelFormat));

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), width, "Must be > 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), height, "Must be > 0");

            PixelFormat = pixelFormat;
            Width       = width;
            Height      = height;
            TimeBase    = timeBase;
            AspectRatio = aspectRatio;
        }

        public PixelFormat PixelFormat { get; }

        public int Width { get; }

        public int Height { get; }

        public TimeBase TimeBase { get; }

        public Rational AspectRatio { get; }

        public bool Equals(VideoFormatInfo other) =>
            PixelFormat == other.PixelFormat &&
            Width.Equals(other.Width) &&
            Height.Equals(other.Height) &&
            TimeBase.Equals(other.TimeBase) &&
            AspectRatio.Equals(other.AspectRatio);

        public override string ToString()
        {
            return $"VideoFormat({PixelFormat},{Width},{Height},{TimeBase},{AspectRatio})";
        }
    }
}