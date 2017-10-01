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
    }
}