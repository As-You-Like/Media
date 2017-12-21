using System;
using System.Drawing;

using Carbon.Media.Processors;

namespace Carbon.Media
{
    using static ExifOrientation;

    public static class OrientationHelper
    {
        public static ExifOrientation Parse(string text)
        {
            if (char.IsDigit(text[0]))
            {
                switch (int.Parse(text))
                {
                    case 0: return None;
                    case 1: return Horizontal;
                    case 2: return FlipHorizontal;
                    case 3: return Rotate180;
                    case 4: return FlipVertical;
                    case 5: return Transpose;
                    case 6: return Rotate90;
                    case 7: return Transverse;
                    case 8: return Rotate270;
                }

                throw new Exception("Invalid orientation code:" + text);
            }

            switch (text.ToLower())
            {   
                case "none"           : return None;
                                      
                case "h":             
                case "horizontal"     : return Horizontal;
                                      
                case "transverse"     : return Transverse;
                case "transpose"      : return Transpose;

                case "fliphorizontal" : return FlipHorizontal;
                case "flipvertical"   : return FlipHorizontal;

                case "rotate90"       : return Rotate90;
                case "rotate180"      : return Rotate180;
                case "rotate270"      : return Rotate270;
            }

            throw new Exception("Invalid orientation:" + text);
        }

        public static Size GetOrientatedSize(Size size, ExifOrientation orientation)
        {
            switch (orientation)
            {
                case Transpose:
                case Rotate90:
                case Transverse:
                case Rotate270 : return new Size(size.Height, size.Width);
                default        : return new Size(size.Width, size.Height);
            }
        }

        public static IProcessor[] GetTransforms(this ExifOrientation orientation)
        {
            switch (orientation)
            {
                case FlipHorizontal : return new IProcessor[] { FlipTransform.Horizontally };
                case Rotate180      : return new IProcessor[] { new RotateTransform(180) };
                case FlipVertical   : return new IProcessor[] { FlipTransform.Vertically };
                case Transpose      : return new IProcessor[] { FlipTransform.Horizontally, new RotateTransform(270) };
                case Rotate90       : return new IProcessor[] { new RotateTransform(90) };
                case Transverse     : return new IProcessor[] { FlipTransform.Horizontally, new RotateTransform(90) };
                case Rotate270      : return new IProcessor[] { new RotateTransform(270) };
                default             : return Array.Empty<IProcessor>();
            }
        }
    }
}

// transverse|transpose
// rotate(90deg|180deg|270deg)
// flip(y)
// flip(x)