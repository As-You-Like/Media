namespace Carbon.Media
{
    public interface IImage
    {
        ImageFormatId Format { get; }

        int Width { get; }

        int Height { get; }

        PixelFormat PixelFormat { get; }
    }
}