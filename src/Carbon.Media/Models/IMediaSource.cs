namespace Carbon.Media
{
    public interface IMediaSource
    {
        string Key { get; }

        int Width { get; }

        int Height { get; }

        ExifOrientation? Orientation { get; }

        // change to: long Id
    }
}