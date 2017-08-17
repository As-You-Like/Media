using System;

namespace Carbon.Media
{
    using static CropAnchor;

    public enum CropAnchor
    {
        Top    = 1 << 1,
        Right  = 1 << 2,
        Bottom = 1 << 3,
        Left   = 1 << 4,
        Center = 1 << 5
    }

    public static class CropAnchorExtensions
    {
        public static string ToCode(this CropAnchor anchor)
        {
            switch (anchor)
            {
                case Bottom         : return "b";
                case Bottom | Left  : return "bl";
                case Bottom | Right : return "br";
                case Center         : return "c";
                case Left           : return "l";
                case Right          : return "r";
                case Top            : return "t";
                case Top | Left     : return "tl";
                case Top | Right    : return "tr";

                default: throw new ArgumentException($"Invalid anchor. Was '{anchor}'");
            }
        }
    }
}