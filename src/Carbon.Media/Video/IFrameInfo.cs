using System;

namespace Carbon.Media
{
    public interface IFrameInfo
    {
        TimeSpan? Offset { set; }

        int Height { get; }

        int Width { get; }

        Uri Url { get; }
    }
}