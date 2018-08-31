using System;

namespace Carbon.Media.Frames
{
    public sealed class ImageFrame : IDisposable
    {
        public ImageFrame(PixelFormat format, int width, int height, Buffer memory)
        {
            Format = format;
            Width = width;
            Height = height;
            Memory = memory ?? throw new ArgumentNullException(nameof(memory));
        }

        // Allocate?

        public PixelFormat Format { get; }

        public int Width { get; }

        public int Height { get; }
        
        // public int[] Strides { get; }

        public Buffer Memory { get; }

        private bool isDisposed = false;

        public ImageFrame Create(PixelFormat format, int width, int height)
        {
            if (width <= 0)  throw new ArgumentException("Must be > 0", nameof(width));
            if (height <= 0) throw new ArgumentException("Must be > 0", nameof(height));

            var memory = Buffer.Allocate(VideoFormatHelper.GetBufferSize(format, width, height, 1));

            return new ImageFrame(format, width, height, memory);
        
            // Strides = VideoFormatHelper.GetStrides(format, width);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (isDisposed) return;
            
            Memory.Dispose();

            isDisposed = true;
        }

        ~ImageFrame()
        {
            Dispose(false);
        }
    }
}
