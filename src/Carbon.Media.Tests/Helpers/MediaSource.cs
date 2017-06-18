namespace Carbon.Media.Tests
{
    internal class MediaSource2 : IMediaSource
    {
        public MediaSource2(string key, int width, int height)
        {
            Key = key;
            Width = width;
            Height = height;
        }

        public ExifOrientation? Orientation => null;

        public string Key { get; }

        public int Width { get; }

        public int Height { get; }
    }
}
