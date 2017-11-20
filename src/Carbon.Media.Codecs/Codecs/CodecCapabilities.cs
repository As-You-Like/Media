namespace Carbon.Media.Codecs
{
    public enum CodecCapabilities
    {
        None                 = 0,
        HardwareAcceleration = 1 << 0,
        Lossless             = 1 << 1
    }
}
