using System;

namespace Carbon.Media
{
    public class FormatInfo
    {
        public FormatInfo(ContainerId id, Mime[] mimes)
        {
            Id    = id;
            Mimes = mimes ?? throw new ArgumentNullException(nameof(mimes));
        }

        public ContainerId Id { get; }
        
        public Mime[] Mimes { get; }

        public static readonly FormatInfo Tiff     = new FormatInfo(ContainerId.Tiff,     new[] { Mime.Tiff });
        public static readonly FormatInfo Mp4      = new FormatInfo(ContainerId.Mp4,      new[] { Mime.Mp4 });
        public static readonly FormatInfo WebM     = new FormatInfo(ContainerId.WebM,     new[] { Mime.WebM });
        public static readonly FormatInfo Matroska = new FormatInfo(ContainerId.Matroska, new[] { Mime.Mka, Mime.Mkv });
        public static readonly FormatInfo Ogg      = new FormatInfo(ContainerId.Ogg,      new[] { Mime.Oga, Mime.Ogv });
        public static readonly FormatInfo Wave     = new FormatInfo(ContainerId.Wave,     new[] { Mime.Wav });
    }
}