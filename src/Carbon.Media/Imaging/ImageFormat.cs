namespace Carbon.Media
{
    using static ImageFormat;

    // NOTE: Keep in sync with CodecType

    public enum ImageFormat
    {
        Bmp  = 401,
        Bpg  = 402,
        Dng  = 408, // Digital Negative
        Gif  = 410,
        Heif = 420, // High Efficiency Image File Format
        Ico  = 425,
        Jp2  = 430, // JPEG2000
        Jpeg = 431,
        Jxr  = 432, // JPEG-XR
        Png  = 450,
        Psd  = 460,
        Svg  = 470,
        Tiff = 475,
        WebP = 490,
    }

    public static class ImageFormatHelper
    {
        public static ImageFormat Parse(string text)
        {
            switch (text)
            {
                case "bmp"  : return Bmp;
                case "bgp"  : return Bpg;
                case "gif"  : return Gif;
                case "dng"  : return Dng;
                case "heif" : return Heif;
                case "ico"  : return Ico;
                case "jpeg" : return Jpeg;
                case "jp2"  : return Jp2;
                case "jxr"  : return Jxr;
                case "png"  : return Png;
                case "psd"  : return Psd;
                case "svg"  : return Svg;
                case "tiff" : return Tiff;
                case "webp" : return WebP;
            }

            throw new System.Exception("Unexpected format:" + text);
        }
    }

    public static class ImageFormatExtensions
    {
        public static Mime ToMime(this ImageFormat value)
        {
            switch (value)
            {
                case Bmp  : return Mime.Bmp;
                case Bpg  : return Mime.Bpg;
                case Gif  : return Mime.Gif;
                case Dng  : return Mime.Dng;
                case Heif : return Mime.Heif;
                case Ico  : return Mime.Ico;
                case Jpeg : return Mime.Jpeg;
                case Jp2  : return Mime.Jp2;
                case Jxr  : return Mime.Jxr;
                case Png  : return Mime.Png;
                case Psd  : return Mime.Psd;
                case Svg  : return Mime.Svg;
                case Tiff : return Mime.Tiff;
                case WebP : return Mime.WebM;
            }

            throw new System.Exception("Unexpected format:" + value.ToLower());
        }

        public static string Canonicalize(this ImageFormat value)
        {
            switch (value)
            {
                case Bmp  : return "BMP";
                case Bpg  : return "BPG";
                case Gif  : return "GIF";
                case Dng  : return "DNG";
                case Heif : return "HEIF";
                case Ico  : return "ICO";
                case Jpeg : return "JPEG";
                case Jp2  : return "JP2";
                case Jxr  : return "JXR"; 
                case Png  : return "PNG";
                case Psd  : return "PSD";
                case Svg  : return "SVG";
                case Tiff : return "TIFF";
                case WebP : return "WebP";
            }

            return value.ToString().ToUpper();
        }

        public static string ToLower(this ImageFormat value)
        {
            return value.ToString().ToLower();
        }
    }
}
