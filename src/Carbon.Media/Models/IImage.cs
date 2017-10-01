namespace Carbon.Media
{
    public interface IImage
    {
        ImageFormat Format { get; }

        int Width { get; }

        int Height { get; }

        PixelFormat PixelFormat { get; }
    }
}