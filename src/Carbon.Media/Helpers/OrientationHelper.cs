using System;

namespace Carbon.Media
{
    using Processors;

    public static class OrientationHelper
    {
        public static Size GetOrientatedSize(ISize media, ImageOrientation orientation)
        {
            switch (orientation)
            {
                case ImageOrientation.Transpose:
                case ImageOrientation.Rotate90:
                case ImageOrientation.Transverse:
                case ImageOrientation.Rotate270 : return new Size(media.Height, media.Width);
                default                         : return new Size(media.Width, media.Height);
            }
        }

        public static ImageOrientation Parse(string text)
            => (ImageOrientation)Enum.Parse(typeof(ImageOrientation), text);
        

        public static IProcessor[] GetTransforms(this ImageOrientation orientation)
        {
            switch (orientation)
            {
                case ImageOrientation.FlipHorizontal    : return new IProcessor[] { Flip.Horizontally };
                case ImageOrientation.Rotate180         : return new IProcessor[] { new Rotate(180) };
                case ImageOrientation.FlipVertical      : return new IProcessor[] { Flip.Vertically };
                case ImageOrientation.Transpose         : return new IProcessor[] { Flip.Horizontally, new Rotate(270) };
                case ImageOrientation.Rotate90          : return new IProcessor[] { new Rotate(90) };
                case ImageOrientation.Transverse        : return new IProcessor[] { Flip.Horizontally, new Rotate(90) };
                case ImageOrientation.Rotate270         : return new IProcessor[] { new Rotate(270) };
                default                                 : return new IProcessor[0];
            }
        }
    }
}
