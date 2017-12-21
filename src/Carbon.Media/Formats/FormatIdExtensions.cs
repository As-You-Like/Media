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
                case _3GP       : return Mime._3GP_Audio;  // audio/3gpp
                case _3GP2      : return Mime._3GP2_Audio; // audio/3gpp2
                case Aiff       : return Mime.Aiff;
                case Asf        : return Mime.Wma;  
                case Avi        : return Mime.Avi;
                case Flv        : return Mime.Flv;
                case Mp3        : return Mime.Mp3;  // audio/mpeg
                case Mp4        : return Mime.M4a;
                case Ogg        : return Mime.Oga;  // audio/ogg
                case Matroska   : return Mime.Mka;  // audio/x-matroska 
                case Wave       : return Mime.Wav;  // audio/wav
                case WebM       : return Mime.WebM; // video/webm

                default: throw new ArgumentException($"{formatId} does not have an audio only type");
            }
        }

        public static Mime ToVideoMime(this FormatId formatId)
        {
            switch (formatId)
            {
                case _3GP  : return Mime._3GP;  // video/3gpp
                case _3GP2 : return Mime._3GP2; // video/3gpp2
                case Aiff  : return Mime.Aiff;
                case Asf   : return Mime.Wmv;   // video/x-ms-asf | video/x-ms-wmv
                case Avi   : return Mime.Avi;
                case Flv   : return Mime.Flv;
                case Matroska   : return Mime.Mkv;   // video/x-matroska 
                case Mov   : return Mime.Mov;   // video/quicktime
                case Mp4   : return Mime.Mp4;
                case Ogg   : return Mime.Ogv;   // video/ogg
                case Wave  : return Mime.Wav;   // audio/wav
                case WebM  : return Mime.WebM;  // video/webm

                default: throw new ArgumentException($"{formatId} does not have a video only type");
            }
        }

        public static Mime ToMime(this FormatId value)
        {
            switch (value)
            {
                // Audio
                case Aac  : return Mime.Aac;
                case Flac : return Mime.Flac;
                case Mp3  : return Mime.Mp3;
                case Opus : return Mime.Opus;

                // Images
                case Bmp  : return Mime.Bmp;
                case Bpg  : return Mime.Bpg;
                case Gif  : return Mime.Gif;
                case Dng  : return Mime.Dng;
                case Heif : return Mime.Heif;
                case Ico  : return Mime.Ico;
                case Jpeg : return Mime.Jpeg;
                case Jp2  : return Mime.Jp2;
                case Jxr  : return Mime.Jxr;
                case Png  : return Mime.Png;
                case Psd  : return Mime.Psd;
                case Svg  : return Mime.Svg;
                case Tiff : return Mime.Tiff;
                case WebP : return Mime.WebP;

                // Videos
                case Mp4  : return Mime.Mp4;
                case WebM : return Mime.WebM;
            }

            throw new Exception("Invalid format:" + value.ToString());
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
                case Mp3  : return "MP3";
                case Opus : return "OPUS";

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
                case WebM: return "WebM";
            }

            return value.ToString().ToUpper();
        }
        
        public static FormatId Parse(string text)
        {
            text = FileFormat.Normalize(text);
            
            if (Enum.TryParse<FormatId>(text, true, out var format))
            {
                return format;
            }
          
            throw new Exception("Invalid format:" + text);
            
        }
    }
}