namespace Carbon.Media
{
    public enum PixelFormatFlags
    {
        None          = 0,
        BigEndian     = 1 << 0,
        Packed        = 1 << 1,
        Planar        = 1 << 2,
        Premultiplied = 1 << 3 // Otherwise straight
    }
}