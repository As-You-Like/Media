using System;

namespace Carbon.Media
{
    using static CropAnchor;

    public static class CropAnchorExtensions
    {
        public static string ToAbbreviation(this CropAnchor anchor)
        {
            switch (anchor)
            {
                case Bottom       : return "b";
                case BottomLeft   : return "bl";
                case BottomRight  : return "br";
                case Center       : return "c";
                case Left         : return "l";
                case Right        : return "r";
                case Top          : return "t";
                case TopLeft      : return "tl";
                case TopRight     : return "tr";

                default: throw new ArgumentException($"Invalid anchor. Was '{anchor}'");
            }
        }
    }
}