namespace Carbon.Media
{
    public enum PixelFormat
    {
        Unknown = 0,
        //                                                   | LAYOUT      | Packing  | WIC              | CoreImage
        // Alpha Masks ---------------------------------------------------------------------------------------------      
        [BitsPerPixel(8)]   A8                = 1,  // A     | 8           | byte     | 8bppAlpha
        [BitsPerPixel(16)]  A16               = 2,  // A     | 16          | int
        [BitsPerPixel(32)]  AFloat            = 3,  // A     | 32f         | float
        [BitsPerPixel(16)]  AHalf             = 4,  // A     | 16f         | half
                                                    
        // ARGB                                     
        [BitsPerPixel(32)]  Abgr32            = 5,  // ABGR  | 8:8:8:8     |           | ?                | 32ARGB
        [BitsPerPixel(32)]  Argb32            = 6,  // ARGB  | 8:8:8:8     |           |                  | 64ARGB
        [BitsPerPixel(64)]  Argb64            = 7,  // ARGB  | 16:16:16:16 | ulong     | 

        // BGR ----------------------------------------------------------------------------------------            
        [BitsPerPixel(4)]   Bgr4              = 10, // BGR   | 1:2:1
        [BitsPerPixel(8)]   Bgr8              = 11, // BGR   | 3:3:2      | byte
        [BitsPerPixel(16)]  Bgr444be          = 12, // BGR   | 4:4:4
        [BitsPerPixel(16)]  Bgr444le          = 13, // BGR   | 4:4:4                  
        [BitsPerPixel(16)]  Bgr555            = 14, // BGR   | 5:5:5:x    | uint     | 16bppBGR555
        [BitsPerPixel(16)]  Bgr555be          = 15, // BGR   | 5:5:5:x    |          | 16bppBGR555
        [BitsPerPixel(16)]  Bgr555le          = 16, // BGR   |                       
        [BitsPerPixel(16)]  Bgr565            = 17, // BGR   | 5:6:5      | uint     | 16bppBGR565
        [BitsPerPixel(16)]  Bgr565be          = 18, // BGR   | 5:6:5
        [BitsPerPixel(16)]  Bgr565le          = 19, // BGR   | 
        [BitsPerPixel(24)]  Bgr24             = 20, // BGR   | 8:8:8                 | 24bppBGR
        [BitsPerPixel(32)]  Bgr101010         = 21, // BGR   | 10:10:10              | 32bppBGR101010
        [BitsPerPixel(32)]  Bgr32             = 22, // BGR   | 8:8:8:xxxx |          | 32bppBGR
        [BitsPerPixel(48)]  Bgr48             = 23, // BGR   | 16:16:16   |           
        [BitsPerPixel(48)]  Bgr48be           = 24, // BGR   | 16:16:16 
        [BitsPerPixel(48)]  Bgr48le           = 25, // BGR   | 16:16:16
                                                             
        // BGRA                                              
        [BitsPerPixel(16)]  Bgra16            = 26, // BGRA  | 4:4:4:4
        [BitsPerPixel(16)]  Bgra555           = 27,          
        [BitsPerPixel(32)]  Bgra32            = 28, // BGRA  | 8:8:8:8               | 32bppBGRA  | 32BGRA
        [BitsPerPixel(64)]  Bgra64            = 29, // BGRA  |                       | 64bppRGBA
        [BitsPerPixel(64)]  Bgra64be          = 30, // BGRA  | 16:16:16:16
        [BitsPerPixel(64)]  Bgra64le          = 31, // BGRA  | 16:16:16:16

