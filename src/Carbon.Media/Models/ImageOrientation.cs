namespace Carbon.Media
{
    public enum ImageOrientation : byte
    {
        None            = 0, // None
        Horizontal      = 1, // None
        FlipHorizontal  = 2, // Flip horizontally
        Rotate180       = 3, // Rotate 180
        FlipVertical    = 4, // Flip vertically
        Transpose       = 5, // Transpose (mirror horizontal and rotate 270)
        Rotate90        = 6, // Rotate 90
        Transverse      = 7, // Transverse (mirror horizontal and rotate 90)
        Rotate270       = 8  // Rotate 270
    }


    public static class ImageOrientationExtensions
    {
        public static string Canonicalize(this ImageOrientation value)
        {
            switch (value)
            {
                case ImageOrientation.FlipHorizontal : return "flip(x)";
                case ImageOrientation.Rotate180      : return "rotate(180deg)";
                case ImageOrientation.FlipVertical   : return "flip(y)";
                case ImageOrientation.Transpose      : return "transpose";
                case ImageOrientation.Rotate90       : return "rotate(90deg)";
                case ImageOrientation.Transverse     : return "transverse";
                case ImageOrientation.Rotate270      : return "rotate(270deg)";
                default                              : return null; 
            }
        }
    }

    // transverse|transpose
    // rotate(90deg|180deg|270deg)
    // flip(y)
    // flip(x)
}