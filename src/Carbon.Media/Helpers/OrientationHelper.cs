using System;

namespace Carbon.Media
{
    using Processors;

    using static ExifOrientation;

    public static class OrientationHelper
    {
        public static Size GetOrientatedSize(ISize media, ExifOrientation orientation)
        {
            switch (orientation)
            {
                case Transpose:
                case Rotate90:
                case Transverse:
                case Rotate270 : return new Size(media.Height, media.Width);
                default        : return new Size(media.Width, media.Height);
            }
        }

        public static ExifOrientation Parse(string text) => 
            (ExifOrientation)Enum.Parse(typeof(ExifOrientation), text);

        public static IProcessor[] GetTransforms(this ExifOrientation orientation)
        {
            switch (orientation)
            {
                case FlipHorizontal : return new IProcessor[] { Flip.Horizontally };
                case Rotate180      : return new IProcessor[] { new Rotate(180) };
                case FlipVertical   : return new IProcessor[] { Flip.Vertically };
                case Transpose      : return new IProcessor[] { Flip.Horizontally, new Rotate(270) };
                case Rotate90       : return new IProcessor[] { new Rotate(90) };
                case Transverse     : return new IProcessor[] { Flip.Horizontally, new Rotate(90) };
                case Rotate270      : return new IProcessor[] { new Rotate(270) };
                default             : return new IProcessor[0];
            }
        }
    }
}
