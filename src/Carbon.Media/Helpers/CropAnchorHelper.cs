using System;

namespace Carbon.Media
{
    using static CropAnchor;

    public static class CropAnchorHelper
    {
        public static CropAnchor Parse(string text)
        {
            #region Preconditions

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            #endregion

            switch (text)
            {
                case "b":
                case "s":
                case "bottom": return Bottom;

                case "bl": return Bottom | Left;
                case "sw": return Bottom | Left;
                case "br": return Bottom | Right;
                case "se": return Bottom | Right;

                case "c":
                case "center": return Center;

                case "w":
                case "west":
                case "l":
                case "left":  return Left;

                case "e":
                case "east":
                case "r":
                case "right": return Right;

                case "n":
                case "north":
                case "t":
                case "top": return Top;

                case "nw":
                case "tl": return Top | Left;

                case "ne":
                case "tr": return Top | Right;

                default: throw new Exception("Unexpected anchor:" + text);
            }
        }
    }
}
