namespace Carbon.Media
{
    public enum PixelFormatFlags
    {
        None          = 0,
        BigEndian     = 1 << 1,
        Packed        = 1 << 2,
        Planar        = 1 << 3,
        Premultiplied = 1 << 4
    }
}