        // RGB ----------------------------------------------------------------------------------------                                                
        [BitsPerPixel(8)]   Rgb4              = 32, // RGB   | 1:2:1                 |
        [BitsPerPixel(8)]   Rgb8              = 33, // RGB   | 3:3:2                 |
        [BitsPerPixel(16)]  Rgb444be          = 34, // RGB   | 4:4:4                 |
        [BitsPerPixel(16)]  Rgb444le          = 35, // RGB   | 4:4:4                 |
        [BitsPerPixel(16)]  Rgb555be          = 36, // RGB   | 5:5:5                 |              | 16BE555                    
        [BitsPerPixel(16)]  Rgb555le          = 37, // RGB   | 5:5:5                 |              | 16LE555
        [BitsPerPixel(16)]  Rgb565be          = 38, // RGB   | 5:6:5                 |              | 16BE565
        [BitsPerPixel(16)]  Rgb565le          = 39, // RGB   | 5:6:5                 |              | 16LE565
        [BitsPerPixel(24)]  Rgb24             = 40, // RGB   | 8:8:8                 | 24bppRGB     | 24RGB
        [BitsPerPixel(32)]  Rrb30             = 41, // RGB   | 10be:10be:10be:xx     |              | 30RGB
        [BitsPerPixel(48)]  Rgb48             = 42, // RGB   | 16:16:16              | 48bppRGB     | 48RGB
        [BitsPerPixel(48)]  Rgb48be           = 43, // RGB   | 16:16:16
        [BitsPerPixel(48)]  Rgb48le           = 44, // RGB   | 16:16:16
        [BitsPerPixel(48)]  Rgb48Half         = 45, // RGB   | 16:16:16              | 48bppRGBHalf |
        [BitsPerPixel(128)] Rgb128Float       = 46, // RGB   | 32:32:32:?
        [BitsPerPixel(128)] Rgb128FixedPoint  = 47, // RGB   | 32:32:32:?
                                                             
        // RGBA                                              
        [BitsPerPixel(32)]  Rgba32            = 51, // RGBA  |                        |           | 32RGBA       
        [BitsPerPixel(64)]  Rgba64            = 52, // RGBA  | 16:16:16:16            | 
        [BitsPerPixel(64)]  Rgba64be          = 53, // RGBA  | 16:16:16:16
        [BitsPerPixel(64)]  Rgba64le          = 54, // RGBA  | 16:16:16:16f
        [BitsPerPixel(128)] Rgba128Float      = 55, // RGBA  |
        [BitsPerPixel(32)]  Rgba1010102       = 56, // RGBA  | 10:10:10:2 
        [BitsPerPixel(32)]  Rgba1010102XR     = 57, // RGBA  | 10:10:10:2

        /*
        // GBR
        Gbrp,     // GBR | 4:4:4
        Gbrp9be,  // GBR | 4:4:4
        Gbrp9le,  // GBR | 4:4:4
        Gbrp10be, // GBR | 4:4:4
        Gbrp10le, // GBR | 4:4:4
        Gbrp12be, // GBR 4:4:4
        Gbrp12le, // GBR 4:4:4
        Gbrp14be, // GBR 4:4:4
        Gbrp14le, // GBR 4:4:4
        // GBRA
        Gbrap12be, // GBR 4:4:4:4
        Gbrap12le, // GBR 4:4:4:4
        Gbrap10be, // GBR 4:4:4:4
        Gbrap10le, // GBR 4:4:4:4        
        */

        // CMYK ---------------------------------------------------------------------------------------           
        [BitsPerPixel(32)] Cmyk32      = 60, // CMYK  |                             | 32bppCMYK   
        [BitsPerPixel(64)] Cmyk64      = 61, // CMYK  |                             | 64bppCMYK
        [BitsPerPixel(40)] Cmyka40     = 62, // CMYKA |                             | 40bppCMYKA
        [BitsPerPixel(80)] Cmyka80     = 63, // CMYKA |                             | 80bppCMYKA

        // Gray
        [BitsPerPixel(1)]  BlackWhite  = 70, //                                     | BlackWhite
        [BitsPerPixel(1)]  WhiteBlack  = 71, // 
        [BitsPerPixel(2)]  Gray2       = 72, // Gray | 2
        [BitsPerPixel(4)]  Gray4       = 73, // Gray | 
        [BitsPerPixel(8)]  Gray8       = 74, // Gray | 8 | byte                     | 8bppGray
        [BitsPerPixel(8)]  Gray8le     = 75, // Gray | 8 | 
        [BitsPerPixel(9)]  Gray9be     = 76, // Gray | 9
        [BitsPerPixel(9)]  Gray9le     = 77, // Gray | 9 
        [BitsPerPixel(16)] Gray10be    = 78, // Gray | 10
        [BitsPerPixel(16)] Gray10le    = 79, // Gray | 10
        [BitsPerPixel(16)] Gray12be    = 80, // Gray | 12
        [BitsPerPixel(16)] Gray12le    = 81, // Gray | 12
        [BitsPerPixel(16)] Gray16      = 82, // Gray | 16BE | Gamma:1.0             | 16bppGray       | 16Gray
        [BitsPerPixel(16)] Gray16be    = 83, // Gray | 16
        [BitsPerPixel(16)] Gray16le    = 84, // Gray | 16
        [BitsPerPixel(16)] Gray16Half  = 85, // Gray | 16   | Half                  | 16bppGrayHalf
        [BitsPerPixel(32)] Gray32Float = 86, // Gray | 16   | Float                 | 32bppGrayFloat
        [BitsPerPixel(16)] GrayAlpha16 = 87, // Gray | 8|8


