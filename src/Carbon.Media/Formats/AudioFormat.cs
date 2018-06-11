namespace Carbon.Media
{
    public enum AudioFormat
    {
        Aac    = FormatId.Aac,
        Ac3    = FormatId.Ac3,
        Aiff   = FormatId.Aiff, // Audio Interchange File Format
        Alac   = FormatId.Alac, // Apple Lossless
        Amr    = FormatId.Amr,  // Adaptive Multi-Rate ACELP
        Ape    = FormatId.Ape,  // Monkey's Audio (APE)
        Awb    = 2070,          // Adaptive Multi-Rate Wideband 
        Flac   = FormatId.Flac, // Free Lossless Audio Codec
        Mp1    = FormatId.Mp1,  // MPEG-1 Audio Layer I
        Mp2    = FormatId.Mp2,  // MPEG-1 Audio Layer II
        Mp3    = FormatId.Mp3,  // MPEG-1 Audio Layer III
        Mpc    = FormatId.Mpc,  // Musepack
        Opus   = FormatId.Opus, // OPUS
        Pcm    = FormatId.Pcm,
        Speex  = FormatId.Speex,
        Tta    = FormatId.Tta,  // True Audio
        Vorbis = FormatId.Vorbis,
        Wav    = FormatId.Wav,
        Wma    = FormatId.Wma,  // Windows Media Audio
        Wmal   = FormatId.Wmal, // Windows Media Audio Lossless
        Wv     = 2850,          // WavPack
    }
}