using System;

namespace Carbon.Media
{
    public interface IVideo
    {
        ICodec Codec { get; }

        TimeSpan? Duration { get; }

        /// <summary>
        /// The frame width
        /// </summary>
        int Width { get; }

        /// <summary>
        /// The frame height
        /// </summary>
        int Height { get; }

        // 1/25
        Rational FrameRate { get; }

        Rational AspectRatio { get; }

        PixelFormat PixelFormat { get; }

        // int PlaneCount { get; }

        // int Alignment { get; }

        // int[] Strides { get; }
    }
}