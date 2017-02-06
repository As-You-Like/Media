using System;

namespace Carbon.Media
{
    public enum CropAnchor
    {
        Top         = 1 << 1,
        Right       = 1 << 2,
        Bottom      = 1 << 3,
        Left        = 1 << 4,
        Center      = 1 << 5
    }

    public static class CropAnchorExtensions
    {
        public static string ToCode(this CropAnchor anchor)
        {
            switch (anchor)
            {
                case CropAnchor.Bottom                     : return "b";
                case CropAnchor.Bottom | CropAnchor.Left   : return "bl";
                case CropAnchor.Bottom | CropAnchor.Right  : return "br";
                case CropAnchor.Center                     : return "c";
                case CropAnchor.Left                       : return "l";
                case CropAnchor.Right                      : return "r";
                case CropAnchor.Top                        : return "t";
                case CropAnchor.Top | CropAnchor.Left      : return "tl";
                case CropAnchor.Top | CropAnchor.Right     : return "tr";

                default: throw new ArgumentException($"Invalid anchor. Was '{anchor}'");
            }
        }
    }
}