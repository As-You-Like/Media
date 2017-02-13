namespace Carbon.Media
{
    public enum ImageFormat : short
    {
        Bmp  = 4001,
        Bpg  = 4002,
        Gif  = 4003,
        Ico  = 4004,
        Jp2  = 4005,
        Jpeg = 4006,
        Jxr  = 4007,
        Png  = 4008,
        Psd  = 4009,
        Svg  = 4010,
        Tiff = 4011,
        WebP = 4012
    }

    public static class ImageFormatExtensions
    {
        public static string Canonicalize(this ImageFormat value)
        {
            switch (value)
            {
                case ImageFormat.Gif  : return "GIF";  // Graphics Interchange Format
                case ImageFormat.Ico  : return "ICO";
                case ImageFormat.Jpeg : return "JPEG";
                case ImageFormat.Jp2  : return "JP2";
                case ImageFormat.Jxr  : return "JXR"; 
                case ImageFormat.Png  : return "PNG";  // Portable Network Graphics 
                case ImageFormat.Svg  : return "SVG";
                case ImageFormat.Tiff : return "TIFF"; // Tag Image File Format
                case ImageFormat.WebP : return "WebP";
            }

            return value.ToString().ToUpper();
        }

        public static string ToLower(this ImageFormat value)
        {
            switch (value)
            {
                case ImageFormat.Gif  : return "gif";
                case ImageFormat.Ico  : return "ico";
                case ImageFormat.Jpeg : return "jpeg";
                case ImageFormat.Png  : return "png";
                case ImageFormat.WebP : return "webp";
            }

            return value.ToString().ToLower();
        }
    }
}
