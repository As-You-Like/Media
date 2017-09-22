namespace Carbon.Media
{
    public enum MediaStreamType : byte
    {
        Audio     = 2,
        Video     = 9,
        Subtitles = 10 // e.g. 3GPP Timed Text
    }

    // Container Format Parts
    // "chunks" as in RIFF and PNG
    // "atoms" in QuickTime/MP4
    // "packets" in MPEG-TS (from the communications term), 
    // "segments" in JPEG. 
}