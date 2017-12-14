namespace Carbon.Media
{
    public readonly struct InterleavingInfo
    {
        public InterleavingInfo(long chunkSize, long chuckDuration)
        {
            ChuckSize     = chunkSize;
            ChuckDuration = chuckDuration;
        }

        public readonly long ChuckSize;

        public readonly long ChuckDuration;
    }
}