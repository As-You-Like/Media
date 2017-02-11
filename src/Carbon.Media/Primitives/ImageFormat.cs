namespace Carbon.Media
{
    public enum ImageFormat
    {
        Bmp      = 1,
		Gif      = 2,
		Ico      = 3,
		Jpeg     = 4,
		Jpeg2000 = 5,
		Jxr      = 6,
        Pdf      = 7,
		Png      = 8,
        Psd      = 9,
        Svg      = 10,
		Tiff     = 11,
		WebP     = 12,
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
                case ImageFormat.Jxr  : return "JPEGXR"; 
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
