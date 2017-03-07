namespace Carbon.Media
{
    // TODO: Keep in sync with MediaCodecType

    public enum ImageFormat
    {
        Bmp      = 401,
        Bpg      = 402,
        Dng      = 408, // Digital Negative
        Gif      = 410,
        Heif     = 420, // High Efficiency Image File Format
        Ico      = 425,
        Jp2      = 430, // JPEG2000
		Jpeg     = 431,
		Jxr      = 432, // JPEG-XR
		Png      = 450,
        Psd      = 460,
        Svg      = 460,
		Tiff     = 470,
		WebP     = 480,
    }

    public static class ImageFormatExtensions
    {
        public static string Canonicalize(this ImageFormat value)
        {
            switch (value)
            {
                case ImageFormat.Gif  : return "GIF";
                case ImageFormat.Dng  : return "DNG";
                case ImageFormat.Ico  : return "ICO";
                case ImageFormat.Jpeg : return "JPEG";
                case ImageFormat.Jp2  : return "JP2";
                case ImageFormat.Jxr  : return "JXR"; 
                case ImageFormat.Png  : return "PNG"; 
                case ImageFormat.Svg  : return "SVG";
                case ImageFormat.Tiff : return "TIFF";
                case ImageFormat.WebP : return "WebP";
            }

            return value.ToString().ToUpper();
        }

        public static string ToLower(this ImageFormat value)
        {
            switch (value)
            {
                case ImageFormat.Gif  : return "gif";
                case ImageFormat.Dng  : return "dng";
                case ImageFormat.Ico  : return "ico";
                case ImageFormat.Jpeg : return "jpeg";
                case ImageFormat.Png  : return "png";
                case ImageFormat.Svg  : return "svg";
                case ImageFormat.WebP : return "webp";
            }

            return value.ToString().ToLower();
        }
    }
}
