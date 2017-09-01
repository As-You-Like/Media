using System;

namespace Carbon.Media
{
    using static ColorChannel;

    public enum PixelFormat
    {
        Unknown = 0,

        [BitsPerPixel(8)]  A8 = 1,
        [BitsPerPixel(32)] Argb32 = 2,
        
        // type
        [BitsPerPixel(30)] Bgr101010 = 10, // BGR  | 10:10:10
        [BitsPerPixel(4)]  Bgr4      = 11, // packed BGR | 1:2:1
        [BitsPerPixel(8)]  Bgr8      = 12, // packed BGR | 3:3:2
        [BitsPerPixel(24)] Bgr24     = 13, // BGRA
        [BitsPerPixel(32)] Bgr32     = 14, 
        [BitsPerPixel(48)] Bgr48     = 15, // BGR | 16:16:16
        [BitsPerPixel(16)] Bgr555    = 16, // BGR | 5:5:5 | uint
        [BitsPerPixel(16)] Bgr565    = 17, // BGR | 5:6:5 | uint


        [BitsPerPixel(32)] Bgra16    = 18, // BGRA | 4:4:4:4
        [BitsPerPixel(32)] Bgra32    = 19,
        [BitsPerPixel(16)] Bgra555   = 20,

        [BitsPerPixel(1)] BlackWhite = 21,
        [BitsPerPixel(1)] WhiteBlack = 22,

        // CMYK ---------------------------------------------------------------------------------------           
        [BitsPerPixel(32)] Cmyk32 = 30,
        [BitsPerPixel(64)] Cmyk64 = 31,
        [BitsPerPixel(40)] CmykAlpha40 = 32,
        [BitsPerPixel(80)] CmykAlpha80 = 33,

        // Gray
        // TODO: Big & LE
        [BitsPerPixel(2)]  Gray2       = 41,          // G | 2
        [BitsPerPixel(8)]  Gray8       = 42,
        [BitsPerPixel(4)]  Gray4       = 43,
        [BitsPerPixel(16)] Gray16      = 44,         // G | 16 | Gamma:1.0
        [BitsPerPixel(16)] Gray16Half  = 45,
        [BitsPerPixel(32)] Gray32Float = 46, // Gamma:1.0

        // Indexed Formats ------------------------------------------------------
        [BitsPerPixel(1)] Indexed1 = 50, 
        [BitsPerPixel(2)] Indexed2 = 51, 
        [BitsPerPixel(4)] Indexed4 = 52, 
        [BitsPerPixel(8)] Indexed8 = 53,

        // pre-multiplied formats
        [BitsPerPixel(32)]  Pbgra32 = 60, // RGBA |  8:8:8:8
        [BitsPerPixel(128)] Prgba128Float = 61, // RGBA | 32:32:32:32
        [BitsPerPixel(64)]  Prgba64 = 62,

        // RGB ------------------------------------

        [BitsPerPixel(8)]   Rgb8             = 70, // packed RGB | 3:3:2
        [BitsPerPixel(24)]  Rgb24            = 71, // packed RGB | 8:8:8
        [BitsPerPixel(48)]  Rgb48            = 72, // packed RGB | 16:16:16
        [BitsPerPixel(128)] Rgb128Float      = 73, // RGB | 32:32:32:?
        [BitsPerPixel(128)] Rgb128FixedPoint = 74, // RGB | 32:32:32:?



        [BitsPerPixel(32)]  Rgba32 = 75,
        [BitsPerPixel(64)]  Rgba64 = 76,
        [BitsPerPixel(128)] Rgba128Float = 77,
        [BitsPerPixel(32)]  Rgba1010102 = 78, // packed RGBA | 10:10:10:2 
        [BitsPerPixel(32)]  Rgba1010102XR = 79, // packed RGBA | 10:10:10:2 

        Yuv420p = 100, // planar YUV | 4:2:0
        Yuyv422 = 101, // packed YUV | 4:2:2
        Yuv422p = 102, // planar YUV | 4:4:4
        Yuv444p = 103, //
        Yuv410p = 104, // 
        Yuv411p = 105, //

        Yuv440p,

        
        Rgb4,
        Nv12, // planar YUV | 4:2:0
        //  Nv21,


    }

    // https://msdn.microsoft.com/en-us/library/windows/desktop/ee719797(v=vs.85).aspx#cmyk_pixel_formats

    internal class BitsPerPixelAttribute : Attribute
    {
        public BitsPerPixelAttribute(int value)
        {
            Value = value;
        }

        public int Value { get; }
    }

    public static class PixelFormatHelper
    {
        public static PixelFormat Parse(string text)
        {
            Enum.TryParse(text, out PixelFormat format);

            return format;
        }
    }
}