using System;

namespace Carbon.Media
{
    using static ImageFormat;

    public enum ImageFormat
    {
        _3fr = 4005, // Hasselblad
        Bmp  = 4101, // BMP
        Bpg  = 4105, // Better Portable Graphics
        Crw  = 4130, // Canon Digital Camera Raw Image Format
        Dcr  = 4200, // Kodak Digital Camera Raw Image File
        Dng  = 4208, // Digital Negative
        Gif  = 4219, // GIF
        Heif = 4230, // High Efficiency Image File Format
        Ico  = 4245, // ICO
        Jp2  = 4305, // JPEG2000
        Jpeg = 4309, // JPEG
        Jxr  = 4355, // JPEG-XR
        Mrw  = 4404, // Sony (Minolta) Raw Image File
        Orf  = 4453, // Olympus Digital Camera Raw Image File
        Pef  = 4509, // Pentax
        Png  = 4520, // PNG
        Psd  = 4550, // PSD
        Raf  = 4580, // Fuji
        R3d  = 4594, // Red Digital Cinema
        Svg  = 4630, // SVG
        Tiff = 4775, // TIFF
        WebP = 4890, // WebP
        X3f  = 4900, // Sigma Camera RAW Picture File
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

            throw new Exception("Unexpected format:" + text);
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

            throw new Exception("Unexpected format:" + value.ToLower());
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