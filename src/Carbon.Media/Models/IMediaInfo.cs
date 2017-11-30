namespace Carbon.Media
{
    public interface IMediaInfo
    {
        string Key { get; }

        int Width { get; }

        int Height { get; }

        ExifOrientation? Orientation { get; }
    }
}