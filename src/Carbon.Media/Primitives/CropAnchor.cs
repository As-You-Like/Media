using System;

namespace Carbon.Media
{
    public enum CropAnchor
    {
        Unknown     = 0,
        TopLeft     = 1,
        TopRight    = 2,
        BottomRight = 3,
        BottomLeft  = 4,
        Center      = 5,
        Top         = 6,
        Bottom      = 7,
        Right       = 8,
        Left        = 9
    }

    public static class CropAnchorExtensions
    {
        public static string ToCode(this CropAnchor anchor)
        {
            switch (anchor)
            {
                case CropAnchor.Bottom       : return "b";
                case CropAnchor.BottomLeft   : return "bl";
                case CropAnchor.BottomRight  : return "br";
                case CropAnchor.Center       : return "c";
                case CropAnchor.Left         : return "l";
                case CropAnchor.Right        : return "r";
                case CropAnchor.Top          : return "t";
                case CropAnchor.TopLeft      : return "tl";
                case CropAnchor.TopRight     : return "tr";

                default: throw new ArgumentException($"Invalid anchor. Was '{anchor}'");
            }
        }
    }
}