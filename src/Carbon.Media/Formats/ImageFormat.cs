using System;

namespace Carbon.Media
{
    using static ImageFormat;

    public enum ImageFormat
    {
        _3fr = 4005, // Hasselblad
        Bmp  = 4101, // BMP
        Bpg  = 4105, // Better Portable Graphics
        Cr2  = 4127, // Canon 2 Raw 
        Crw  = 4130, // Canon Raw
        Cur  = 4140, // Windows Cursor
        Dcr  = 4200, // Kodak Raw
        Dng  = 4208, // Digital Negative (Adobe Raw)
        Exr  = 4210, // OpenEXR
        Fpx  = 4212, // FlashPix
        Gif  = 4219, // GIF
        Heif = 4230, // High Efficiency Image Format
        Icns = 4243, // Icon File Format
        Ico  = 4245, // Windows Icon Format
        Jp2  = 4305, // JPEG2000
        Jpeg = 4309, // JPEG
        Jxr  = 4355, // JPEG-XR
        Mrw  = 4404, // Minolta Raw
        Orf  = 4453, // Olympus Raw
        Pef  = 4509, // Pentax
        Png  = 4520, // PNG
        Pnt  = 4523, // MacPaint
        Psd  = 4550, // PSD
        Raf  = 4580, // Fuji Raw
        R3d  = 4594, // Red Digital Cinema
        Srf  = 4620, // Sony RAW
        Svg  = 4630, // SVG
        Tga  = 4770, // Targa
        Tiff = 4775, // TIFF
        WebP = 4890, // WebP
        X3f  = 4900, // Sigma Raw
        Xbm  = 4910, // XWindow Bitmap
    }

    public static class ImageFormatHelper
    {
        public static ImageFormat Parse(string text)
        {
            text = FileFormat.Normalize(text);

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

            throw new Exception("Unsupported image format:" + text);
        }
    }
}