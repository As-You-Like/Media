using System;

namespace Carbon.Media
{
    public class FormatInfo
    {
        public FormatInfo(FormatId id, Mime[] mimes)
        {
            Id    = id;
            Mimes = mimes ?? throw new ArgumentNullException(nameof(mimes));
        }

        public FormatInfo(FormatId id, Mime mime)
        {
            Id = id;
            Mimes = new[] { mime };
        }

        public FormatId Id { get; }
        
        public Mime[] Mimes { get; }

        public static readonly FormatInfo Json = new FormatInfo(FormatId.Json, Mime.Json);
        public static readonly FormatInfo Avi  = new FormatInfo(FormatId.Avi,  Mime.Avi);
        public static readonly FormatInfo Mp3  = new FormatInfo(FormatId.Mp3,  Mime.Mp3);
        public static readonly FormatInfo Mp4  = new FormatInfo(FormatId.Mp4,  Mime.Mp4);
        public static readonly FormatInfo Mkv  = new FormatInfo(FormatId.Mkv,  Mime.Mkv); // Matroska Video
        public static readonly FormatInfo Ogg  = new FormatInfo(FormatId.Ogg,  new[] { Mime.Oga, Mime.Ogv });
        public static readonly FormatInfo Tiff = new FormatInfo(FormatId.Tiff, Mime.Tiff );
        public static readonly FormatInfo WebM = new FormatInfo(FormatId.WebM, new[] { Mime.WebM });
    }
}