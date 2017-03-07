namespace Carbon.Media
{
    public enum MediaType : byte
    {
        Unknown     = 0,
        Application = 1, // 1,203 registered
        Audio       = 2, // 141 registered
        Example     = 3,
        Image       = 4, // 52 registered
        Message     = 5, // 18 registered
        Model       = 6, // 20 registered
        Multipart   = 7,
        Text        = 8,
        Video       = 9  // 75 registered
    }

    // http://www.iana.org/assignments/media-types/media-types.xhtml
}