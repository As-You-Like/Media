using System;

namespace Carbon.Media
{
    using static ImageFormat;

    public static class ImageFormatHelper
    {
        public static ImageFormat Parse(string text)
        {
            text = FileFormat.Normalize(text);

            switch (text)
            {
                case "apng" : return Apng;
                case "bmp"  : return Bmp;
                case "bgp"  : return Bpg;
                case "cr2"  : return Cr2;
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

            throw new Exception("Invalid ImageFormat:" + text);
        }
    }
}