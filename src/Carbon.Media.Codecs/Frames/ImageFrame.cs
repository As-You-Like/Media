namespace Carbon.Media.Codecs
{
    // ImageFrame?

    public class ImageFrame
    {
        public ImageFrame(PixelFormat pixelFormat, int width, int height)
        {
            Format  = pixelFormat;
            Width   = width;
            Height  = height;
            Memory  = Buffer.Allocate(VideoFormatHelper.GetBufferSize(pixelFormat, width, height));
            Strides = VideoFormatHelper.GetStrides(pixelFormat, width);
        }

        public PixelFormat Format { get; }

        public int Width { get; }

        public int Height { get; }

        public int[] Strides { get; }

        public Buffer Memory { get; }
    }
}
