namespace Carbon.Media
{
    public enum MediaType : byte
    {
        Unknown     = 0,
        Application = 1,
        Audio       = 2, 
        Example     = 3,
        Image       = 4, 
        Message     = 5, 
        Model       = 6, 
        Multipart   = 7,
        Text        = 8,
        Video       = 9,
        Font        = 10 // 2017-02 | https://tools.ietf.org/html/rfc8081#section-4.4.5
    }
}

// http://www.iana.org/assignments/media-types/media-types.xhtml