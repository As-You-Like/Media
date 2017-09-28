namespace Carbon.Media
{
    public enum PixelFormat
    {
        Unknown = 0,

        // Alpha Masks                        
        [BitCount(8)]   A8                = 1, // A    | 8                       | 8bppAlpha
        [BitCount(16)]  A16               = 2, // A    | 16
        [BitCount(32)]  AFloat            = 3, // A    | 32f
        [BitCount(16)]  AHalf             = 4, // A    | 16f
        [BitCount(32)]  Abgr32            = 5, // ABGR | 8:8:8:8
        [BitCount(32)]  Argb32            = 4, // ARGB | 8:8:8:8
        [BitCount(64)]  Argb64            = 5, // ARGB | 16:16:16:16
                        
        // RGA / BGR                      
        [BitCount(30)]  Bgr101010         = 10, // BGR  | 10:10:10
        [BitCount(4)]   Bgr4              = 11, // BGR  | 1:2:1
        [BitCount(8)]   Bgr8              = 12, // BGR  | 3:3:2
        [BitCount(24)]  Bgr24             = 13, // BGR  | 8:8:8
        [BitCount(32)]  Bgr32             = 14, // BGR  | 8:8:8:xxxx             | 32bppBGR   | Ignore
        [BitCount(48)]  Bgr48             = 15, // BGR  | 16:16:16
        [BitCount(16)]  Bgr555            = 16, // BGR  | 5:5:5:x     | uint     | 16bppBGR555
        [BitCount(16)]  Bgr565            = 17, // BGR  | 5:6:5       | uint     | 16bppBGR565
        [BitCount(32)]  Bgra16            = 18, // BGRA | 4:4:4:4
        [BitCount(32)]  Bgra32            = 19, // BGRA | 8:8:8:8
        [BitCount(16)]  Bgra555           = 20,

        [BitCount(8)]   Rgb4             = 30, // RGB | 1:2:1
        [BitCount(8)]   Rgb8             = 31, // RGB | 3:3:2
        [BitCount(24)]  Rgb24            = 32, // RGB | 8:8:8
        [BitCount(30)]  Rrb30            = 33, // RGB | 10:10:10:xx | 
        [BitCount(48)]  Rgb48            = 34, // RGB | 16:16:16    | big-endian
        [BitCount(128)] Rgb128Float      = 35, // RGB | 32:32:32:?
        [BitCount(128)] Rgb128FixedPoint = 36, // RGB | 32:32:32:?
        
        [BitCount(32)]  Rgba32           = 40,
        [BitCount(64)]  Rgba64           = 41,
        [BitCount(128)] Rgba128Float     = 42,
        [BitCount(32)]  Rgba1010102      = 43, // packed RGBA | 10:10:10:2 
        [BitCount(32)]  Rgba1010102XR    = 44, // packed RGBA | 10:10:10:2 

        // Bgr555be, // BGR 5:5:5:x    | 16bppBGR555
        // Bgr555le,
        // Bgr565be, // BGR 5:6:5      | 16bppBGR565
        // Bgr565le,
        // Rgb555be,
        // Rgb555le,
        // Rgb565be,  
        // Rgb565le,

        /*
        Gbrp,     // planar GBR 4:4:4
        Gbrp9be,  // planar GBR 4:4:4
        Gbrp9le,  // planar GBR 4:4:4
        Gbrp10be, // planar GBR 4:4:4
        Gbrp10le, // planar GBR 4:4:4

        Rgb444le, // packed RGB | 4:4:4
        Rgb444be,
        Bgr444le,
        Bgr444be,
        Bgr48be, // packed RGB 16:16:16 
        Bgr48le,
        Rgb48be,
        Rgb48le,
        
        Bgra64le, // packed RGBA 16:16:16:16,
        VdpauMpeg4,
        Rgba64be, // packed RGBA | 16:16:16:16
        Rgba64le,
        Bgra64be, // packed RGBA 16:16:16:16
        */

        // CMYK ---------------------------------------------------------------------------------------           
        [BitCount(32)] Cmyk32      = 60,
        [BitCount(64)] Cmyk64      = 61,
        [BitCount(40)] CmykAlpha40 = 62,
        [BitCount(80)] CmykAlpha80 = 63,

        // Gray
        [BitCount(1)]  BlackWhite  = 70,
        [BitCount(1)]  WhiteBlack  = 71,

        [BitCount(2)]  Gray2       = 82, // Gray | 2
        [BitCount(8)]  Gray8       = 83, // Gray | 8 | big-eiden
        [BitCount(8)]  Gray8le     = 84, // Gray | 8 | little-eiden
        [BitCount(4)]  Gray4       = 85,
        [BitCount(16)] Gray16      = 86, // Gray | 16 | Gamma:1.0
        [BitCount(16)] Gray16Half  = 87,
        [BitCount(32)] Gray32Float = 89,
        [BitCount(16)] GrayAlpha16 = 89,


        // Indexed Formats ------------------------------------------------------
        [BitCount(1)] Indexed1 = 70, // 1bppIndexed
        [BitCount(2)] Indexed2 = 71, // 2bppIndexed
        [BitCount(4)] Indexed4 = 72, // 4bppIndexed
        [BitCount(8)] Indexed8 = 73, // 8bppIndexed

        // pre-multiplied formats
        [BitCount(32)]  Pbgra32       = 80, // RGBA |  8:8:8:8              || ?
        [BitCount(128)] Prgba128Float = 81, // RGBA | 32:32:32:32
        [BitCount(64)]  Prgba64       = 82,

      


        // Bayer -------------------------------------------------------------------

        BayerBggr8      = 100,
        BayerRggb8      = 101,
        BayerGbrg8      = 102,
        BayerGrbg8      = 103,
        BayerBggr16le   = 104,
        BayerBggr16be   = 105,
        BayerRggb16le   = 106,
        BayerRggb16be   = 107,
        BayerGbrg16le   = 108,
        BayerGbrg16be   = 109,
        BayerGrbg16le   = 110,
        BayerGrbg16be   = 111,

        // YUV -------------------------------------------------------------------
                               // Description | Sampling
        Yuv420p         = 300, // planar YUV  | 4:2:0
        Yuv420p9be      = 301, // 
        Yuv420p9le      = 302,
        Yuv420p16le     = 303,
        Yuv420p16be     = 304,
        Yuv422p16le     = 305,
        Yuv422p16be     = 306,
        Yuv444p16le     = 307,
        Yuv444p16be     = 308,
        Yuyv422         = 309, // packed YUV | 4:2:2
        Yuv422p         = 310, // planar YUV | 4:4:4
        Yuv422p9be      = 311, // ?
        Yuv422p9le      = 312, // ?
        Yuv444p         = 313, // planar
        Yuv410p         = 314, // planar
        Yuv411p         = 315, // planar
        Yuv440p         = 316, // planar YUV 4:4:0
        Yuv444p10le     = 317,
        Yuv444p9be      = 318,
        Yuv444p9le      = 319,
        Yuv444p10be     = 320,
        Yuv420p10be     = 321,
        Yuv420p10le     = 322,
        Yuv422p10be     = 323,
        Yuv422p10le     = 324,     
        Yuva422p        = 325, // planar YUV | 4:2:2
        Yuva444p        = 326, // planar YUV | 4:4:4
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
        Yuv420p12be, // planar YUV | 4:2:0
        Yuv420p12le, // planar YUV | 4:2:0
        Yuv420p14be, // planar YUV | 4:2:0
        Yuv420p14le, // planar YUV | 4:2:0
        Yuv422p12be, // planar YUV | 4:2:2
        Yuv422p12le, // planar YUV | 4:2:2
        Yuv422p14be, // planar YUV | 4:2:2
        Yuv422p14le, // planar YUV | 4:2:2
        Yuv444p12be, // planar YUV | 4:4:4
        Yuv444p12le, // planar YUV | 4:4:4
        Yuv444p14be, // planar YUV | 4:4:4
        Yuv444p14le, // planar YUV | 4:4:4

        Uyvy422,     // packed YUV | 4:2:2
        Uyyvyy411,   // packed YUV | 4:1:1

        Yuv440p10le, // planar YUV 4:4:0 20bpp
        Yuv440p10be, // planar YUV 4:4:0 20bpp
        Yuv440p12le, // planar YUV 4:4:0 24bpp
        Yuv440p12be, // planar YUV 4:4:0 24bpp

        Yvyu422, // packed YUV 4:2:2

        Xyz12le, // packed XYZ | 4:4:4
        Xyz12be, // packed XYZ | 4:4:4

        Nv11,   // planar YUV 4:1:1
        Nv12,   // planar YUV 4:2:0
        Nv16,   // interleaved chroma YUV | 4:2:2
        Nv20be, // interleaved chroma YUV 4:2:2
        Nv20le, // interleaved chroma YUV | 4:2:2
        Nv21,   // planar YUV 4:2:0 (swap U & V)


        Ayuv64le, // packed AYUV 4:4:4
        Ayuv64be, // packed AYUV 4:4:4


        Imc1,   // planar YUV 4:2:0 16bpp
        Imc3,   // planar YUV 4:2:0 16bpp

        // Four CC Codecs

        P016 = 0, // Planar, 4:2:0, 16bit
        P010 = 0, // Planar, 4:2:0, 10-bit.
        P216 = 0, // Planar, 4:2:2, 16-bit.
        P210 = 0, // Planar, 4:2:2, 10-bit.
        Y216 = 0, // Packed, 4:2:2, 16-bit.
        Y210 = 0, // Packed, 4:2:2, 10-bit.
        Y416 = 0, // Packed, 4:4:4, 16-bit
        Y410 = 0, // Packed, 4:4:4, 10-bit.
        
        /*
        YUV ----------------------
        AI44		4:4:4	Packed
        AYUV		4:4:4	Packed
        I420		4:2:0	Planar
        IYUV		4:2:0	Planar
        UYVY		4:2:2	Packed
        Y41P		4:1:1	Packed
        Y41T		4:1:1	Packed
        Y42T		4:2:2	Packed
        YUY2		4:2:2	Packed
        YVU9		8:4:4	Planar
        YV12		4:2:0	Planar
        YVYU		4:2:2 	Packed

        */

        /*
        Pal8,
       
        Bgr4Byte, // packed RGB 1:2:1
        Rgb4Byte, // packed RGB 1:2:1

        
        [BitsPerPixel(20)] Yuva420p, // planar YUV | 4:2:0

        VdpauH264,
        VdpauMpeg1,
        VdpauMpeg2,
        VdpauWmv3,
        VdpauVc1,

        Gbrp16be,
        Gbrp16le,
       
       
       
        
        Ya16be,
        Ya16le,
        Gbrap, // planar GBRA 4:4:4:4
        Gbrap16be, // planar GBRA 4:4:4:4
        Gbrap16le, // planar GBRA 4:4:4:4 64bpp
        Qsv,
        Mmal,
       
        Gbrp12be,    // planar GBR 4:4:4
        Gbrp12le,    // planar GBR 4:4:4
        Gbrp14be,    // planar GBR 4:4:4
        Gbrp14le,    // planar GBR 4:4:4
        Yuvj411p,    // planar YUV 4:1:1

       
 
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
// https://developer.apple.com/documentation/corevideo/cvpixelformatdescription/1563591-pixel_format_types