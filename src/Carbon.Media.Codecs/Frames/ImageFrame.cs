using System;

namespace Carbon.Media.Frames
{
    public class ImageFrame : IDisposable
    {
        public ImageFrame(PixelFormat format, int width, int height)
        {
            Format  = format;
            Width   = width;
            Height  = height;
            Memory  = Buffer.Allocate(VideoFormatHelper.GetBufferSize(format, width, height));
            Strides = VideoFormatHelper.GetStrides(format, width);
        }

        public PixelFormat Format { get; }

        public int Width { get; }

        public int Height { get; }
        
        public int[] Strides { get; }

        public Buffer Memory { get; }

        private bool isDisposed = false;

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (isDisposed)
            {
                Memory.Dispose();

                isDisposed = true;
            }
        }

        ~ImageFrame()
        {
            Dispose(false);
        }
    }
}