        // Indexed Formats ------------------------------------------------------
        [BitsPerPixel(1)] Indexed1     = 90, // Indexed |                          | 1bppIndexed | 1Monochrome
        [BitsPerPixel(2)] Indexed2     = 91, // Indexed |                          | 2bppIndexed | 2Indexed
        [BitsPerPixel(4)] Indexed4     = 92, // Indexed |                          | 4bppIndexed | 4Indexed
        [BitsPerPixel(8)] Indexed8     = 93, // Indexed |                          | 8bppIndexed | 8Indexed

        // Pre-multiplied
        [BitsPerPixel(32)]  Pbgra32       = 95, // RGBA |  8:8:8:8              || ?
        [BitsPerPixel(64)]  Prgba64       = 96, // RGBA | 
        [BitsPerPixel(128)] Prgba128Float = 97, // RGBA | 32:32:32:32

        // AYUV -------------------------------------------------------------------
        Ayuv64be = 100, // packed AYUV 4:4:4
        Ayuv64le = 101, // packed AYUV 4:4:4

        // Bayer -------------------------------------------------------------------
        BayerBggr8      = 200, // Bayer
        BayerRggb8      = 201, // Bayer
        BayerGbrg8      = 202, // Bayer
        BayerGrbg8      = 203, // Bayer
        BayerBggr16be   = 204, // Bayer
        BayerBggr16le   = 205, // Bayer
        BayerRggb16be   = 206, // Bayer
        BayerRggb16le   = 207, // Bayer
        BayerGbrg16be   = 208, // Bayer
        BayerGbrg16le   = 209, // Bayer
        BayerGrbg16be   = 210, // Bayer
        BayerGrbg16le   = 211, // Bayer

        // NV -------------------------------------------------------------------
        Nv11            = 300, // YUV  | 4:1:1
        Nv12            = 301, // YUV  | 4:2:0
        Nv16            = 303, // YUV  | 4:2:2
        Nv20be          = 304, // YUV  | 4:2:2
        Nv20le          = 305, // YUV  | 4:2:2
        Nv21            = 306, // YUV  | 4:2:0 (swap U & V)

        [BitsPerPixel(16)] Uyvy422 = 400, // YUV | 4:2:2  
        Uyyvyy411       = 401, // YUV | 4:1:1

        Xyz12be         = 500, // XYZ  | 4:4:4
        Xyz12le         = 501, // XYZ  | 4:4:4

        // YUV -------------------------------------------------------------------
        Yuv410p         = 510, // YUV  | 
        Yuv411p         = 511, // YUV  | 
        Yuv420p         = 520, // YUV  | 4:2:0               |  YCoCg 4:2:0
        Yuv420p9be      = 521, // YUV  | 
        Yuv420p9le      = 522, // YUV  | 
        Yuv420p10be     = 530, // YUV  | 
        Yuv420p10le     = 531, // YUV  | 
        Yuv420p12be     = 532, // YUV  | 4:2:0
        Yuv420p12le     = 533, // YUV  | 4:2:0
        Yuv420p14be     = 534, // YUV  | 4:2:0
        Yuv420p14le     = 535, // YUV  | 4:2:0
        Yuv420p16be     = 536, // YUV  | 
        Yuv420p16le     = 537, // YUV  | 
        Yuv422p         = 540, // YUV  | 4:4:4                | YCoCg 4:2:2
        Yuv422p9be      = 541, // YUV  | 
        Yuv422p9le      = 542, // YUV  | 
        Yuv422p10be     = 543, // YUV  | 
        Yuv422p10le     = 544, // YUV  | 
        Yuv422p12be     = 545, // YUV  | 4:2:2
        Yuv422p12le     = 546, // YUV  | 4:2:2
        Yuv422p14be     = 547, // YUV  | 4:2:2
        Yuv422p14le     = 548, // YUV  | 4:2:2
        Yuv422p16be     = 549, // YUV  | 
        Yuv422p16le     = 550, // YUV  | 
        Yuv440p         = 560, // YUV  | 4:4:0
        Yuv440p10le     = 561, // YUV  | 4:4:0 20bpp
        Yuv440p10be     = 562, // YUV  | 4:4:0 20bpp
        Yuv440p12le     = 563, // YUV  | 4:4:0 24bpp
        Yuv440p12be     = 564, // YUV  | 4:4:0 24bpp
        Yuv444p         = 570, // YUV  | 4:4:4                           | YCoCg 4:4:4 
        Yuv444p9be      = 571, // YUV  | 4:4:4
        Yuv444p9le      = 572, // YUV  | 4:4:4
        Yuv444p10be     = 573, // YUV  | 4:4:4
        Yuv444p10le     = 574, // YUV  | 4:4:4
        Yuv444p12be     = 575, // YUV  | 4:4:4
        Yuv444p12le     = 576, // YUV  | 4:4:4
        Yuv444p14be     = 577, // YUV  | 4:4:4
        Yuv444p14le     = 578, // YUV  | 4:4:4
        Yuv444p16be     = 579, // YUV  | 4:4:4
        Yuv444p16le     = 580, // YUV  | 4:4:4

