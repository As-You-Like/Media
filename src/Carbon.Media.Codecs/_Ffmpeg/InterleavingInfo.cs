namespace Carbon.Media
{
    public readonly struct InterleavingInfo
    {
        public InterleavingInfo(long chunkSize, long chuckDuration)
        {
            ChuckSize     = chunkSize;
            ChuckDuration = chuckDuration;
        }

        public long ChuckSize { get; }

        public long ChuckDuration { get; }
    }
}