namespace Carbon.Media.Metadata.Exif
{
    internal enum ExifTagFormat
    {
        Any         = 0,
        Ansi        = 1 << 0,
        Boolean     = 1 << 1,
        Byte        = 1 << 2,
        Date        = 1 << 3,
        Short       = 1 << 4,
        Long        = 1 << 5,
        Rational    = 1 << 6, // Unsigned
        SRational   = 1 << 7
    }
}