namespace Carbon.Media
{
    public interface IMediaSource : ISize
    {
        string Key { get; }

        ImageOrientation? Orientation { get; }

        // change to: long Id
    }
}