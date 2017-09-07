namespace Carbon.Media
{
    public enum PixelFormat
    {
        Unknown = 0,

        [BitCount(8)]  A8     = 1, // packed A    | 8
        [BitCount(16)] A16    = 2, // packed A    | 16
        [BitCount(32)] AFloat = 3, // packed A    | 32f
        [BitCount(16)] AHalf  = 4, // packed A    | 16f
        [BitCount(32)] Abgr32 = 5, // packed ABGR | 8:8:8:8
        [BitCount(32)] Argb32 = 4, // packed ARGB | 8:8:8:8

        // type
        [BitCount(30)] Bgr101010 = 10, // packed BGR | 10:10:10
        [BitCount(4)]  Bgr4      = 11, // packed BGR | 1:2:1
        [BitCount(8)]  Bgr8      = 12, // packed BGR | 3:3:2
        [BitCount(24)] Bgr24     = 13, // packed BGRA
        [BitCount(32)] Bgr32     = 14, 
        [BitCount(48)] Bgr48     = 15, // BGR | 16:16:16
        [BitCount(16)] Bgr555    = 16, // BGR | 5:5:5 | uint
        [BitCount(16)] Bgr565    = 17, // BGR | 5:6:5 | uint
        [BitCount(32)] Bgra16    = 18, // BGRA | 4:4:4:4
        [BitCount(32)] Bgra32    = 19,
        [BitCount(16)] Bgra555   = 20,

        [BitCount(1)] BlackWhite = 21,
        [BitCountAttribute(1)] WhiteBlack = 22,

        // CMYK ---------------------------------------------------------------------------------------           
        [BitCount(32)] Cmyk32      = 30,
        [BitCount(64)] Cmyk64      = 31,
        [BitCount(40)] CmykAlpha40 = 32,
        [BitCount(80)] CmykAlpha80 = 33,

        // Gray
        // TODO: Big & LE
        [BitCount(2)]  Gray2       = 41, // K | 2
        [BitCount(8)]  Gray8       = 42,
        [BitCount(4)]  Gray4       = 43,
        [BitCount(16)] Gray16      = 44, // K | 16 | Gamma:1.0
        [BitCount(16)] Gray16Half  = 45,
        [BitCount(32)] Gray32Float = 46, // Gamma:1.0
        [BitCount(16)] GrayAlpha16 = 47,


        // Indexed Formats ------------------------------------------------------
        [BitCount(1)] Indexed1 = 50, 
        [BitCount(2)] Indexed2 = 51, 
        [BitCount(4)] Indexed4 = 52, 
        [BitCount(8)] Indexed8 = 53,

        // pre-multiplied formats
        [BitCount(32)]  Pbgra32 = 60, // RGBA |  8:8:8:8
        [BitCount(128)] Prgba128Float = 61, // RGBA | 32:32:32:32
        [BitCount(64)]  Prgba64 = 62,

        // RGB ------------------------------------

        [BitCount(8)]   Rgb4             = 70, // packed RGB | 1:2:1 bitstream
        [BitCount(8)]   Rgb8             = 71, // packed RGB | 3:3:2
        [BitCount(24)]  Rgb24            = 72, // packed RGB | 8:8:8
        [BitCount(48)]  Rgb48            = 73, // packed RGB | 16:16:16
        [BitCount(128)] Rgb128Float      = 74, // RGB | 32:32:32:?
        [BitCount(128)] Rgb128FixedPoint = 75, // RGB | 32:32:32:?

        [BitCount(32)]  Rgba32 = 75,
        [BitCount(64)]  Rgba64 = 76,
        [BitCount(128)] Rgba128Float = 77,
        [BitCount(32)]  Rgba1010102 = 78, // packed RGBA | 10:10:10:2 
        [BitCount(32)]  Rgba1010102XR = 79, // packed RGBA | 10:10:10:2 

        [BitCount(12)]  Yuv420p = 100, // planar YUV | 4:2:0
        [BitCount(16)]  Yuyv422 = 101, // packed YUV | 4:2:2
        [BitCount(16)]  Yuv422p = 102, // planar YUV | 4:4:4
        [BitCount(24)]  Yuv444p = 103, // planar
        [BitCount(9)]   Yuv410p = 104, //  planar
        [BitCount(12)]  Yuv411p = 105, // planar
        Yuv440p = 106, //  planar YUV 4:4:0

        /*

        [BitsPerPixel(16)] Uyvy422, // packed YUV | 4:2:2
        [BitsPerPixel(12)] Uyyvyy411, //  packed YUV 4:1:1

        Pal8,
       
        Bgr4Byte, // packed RGB 1:2:1
        Rgb4Byte, // packed RGB 1:2:1

        Nv12, //  planar YUV 4:2:0
        Nv21, // planar YUV 4:2:0 (swap U & V)
        
        Abgr32, // packed ABGR 8:8:8:8

        Gray16be,
        Gray16le,
   
        [BitsPerPixel(20)] Yuva420p, // planar YUV | 4:2:0

        VdpauH264,
        VdpauMpeg1,
        VdpauMpeg2,
        VdpauWmv3,
        VdpauVc1,

        Rgb48be,
        Rgb48le,
        Rgb565be,
        Rgb565le,
        Rgb555be,
        Rgb555le,
        Bgr565be, // packed BGR 5:6:5
        Bgr565le,
        Bgr555be,
        Bgr555le,
        Yuv420p16le,
        Yuv420p16be,
        Yuv422p16le,
        Yuv422p16be,
        Yuv444p16le,
        Yuv444p16be,
        VdpauMpeg4,
        
        Rgb444le, // packed RGB | 4:4:4
       
        Rgb444be,
        Bgr444le,
        Bgr444be,
    
        Bgr48be, // packed RGB 16:16:16 
        Bgr48le,
        Yuv420p9be,
        Yuv420p9le,
        Yuv420p10be,
        Yuv420p10le,
        Yuv422p10be,
        Yuv422p10le,
        Yuv444p9be,
        Yuv444p9le,
        Yuv444p10be,
        Yuv444p10le,
        Yuv422p9be,
        Yuv422p9le,

        Gbrp,     // planar GBR 4:4:4
        Gbrp9be,  // planar GBR 4:4:4
        Gbrp9le,  // planar GBR 4:4:4
        Gbrp10be, // planar GBR 4:4:4
        Gbrp10le, // planar GBR 4:4:4
       
        Gbrp16be,

        Gbrp16le,
        Yuva422p, // planar YUV 4:2:2
        Yuva444p, // planar YUV 4:4:4
        Yuva420p9be,
        Yuva420p9le,
        Yuva422p9be,
        Yuva422p9le,
        Yuva444p9be,
        Yuva444p9le,
        Yuva420p10be,
        Yuva420p10le,
        Yuva422p10be,
        Yuva422p10le,
        Yuva444p10be,
        Yuva444p10le,
        Yuva420p16be,
        Yuva420p16le,
        Yuva422p16be,
        Yuva422p16le,
        Yuva444p16be,
        Yuva444p16le,
        [BitsPerPixel(36)] Xyz12le, // packed XYZ | 4:4:4
        [BitsPerPixel(36)] Xyz12be, // packed XYZ | 4:4:4
        Nv16,     // interleaved chroma YUV | 4:2:2
        Nv20le,   // interleaved chroma YUV | 4:2:2
        Nv20be,   // interleaved chroma YUV 4:2:2
        Rgba64be, // packed RGBA | 16:16:16:16
        Rgba64le,
        Bgra64be, // packed RGBA 16:16:16:16

        Bgra64le, // packed RGBA 16:16:16:16,
        Yvyu422, // packed YUV 4:2:2
        Ya16be,
        Ya16le,
        [BitsPerPixel(32)] Gbrap, // planar GBRA 4:4:4:4
        [BitsPerPixel(64)] Gbrap16be, // planar GBRA 4:4:4:4
        Gbrap16le, // planar GBRA 4:4:4:4 64bpp
        Qsv,
        Mmal,
       
        Yuv420p12be, // planar YUV 4:2:0
        Yuv420p12le, // planar YUV 4:2:0
        Yuv420p14be, // planar YUV 4:2:0
        Yuv420p14le, // planar YUV 4:2:0
        Yuv422p12be, // planar YUV 4:2:2
        Yuv422p12le, // planar YUV 4:2:2
        Yuv422p14be, // planar YUV 4:2:2
        Yuv422p14le, // planar YUV 4:2:2
        Yuv444p12be, // planar YUV 4:4:4
        Yuv444p12le, // planar YUV 4:4:4
        Yuv444p14be, // planar YUV 4:4:4
        Yuv444p14le, // planar YUV 4:4:4
        Gbrp12be,    // planar GBR 4:4:4
        Gbrp12le,    // planar GBR 4:4:4
        Gbrp14be,    // planar GBR 4:4:4
        Gbrp14le,    // planar GBR 4:4:4
        Yuvj411p,    // planar YUV 4:1:1
        BayerBggr8,
        BayerRggb8,
        BayerGbrg8,
        BayerGrbg8,
        BayerBggr16le,
        BayerBggr16be,
        BayerRggb16le,
        BayerRggb16be,
        BayerGbrg16le,
        BayerGbrg16be,
        BayerGrbg16le,
        BayerGrbg16be,
        Yuv440p10le, // planar YUV 4:4:0
        Yuv440p10be, // planar YUV 4:4:0
        Yuv440p12le, // planar YUV 4:4:0
        Yuv440p12be, // planar YUV 4:4:0
        Ayuv64le,    // packed AYUV 4:4:4
        Ayuv64be,    // packed AYUV 4:4:4
        P010le,
       
        P010be,
        Gbrap12be, // planar GBR 4:4:4:4
        Gbrap12le, // planar GBR 4:4:4:4
        Gbrap10be, // planar GBR 4:4:4:4
        Gbrap10le, // planar GBR 4:4:4:4

        Nb,
        */
    }
}

// http://ffmpeg.org/doxygen/2.8/pixfmt_8h.html#a9a8e335cf3be472042bc9f0cf80cd4c5a4b8a29937744c722f35fccafb91ebdf0
// https://msdn.microsoft.com/en-us/library/windows/desktop/ee719797(v=vs.85).aspx#cmyk_pixel_formats