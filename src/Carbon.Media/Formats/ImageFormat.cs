using System;

namespace Carbon.Media
{
    using static ImageFormat;

    public enum ImageFormat
    {
        _3fr = 4005, // Hasselblad
        Art  = 4050, // ART
        Bmp  = 4101, // BMP
        Bpg  = 4105, // Better Portable Graphics
        Cin  = 4110, // Cineon
        Cr2  = 4127, // Canon 2 Raw 
        Crw  = 4130, // Canon Raw
        Cur  = 4140, // Windows Cursor
        Dcm  = 4160, // DICOM
        Dcr  = 4165, // Kodak Raw
        Dng  = 4170, // Digital Negative (Adobe Raw)
        Dpx  = 4175, // Digital Picture Exchange
        Exr  = 4200, // OpenEXR
        Flic = 4205, // Flic
        Fpx  = 4210, // FlashPix
        Gif  = 4220, // GIF
        Heif = 4230, // High Efficiency Image Format
        Icns = 4300, // Icon File Format
        Ico  = 4301, // Windows Icon Format
        Iges = 4305, // Initial Graphics Exchange Specification
        Jp2  = 4310, // JPEG2000
        Jpeg = 4320, // JPEG
        Jxr  = 4325, // JPEG-XR
        Kra  = 4350, // Krita
        Mrw  = 4404, // Minolta Raw
        Ora  = 4410, // OpenRaster
        Orf  = 4453, // Olympus Raw
        Pef  = 4509, // Pentax
        Pix  = 4510, // Alias Pix
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