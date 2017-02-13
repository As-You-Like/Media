namespace Carbon.Media
{
    public enum MediaType : byte
    {
        Unknown     = 0,
        Application = 1, // 0,1999        | 1,203 registered
        Audio       = 2, // 2000,2999     | 141 registered
        Example     = 3,
        Image       = 4, // 4000,4999     | 52 registered
        Message     = 5, //               | 18 registered
        Model       = 6, //               | 20 registered
        Multipart   = 7,
        Text        = 8,
        Video       = 9  // 9000,9999     | 75 registered
    }

    // http://www.iana.org/assignments/media-types/media-types.xhtml
}