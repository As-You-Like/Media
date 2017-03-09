namespace Carbon.Media
{
    // A media container may hold one more more types of media
    // include audio, video, captions, and still images

    public enum MediaContainerType
    {
        _3GP      = 1,   // 3GP                           | 3gp  | audio, video
        _3GP2     = 2,   // 3GP2                          | 3g2  | audio, video
        Aiff      = 11,  // ?                             | aiff | audio
        Asf       = 13,  // Advanced Systems Format       | asf  | audio (wma), video (wmv)
        Avi       = 15,  // Audio Video Interleave        | avi  | audio, video
        Dmf       = 41,  // DivX Media Format             | ?    | audio, video        
        Flv       = 62,  // Flash Video                   | flv  | audio, video
        Matroska  = 130, // Matroska Multimedia Container | mks  | audio (mka), video (mkv)
        MJ2       = 134, // Motion JPEG 2000              | mj2  | image
        Mp4       = 135, // MPEG-4 Part 14                | mp4  | audio (m4a), video (m4v)
        Mxf       = 138, // Material eXchange Format      | mxf  | ?
        Ogg       = 155, // OGG                           | ogg  | audio (oga), video (ogv)
        Quicktime = 173, // Quicktime                     | mov  | audio, video
        RealMedia = 184, // RealMedia                     | rm   | audio, video
        Wav       = 230, // Waveform Audio Format         | wav  | audio
        WebM      = 231, // audio, video                  | webm |
        Xmf       = 240  // Extensible Music Format       | xdf  | audio
    }
}

// https://en.wikipedia.org/wiki/Comparison_of_video_container_formats