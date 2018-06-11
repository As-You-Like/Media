using System;

namespace Carbon.Media
{
    using static ImageFormat;

    public enum ImageFormat
    {
        _3fr = FormatId._3fr, // Hasselblad
        Apng = FormatId.Apng, // Animated Png
        Art  = FormatId.Art,  // ART
        Bmp  = FormatId.Bmp,  // BMP
        Bpg  = FormatId.Bpg,  // Better Portable Graphics
        Cin  = FormatId.Cin,  // Cineon
        Cr2  = FormatId.Cr2,  // Canon 2 Raw 
        Crw  = FormatId.Crw,  // Canon Raw
        Cur  = FormatId.Cur,  // Windows Cursor
        Dcm  = FormatId.Dcm,  // DICOM
        Dcr  = FormatId.Dcr,  // Kodak Raw
        Dng  = FormatId.Dng,  // Digital Negative (Adobe Raw)
        Dpx  = FormatId.Dpx,  // Digital Picture Exchange
        Exr  = FormatId.Exr,  // OpenEXR
        Flic = FormatId.Flic, // Flic
        Fpx  = FormatId.Fpx,  // FlashPix
        Gif  = FormatId.Gif,  // GIF
        Heif = FormatId.Heif, // High Efficiency Image Format
        Icns = FormatId.Icns, // Icon File Format
        Ico  = FormatId.Ico,  // Windows Icon Format
        Iges = 4305,          // Initial Graphics Exchange Specification
        Jp2  = FormatId.Jp2,  // JPEG2000
        Jpeg = FormatId.Jpeg, // JPEG
        Jxr  = FormatId.Jxr,  // JPEG-XR
        Kra  = FormatId.Kra,  // Krita
        Mrw  = FormatId.Mrw,  // Minolta Raw
        Ora  = FormatId.Ora,  // OpenRaster
        Orf  = FormatId.Orf,  // Olympus Raw
        Pef  = FormatId.Pef,  // Pentax
        Pix  = FormatId.Pix,  // Alias Pix
        Png  = FormatId.Png,  // PNG
        Pnt  = FormatId.Pnt,  // MacPaint
        Psd  = FormatId.Psd,  // PSD
        Raf  = FormatId.Raf,  // Fuji Raw
        R3d  = FormatId.R3d,  // Red Digital Cinema
        Srf  = FormatId.Srf,  // Sony RAW
        Svg  = FormatId.Svg,  // SVG
        Tga  = FormatId.Tga,  // Targa
        Tiff = FormatId.Tiff, // TIFF
        WebP = FormatId.WebP, // WebP
        X3f  = FormatId.X3f,  // Sigma Raw
        Xbm  = FormatId.Xbm,  // XWindow Bitmap
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