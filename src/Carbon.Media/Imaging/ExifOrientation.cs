using System;

namespace Carbon.Media
{
    using static ExifOrientation;

    public enum ExifOrientation : byte
    {
        None           = 0, // None
        Horizontal     = 1, // None
        FlipHorizontal = 2, // Flip horizontally
        Rotate180      = 3, // Rotate 180
        FlipVertical   = 4, // Flip vertically
        Transpose      = 5, // Transpose (mirror horizontal and rotate 270)
        Rotate90       = 6, // Rotate 90
        Transverse     = 7, // Transverse (mirror horizontal and rotate 90)
        Rotate270      = 8  // Rotate 270
    }
    
    public static class ExifOrientationHelper
    {
        public static ExifOrientation Parse(string text)
        {
            switch (text)
            {
                case "0"          : return None;
                case "1"          : return Horizontal;
                case "2"          : return FlipHorizontal;
                case "3"          : return Rotate180;
                case "4"          : return FlipVertical;
                case "5"          : return Transpose;
                case "6"          : return Rotate90;
                case "7"          : return Transverse;
                case "8"          : return Rotate270;


                case "transverse" : return Transverse;
                case "transpose"  : return Transpose;

                case "h":
                case "horizontal" : return Horizontal;
                
                default: throw new Exception("Unexpected orientation:" + text);
            }
        }
    }
}

// transverse|transpose
// rotate(90deg|180deg|270deg)
// flip(y)
// flip(x)