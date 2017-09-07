using System;

namespace Carbon.Media
{
    public interface IVideoInfo
    {
        CodecInfo Codec { get; }

        TimeSpan Duration { get; }

        int Width { get; }

        int Height { get; }

        // 1/25
        Rational FrameRate { get; }

        Rational AspectRatio { get; }

        PixelFormat PixelFormat { get; }

        int PlaneCount { get; }

        int Alignment { get; }

        int[] Strides { get; }
    }
}