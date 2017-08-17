namespace Carbon.Media
{
    // A media container may hold one more more types of media
    // include audio, video, captions, and still images

    public enum MediaContainerType
    {
        _3GP     = 1,   // 3GP                           | 3gp  | audio, video
        _3GP2    = 2,   // 3GP2                          | 3g2  | audio, video
        Aiff     = 11,  // Audio Interchange File Format | aiff | audio
        Asf      = 13,  // Advanced Systems Format       | asf  | audio (wma), video (wmv)
        Au       = 14,  // by Sun Microyststems          | ?    | audio
        Avi      = 15,  // Audio Video Interleave        | avi  | audio, video
        Dmf      = 41,  // DivX Media Format             | ?    | audio, video        
        Flv      = 62,  // Flash Video                   | flv  | audio, video
        Matroska = 130, // Matroska Multimedia Container | mks  | audio (mka), video (mkv)
        MJ2      = 133, // Motion JPEG 2000              | mj2  | image
        Mov      = 134, // Quicktime                     | mov  | audio, video
        Mp4      = 135, // MPEG-4 Part 14                | mp4  | audio (m4a), video (m4v)
        Mxf      = 138, // Material eXchange Format      | mxf  | ?
        Ogg      = 155, // OGG                           | ogg  | audio (oga), video (ogv)
        Rmff     = 184, // RealMedia File Format         | rm   | audio (ra), video
        Tiff     = 205, // Tagged Image File Format      | tiff | images
        Wav      = 230, // Waveform Audio Format         | wav  | audio
        WebM     = 232, // audio, video                  | webm | audio, video
        Xmf      = 240  // eXtensible Music Format       | xdf  | audio
    }
}

// https://www.w3.org/2008/WebVideo/Fragments/wiki/State_of_the_Art/Containers
// https://en.wikipedia.org/wiki/Comparison_of_video_container_formats