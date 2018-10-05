namespace Carbon.Media.Metadata
{
    public class GifMetadata : ImageInfo
    {
        public FrameDisposalMethod FrameDisposalMethod { get; set; }

        public int? LoopCount { get; set; }
    }
}