using System;

namespace Carbon.Media
{
    using static MediaContainerType;

    public static class MediaContainerTypeExtensions
    {
        public static string GetVideoFormat(this MediaContainerType container)
        {
            return container.ToVideoMime().Format;
        }

        public static string GetAudioFormat(this MediaContainerType container)
        {
            return container.ToAudioMime().Format;
        }

        public static Mime ToAudioMime(this MediaContainerType container)
        {
            switch (container)
            {
                case _3GP       : return Mime._3GP;  // audio/3gpp
                case _3GP2      : return Mime._3GP2; // audio/3gpp2
                case Aiff       : return Mime.Aiff;
                case Asf        : return Mime.Wma;  
                case Avi        : return Mime.Avi;
                case Flv        : return Mime.Flv;
                case Mp4        : return Mime.M4a;
                case Ogg        : return Mime.Oga;  // audio/ogg
                case Wav        : return Mime.Wav;  // audio/wav
                case WebM       : return Mime.WebM; // video/webm
                case Matroska   : return Mime.Mka;  // audio/x-matroska 

                default: throw new ArgumentException("Invalid container:" + container);
            }
        }

        public static Mime ToVideoMime(this MediaContainerType container)
        {
            switch (container)
            {
                case _3GP      : return Mime._3GP;  // video/3gpp
                case _3GP2     : return Mime._3GP2; // video/3gpp2
                case Aiff      : return Mime.Aiff;
                case Asf       : return Mime.Wmv;   // video/x-ms-asf | video/x-ms-wmv
                case Avi       : return Mime.Avi;
                case Flv       : return Mime.Flv;
                case Matroska  : return Mime.Mkv;   // video/x-matroska 
                case Mp4       : return Mime.Mp4;
                case Ogg       : return Mime.Ogv;   // video/ogg
                case Quicktime : return Mime.Mov;   // video/quicktime
                case Wav       : return Mime.Wav;   // audio/wav
                case WebM      : return Mime.WebM;  // video/webm

                default: throw new ArgumentException("Invalid container:" + container);
            }
        }
    }
}