        // YUVA -------------------------------------------------------------------
        Yuva420p        = 600, // YUVA | 4:2:0
        Yuva420p9be     = 601, // YUVA | 
        Yuva420p9le     = 602, // YUVA | 
        Yuva420p10be    = 603, // YUVA | 
        Yuva420p10le    = 604, // YUVA | 
        Yuva420p16be    = 605, // YUVA | 
        Yuva420p16le    = 606, // YUVA | 
        Yuva422p        = 610, // YUVA | 4:2:2
        Yuva422p9be     = 611, // YUVA | 
        Yuva422p9le     = 612, // YUVA | 
        Yuva422p10be    = 613, // YUVA | 
        Yuva422p10le    = 614, // YUVA | 
        Yuva422p16be    = 615, // YUVA | 
        Yuva422p16le    = 616, // YUVA | 
        Yuva444p        = 620, // YUVA | 4:4:4
        Yuva444p9be     = 621, // YUVA | 
        Yuva444p9le     = 622, // YUVA | 
        Yuva444p10be    = 623, // YUVA | 
        Yuva444p10le    = 624, // YUVA | 
        Yuva444p16be    = 625, // YUVA | 
        Yuva444p16le    = 626, // YUVA | 

        // YUVJ
        Yuvj411p        = 650, // YUVJ | 
        Yuvj420p        = 651, // YUVJ |
        Yuvj422p        = 652, // YUVJ |
        Yuvj440p        = 653, // YUVJ |
        Yuvj444p        = 654, // YUVJ |

        // YUYV
        [BitsPerPixel(16)] Yuyv422 = 660, // YUV | 4:2:2 | Y0 Cb Y1 Cr
        [BitsPerPixel(16)] Yvyu422 = 661, // YUV 4:2:2


        Imc1 = 1000,   // planar YUV 4:2:0 16bpp
        Imc3 = 1001,   // planar YUV 4:2:0 16bpp

        // Four CC Codecs

        [BitsPerPixel(16)] P016 = 1002, // Planar, 4:2:0
        [BitsPerPixel(10)] P010 = 1003, // Planar, 4:2:0fRgba
        [BitsPerPixel(16)] P216 = 1004, // Planar, 4:2:2
        [BitsPerPixel(10)] P210 = 1005, // Planar, 4:2:2
        [BitsPerPixel(16)] Y216 = 1006, // Packed, 4:2:2
        [BitsPerPixel(10)] Y210 = 1007, // Packed, 4:2:2
        [BitsPerPixel(16)] Y416 = 1008, // Packed, 4:4:4
        [BitsPerPixel(10)] Y410 = 1009, // Packed, 4:4:4

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
        VdpauH264,
        VdpauMpeg1,
        VdpauMpeg2,
        VdpauWmv3,
        VdpauVc1,
        Ya16be,
        Ya16le,
        Gbrp16be,
        Gbrp16le,
        Gbrap, // planar GBRA 4:4:4:4
        Gbrap16be, // planar GBRA 4:4:4:4
        Gbrap16le, // planar GBRA 4:4:4:4 64bpp
        Qsv,
        Mmal,       
        Yuvj411p,    // planar YUV 4:1:1
        P010le,
        P010be,
        Nb,
        */
    }
}

// http://ffmpeg.org/doxygen/2.8/pixfmt_8h.html#a9a8e335cf3be472042bc9f0cf80cd4c5a4b8a29937744c722f35fccafb91ebdf0
// https://msdn.microsoft.com/en-us/library/windows/desktop/ee719797(v=vs.85).aspx#cmyk_pixel_formats
// https://developer.apple.com/documentation/corevideo/cvpixelformatdescription/1563591-pixel_format_types
 