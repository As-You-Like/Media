namespace Carbon.Media
{
    public enum MediaFramework
    {
        Unknown         = 0,
        CoreAudio       = 1,
        CoreImage       = 2,
        FFmpeg          = 3, 
        MediaFoundation = 4, // AAC (encode & decode), AVI, WAVE, H.264, MP3, MP4
        WIC             = 5, // GIF, ICO, JPEG, JXR, JXR, TIFF
    }
}