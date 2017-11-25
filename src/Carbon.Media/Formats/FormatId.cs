namespace Carbon.Media
{
    public enum FormatId
    {
        // Applications
        Doc    = 1100,
        Eot    = 1150,
        Json   = 1400,
        Otf    = 1550,
        Pdf    = 1600,
        Ttf    = 1700,
        Woff   = 1850,
        Woff2  = 1851,
        
        // Audio Only Formats
        Aac    = 2000,
        Ac3    = 2005,
        Aiff   = 2010, // Audio Interchange File Format
        Alac   = 2015, // Apple Lossless
        Amr    = 2016, // Adaptive Multi-Rate ACELP
        Ape    = 2018, // Monkey's Audio (APE)
        Flac   = 2105, // Free Lossless Audio Codec
        Mp1    = 2300, // MPEG-1 Audio Layer I
        Mp2    = 2301, // MPEG-1 Audio Layer II
        Mp3    = 2302, // MPEG-1 Audio Layer III
        Mpc    = 2350, // Musepack
        Opus   = 2410,
        Pcm    = 2430,
        Speex  = 2500,
        Tta    = 2650, // True Audio
        Vorbis = 2700,
        Wav    = 2800,
        Wma    = 2805, // Windows Media Audio
        Wmal   = 2806, // Windows Media Audio Lossless
        Wv     = 2850, // WavPack

        // Image Formats
        _3fr = 4005, // Hasselblad
        Bmp  = 4101, // BMP
        Bpg  = 4105, // Better Portable Graphics
        Cr2  = 4127, // Canon 2 Raw 
        Crw  = 4130, // Canon Raw
        Cur  = 4140, // Windows Cursor
        Dcr  = 4200, // Kodak Raw
        Dng  = 4208, // Digital Negative
        Exr  = 4210, // OpenEXR
        Fpx  = 4212, // FlashPix
        Gif  = 4219, // GIF
        Heif = 4230, // High Efficiency Image File Format
        Icns = 4243, // Icon File Format
        Ico  = 4245, // ICO
        Jp2  = 4305, // JPEG2000
        Jpeg = 4309, // JPEG
        Jxr  = 4355, // JPEG-XR
        Mrw  = 4404, // Sony (Minolta) Raw Image File
        Orf  = 4453, // Olympus Raw
        Pef  = 4509, // Pentax
        Png  = 4520, // PNG
        Pnt  = 4523, // MacPaint
        Psd  = 4550, // PSD
        Raf  = 4580, // Fuji
        R3d  = 4594, // Red Digital Cinema
        Srf  = 4620, // Sony Raw
        Svg  = 4630, // SVG
        Tga  = 4770, // Targa
        Tiff = 4775, // TIFF
        WebP = 4890, // WebP
        X3f  = 4900, // Sigma Camera RAW Picture File
        Xbm  = 4910, // XWindow Bitmap

        // Video Formats
        _3gp   = 9000, //
        Amv    = 9001, //
        Asf    = 9002,  // Advanced Systems Format        | asf  | audio (wma), video (wmv)
        Avi    = 9003, // Audio Video Interleave          | avi  | audio, video
        Drc    = 9004, // Dirac
        F4v    = 9010, // Flash
        Flv    = 9011, // Flash Video                     | flv  | audio, video
        Mkv    = 9020, // Matroska
        Mov    = 9021, // Quicktime                       | mov  | audio, video
        Ogv    = 9025, // Ogg
        WebM   = 9022, // audio, video                    | webm | audio, image (webp), video
        Mp4    = 9050, // MPEG-4 Part 14                  | mp4  | audio (m4a), video (m4v)
        Wmv    = 9090, // Windows 

        // TODO: Subtitle formats

        // Multimedia Containers & Streaming Protocols (0 - 1000)
        _3GP     = 1,   // 3GP                             | 3gp  | audio, video, subtitle
        _3GP2    = 2,   // 3GP2                            | 3g2  | audio, video, subtitle
        Adts     = 10,  // 
        Au       = 14,  // by Sun Microyststems            | ?    | audio
        Dmf      = 41,  // DivX Media Format               | ?    | audio, video        
        Fits     = 59,  // Flexible Image Transport System | ?    | image
        Matroska = 130, // Matroska Multimedia Container   | ?    | audio (mka), video (mkv), subtitles (mks)
        MJ2      = 132, // Motion JPEG 2000                | mj2  | image
        Mxf      = 138, // Material eXchange Format        | mxf  | ?
        Ogg      = 155, // OGG                             | ogg  | audio (oga), video (ogv)
        Rmff     = 184, // RealMedia File Format           | rm   | audio (ra), video
        Wave     = 230, // Waveform Audio Format           | wav  | audio
        Xmf      = 240, // eXtensible Music Format         | xdf  | audio
                 
        Hls      = 250, // HTTP Live Streaming              | m3u8
    }
}

// https://www.w3.org/2008/WebVideo/Fragments/wiki/State_of_the_Art/Containers
// https://en.wikipedia.org/wiki/Comparison_of_video_container_formats