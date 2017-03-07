namespace Carbon.Media
{
    public interface IMediaSource : ISize
    {
        string Key { get; }

        ExifOrientation? Orientation { get; }

        // change to: long Id
    }
}