using System;

namespace Carbon.Media
{
    public interface IVideoInfo
    {
        CodecInfo Codec { get; }

        TimeSpan Duration { get; }

        int Width { get; }

        int Height { get; }

        // 30
        Rational FrameRate { get; }
    }
}