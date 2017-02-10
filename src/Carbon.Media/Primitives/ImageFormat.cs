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
        public static string ToLower(this ImageFormat value)
        {
            switch (value)

            {
                case ImageFormat.Gif  : return "gif";
                case ImageFormat.Jpeg : return "jpeg";
                case ImageFormat.Png  : return "png";
                case ImageFormat.WebP : return "webp";
            }

            return value.ToString().ToLower();

        }
    }
}
