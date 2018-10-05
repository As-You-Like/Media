using System;

namespace Carbon.Media
{
    using static FormatId;

    public static class FormatIdExtensions
    {
        public static string GetVideoFormat(this FormatId formatId) =>
             formatId.ToVideoMime().Format;

        public static string GetAudioFormat(this FormatId formatId) =>
            formatId.ToAudioMime().Format;

        public static Mime ToAudioMime(this FormatId formatId)
        {
            switch (formatId)
            {
                case _3GP     : return Mime._3GP_A;  // audio/3gpp
                case _3GP2    : return Mime._3GP2_A; // audio/3gpp2
                case Aiff     : return Mime.Aiff;    // audio/aiff
                case Asf      : return Mime.Wma;     
                case Avi      : return Mime.Avi;     
                case Mp3      : return Mime.Mp3;      // audio/mpeg
                case M4a      : return Mime.M4a;      // audio/mp4
                case Mp4      : return Mime.M4a;      // audio/mp4
                case Ogg      : return Mime.Oga;      // audio/ogg
                case Opus     : return Mime.Opus;    
                case Mka      : return Mime.Mka;     
                case Matroska : return Mime.Mka;      // audio/x-matroska 
                case Wave     : return Mime.Wav;      // audio/wav
                case WebM     : return Mime.WebM;     // video/webm
            }

            throw new ArgumentException($"{formatId} does not have an audio only type");
        }

        public static Mime ToVideoMime(this FormatId formatId)
        {
            switch (formatId)
            {
                case _3GP     : return Mime._3GP;  // video/3gpp
                case _3GP2    : return Mime._3GP2; // video/3gpp2
                case Aiff     : return Mime.Aiff;
                case Asf      : return Mime.Wmv;   // video/x-ms-asf | video/x-ms-wmv
                case Avi      : return Mime.Avi;
                case Matroska : return Mime.Mkv;   // video/x-matroska 
                case Mov      : return Mime.Mov;   // video/quicktime
                case Mp4      : return Mime.M4v;
                case Ogg      : return Mime.Ogv;   // video/ogg
                case Wave     : return Mime.Wav;   // audio/wav
                case WebM     : return Mime.WebM;  // video/webm
            }

            throw new ArgumentException($"{formatId} does not have a video only type");
        }

        public static Mime ToMime(this FormatId value)
        {
            return Mime.FromFormat(value);
        }

        public static string Canonicalize(this FormatId value)
        {
            switch (value)
            {
                // Applications
                case Json : return "JSON";

                // Audio
                case Aac  : return "AAC";
                case Flac : return "FLAC";
                case M4a  : return "M4A";
                case Mp3  : return "MP3";
                case Opus : return "Opus";

                // Images
                case Bmp  : return "BMP";
                case Bpg  : return "BPG";
                case Gif  : return "GIF";
                case Dng  : return "DNG";
                case Heif : return "HEIF";
                case Ico  : return "ICO";
                case Jpeg : return "JPEG";
                case Jp2  : return "JP2";
                case Jxr  : return "JXR"; 
                case Png  : return "PNG";
                case Psd  : return "PSD";
                case Svg  : return "SVG";
                case Tiff : return "TIFF";
                case WebP : return "WebP";

                // Video
                case Mp4    : return "MP4";
                case M4v    : return "M4V";

                case WebM   : return "WebM";

                // Fonts
                case Ttf    : return "TTF";
                case Woff   : return "WOFF";
                case Woff2  : return "WOFF2";
            }

            return value.ToString().ToUpper();
        }
        
        public static FormatId Parse(string text)
        {
            switch (text)
            {
                case "gif"  : return Gif;  
                case "jpeg" : return Jpeg;
                case "mp4"  : return Mp4;
                case "png"  : return Png;
                case "webp" : return WebP;
                case "aif"  : return Aiff;
                case "fpix" : return Fpx;
                case "jpe"  : return Jpeg;
                case "jpg"  : return Jpeg;
                case "tif"  : return Tiff;
                case "wave" : return Wav;
            }
            
            if (Enum.TryParse<FormatId>(text, true, out var format))
            {
                return format;
            }

            throw new InvalidValueException("format", text); 
        }
    }
}