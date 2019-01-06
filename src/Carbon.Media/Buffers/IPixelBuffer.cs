using System;

namespace Carbon.Media.Buffers
{
    public interface IPixelBuffer : IDisposable
    {
        IntPtr Pointer { get; }

        int Length { get; }

        Span<byte> Span { get; }

        int Height { get; }

        int Width { get; }

        int Stride { get; }
    }
}