using System;
using System.Runtime.InteropServices;

namespace Carbon.Media.Buffers
{
    public class PixelBuffer : IPixelBuffer
    {
        public bool isDisposed = false;

        public PixelBuffer(PixelFormat format, int width, int height, IntPtr pointer, int length)
        {
            Format = format;
            Width = width;
            Height = height;
            Pointer = pointer;
            Length = length;
        }

        public IntPtr Pointer { get; }

        public int Length { get; }

        public PixelFormat Format { get; }

        public unsafe Span<byte> Span => new Span<byte>((void*)Pointer, Length);

        public int Width { get; }

        public int Height { get; }

        public int Stride => GetBytesPerPixel(Format) * Width;

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        private void Dispose(bool diposing)
        {
            if (isDisposed) return;

            Marshal.FreeHGlobal(Pointer);

            isDisposed = true;
        }

        ~PixelBuffer()
        {
            Dispose(true);
        }

        public static PixelBuffer Allocate(PixelFormat format, int width, int height)
        {
            if (width <= 0)
                throw new ArgumentException("Must be > 0", nameof(width));

            if (height <= 0)
                throw new ArgumentException("Must be > 0", nameof(height));

            
            int stride = width * GetBytesPerPixel(format);
            int length = stride * height;

            if (length > 1024 * 1024 * 1024)
            {
                throw new Exception($"buffer must be less than 1GB. Was {width}x{height} * {GetBytesPerPixel(format)}.");
            }

            IntPtr pointer = Marshal.AllocHGlobal(stride * height);

            return new PixelBuffer(
               format  : format,
               width   : width,
               height  : height,
               pointer : pointer,
               length  : length
            );
        }

        public static int GetBytesPerPixel(PixelFormat pixelFormat)
        {
            switch (pixelFormat)
            {
                case PixelFormat.Bgr24  : return 3;
                case PixelFormat.Bgra32 : return 4;
                case PixelFormat.Rgb24  : return 3;
                case PixelFormat.Rgba32 : return 4;
                case PixelFormat.Gray8  : return 1;
            }

            throw new Exception("Unsupported pixel format:" + pixelFormat);
        }
    }
}
