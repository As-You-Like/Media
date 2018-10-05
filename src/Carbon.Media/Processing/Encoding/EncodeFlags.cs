namespace Carbon.Media.Processing
{
    public enum EncodeFlags
    {
        None = 0,
        Progressive = 1 << 1,
        Lossless    = 1 << 2,
        _8bit       = 1 << 3,
        _32bit      = 1 << 4
        
    }
}