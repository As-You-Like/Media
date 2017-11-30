namespace Carbon.Media.Formats
{
    public enum FontFormat
    {
        Eot,            // web format for ttf
        Otf,            // evolution of ttf
        Ttf,
        Woff,           // WOFF is basically OTF or TTF with metadata and compression supported by all major browsers.
        Woff2,          // better compression
        Svg
    }
}