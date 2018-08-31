namespace Carbon.Media
{
    public enum PixelFormat
    {
        Unknown = 0,

        //                                                  | Layout      | Packing  | WIC              | CI      |
        // A -----------------------------------------------|-------------|----------|------------------|-------- |    
        [BitsPerPixel(8)]   A8               = 1,  // A     | i8          | byte     | 8bppAlpha        | A8      |
        [BitsPerPixel(16)]  A16              = 2,  // A     | i16         | int      |                  | A16     |
        [BitsPerPixel(32)]  Af               = 3,  // A     | f32         | float    |                  | Af      |
        [BitsPerPixel(16)]  Ah               = 4,  // A     | f16         | half     |                  | Ah      |
                                                                                                                  
        // ARGB ----------------------------------------------------------|----------|------------------|---------|                                                        |          |                  |
        [BitsPerPixel(32)]  Abgr32           = 5,  // ABGR  | 8:8:8:8     |          | ?                | ABGR8   |
        [BitsPerPixel(32)]  Argb32           = 6,  // ARGB  | 8:8:8:8     |          |                  | ARGB8   |
        [BitsPerPixel(64)]  Argb64           = 7,  // ARGB  | 16:16:16:16 | ulong    |                  |         |
                                                                                                                  
        // BGR(A) --------------------------------------------------------|----------|------------------|-------- |          
        [BitsPerPixel(4)]   Bgr4             = 10, // BGR   | 1:2:1       |          |                  |         |
        [BitsPerPixel(8)]   Bgr8             = 11, // BGR   | 3:3:2       | byte     |                  |         |
        [BitsPerPixel(16)]  Bgr444be         = 12, // BGR   | 4:4:4       |          |                  |         |
        [BitsPerPixel(16)]  Bgr444le         = 13, // BGR   | 4:4:4       |          |                  |         |
        [BitsPerPixel(16)]  Bgr555           = 14, // BGR   | 5:5:5:x     | uint     | 16bppBGR555      |         |
        [BitsPerPixel(16)]  Bgr555be         = 15, // BGR   | 5:5:5:x     |          | 16bppBGR555      |         |
        [BitsPerPixel(16)]  Bgr555le         = 16, // BGR   |             |          |                  |         |
        [BitsPerPixel(16)]  Bgr565           = 17, // BGR   | 5:6:5       | uint     | 16bppBGR565      |         |
        [BitsPerPixel(16)]  Bgr565be         = 18, // BGR   | 5:6:5       |          |                  |         |
        [BitsPerPixel(16)]  Bgr565le         = 19, // BGR   |             |          |                  |         |
        [BitsPerPixel(24)]  Bgr24            = 20, // BGR   | 8:8:8       |          | 24bppBGR         |         |
        [BitsPerPixel(32)]  Bgr101010        = 21, // BGR   | 10:10:10    |          | 32bppBGR101010   |         |
        [BitsPerPixel(32)]  Bgr32            = 22, // BGR   | 8:8:8:xxxx  |          | 32bppBGR         |         |
        [BitsPerPixel(48)]  Bgr48            = 23, // BGR   | 16:16:16    |          |                  |         |
        [BitsPerPixel(48)]  Bgr48be          = 24, // BGR   | 16:16:16    |          |                  |         |
        [BitsPerPixel(48)]  Bgr48le          = 25, // BGR   | 16:16:16    |          |                  |         |
        [BitsPerPixel(16)]  Bgra16           = 26, // BGRA  | 4:4:4:4     |          |                  |         |
        [BitsPerPixel(16)]  Bgra555          = 27, //                     |          |                  |         |
        [BitsPerPixel(32)]  Bgra32           = 28, // BGRA  | 8:8:8:8     |          | 32bppBGRA        | BGR8    |
        [BitsPerPixel(64)]  Bgra64           = 29, // BGRA  |             |          | 64bppRGBA        |         |
        [BitsPerPixel(64)]  Bgra64be         = 30, // BGRA  | 16:16:16:16 |          |                  |         |
        [BitsPerPixel(64)]  Bgra64le         = 31, // BGRA  | 16:16:16:16 |          |                  |         |
                                                                                                                  
        // Pre-multiplied                                                                               |         |
        [BitsPerPixel(32)]  Pbgra32          = 32, // BGRA | 8:8:8:8     |           | 32bppPBGRA       |         |
        [BitsPerPixel(32)]  Pbgra64          = 33, // BGRA | 16:16:16:16 |           | 64bppPBGRA       |         |
                                                                                                                  
        // RGB(A) --------------------------------------------------------|----------|------------------|-------- |                                                
        [BitsPerPixel(8)]   Rgb4             = 34, // RGB   | 1:2:1       |          |                  |         |
        [BitsPerPixel(8)]   Rgb8             = 35, // RGB   | 3:3:2       |          |                  |         |
        [BitsPerPixel(16)]  Rgb444be         = 36, // RGB   | 4:4:4       |          |                  |         |
        [BitsPerPixel(16)]  Rgb444le         = 37, // RGB   | 4:4:4       |          |                  |         |
        [BitsPerPixel(16)]  Rgb555be         = 38, // RGB   | 5:5:5       |          |                  | 16BE555 |              
        [BitsPerPixel(16)]  Rgb555le         = 39, // RGB   | 5:5:5       |          |                  | 16LE555 |
        [BitsPerPixel(16)]  Rgb565be         = 40, // RGB   | 5:6:5       |          |                  | 16BE565 |
        [BitsPerPixel(16)]  Rgb565le         = 41, // RGB   | 5:6:5       |          |                  | 16LE565 |
        [BitsPerPixel(24)]  Rgb24            = 42, // RGB   | 8:8:8                  | 24bppRGB         | 24RGB   |
        [BitsPerPixel(32)]  Rrb30            = 43, // RGB   | 10be:10be:10be:xx      |                  | 30RGB   |
        [BitsPerPixel(32)]  Rgb32            = 44, // RGB   | 8:8:8:x     |          | 32bppRGB                   |
        [BitsPerPixel(48)]  Rgb48            = 45, // RGB   | 16:16:16               | 48bppRGB         | 48RGB   |
        [BitsPerPixel(48)]  Rgb48be          = 46, // RGB   | 16:16:16    |          |                            |
        [BitsPerPixel(48)]  Rgb48le          = 47, // RGB   | 16:16:16    |          |                            |
        [BitsPerPixel(48)]  Rgb48h           = 48, // RGB   | 16:16:16    |          | 48bppRGBHalf     |         |
        [BitsPerPixel(32)]  Rgb64            = 49, // RGB   | 16:16:16:x  |          | 64bppRGB                   |
        [BitsPerPixel(128)] Rgb128f          = 50, // RGB   | 32:32:32:x  |          | 128bppRGBFloat   |         |
        [BitsPerPixel(128)] Rgb128FixedPoint = 51, // RGB   | 32:32:32:x  |          |                            |                                                                                                    |
        [BitsPerPixel(32)]  Rgba32           = 52, // RGBA  | 8:8:8:8     | i8 x 4   | 32bppRGBA        | RGBA8   |
        [BitsPerPixel(64)]  Rgba64           = 53, // RGBA  | 16:16:16:16 | i16 x 4  |                  | RGBA16  |
        [BitsPerPixel(64)]  Rgba64be         = 54, // RGBA  | 16:16:16:16 |          |                  |         |
        [BitsPerPixel(64)]  Rgba64le         = 55, // RGBA  | 16:16:16:16 |          |                  |         |
        [BitsPerPixel(64)]  Rgba64h          = 56, // RGBA  | 16:16:16:16 | f16 x 4  | 64bppRGBAHalf    | RGBAh   |
        [BitsPerPixel(128)] Rgba128f         = 57, // RGBA  | 16:16:16:16 | f32 x 4  | 128bppRGBAFloat  | RGBAf   |
        [BitsPerPixel(32)]  Rgba1010102      = 58, // RGBA  | 10:10:10:2  |          |                  |         |
        [BitsPerPixel(32)]  Rgba1010102XR    = 59, // RGBA  | 10:10:10:2  |          |                  |         |
                                                                                                                  
        // Pre-multiplied                                                                               |         |
        [BitsPerPixel(64)]  Prgba32          = 60, // RGBA  | 8:8:8:8     |          | 32bppPRGBA       |         |
        [BitsPerPixel(64)]  Prgba64          = 61, // RGBA  | 16:16:16:16 |          | 64bppPRGBA       |         |
        [BitsPerPixel(128)] Prgba128f        = 62, // RGBA  | 32:32:32:32 |          | 128bppPRGBAFloat |         |
                                                                                                                  
        // GBR(A) --------------------------------------------------------| ---------|------------------|---------|
        Gbrp                                 = 70, // GBR   | 4:4:4       |                                       |
        Gbrp9be                              = 71, // GBR   | 4:4:4       |                                       |
        Gbrp9le                              = 72, // GBR   | 4:4:4       |                                       |
        Gbrp10be                             = 73, // GBR   | 4:4:4       |                                       |
        Gbrp10le                             = 74, // GBR   | 4:4:4       |                                       |
        Gbrp12be                             = 75, // GBR   | 4:4:4       |                                       |
        Gbrp12le                             = 76, // GBR   | 4:4:4       |                                       |
        Gbrp14be                             = 77, // GBR   | 4:4:4       |                                       |
        Gbrp14le                             = 78, // GBR   | 4:4:4       |                                       |                                                                                                                                     |                  |
        Gbrp16be                             = 79, // GBR   | 4:4:4:4     |                                       |
        Gbrp16le                             = 80, // GBR   | 4:4:4:4     |                                       |
        Gbrap                                = 81, // GBRA  | 4:4:4:4     |                                       |
        Gbrap10be                            = 82, // GBRA  | 4:4:4:4     |                                       |
        Gbrap10le                            = 83, // GBRA  | 4:4:4:4     |                                       |
        Gbrap12be                            = 84, // GBRA  | 4:4:4:4     |                                       |
        Gbrap12le                            = 85, // GBRA  | 4:4:4:4     |                                       |
        [BitsPerPixel(64)]  Gbrap16be        = 86, // GBRA  | 4:4:4:4     |                                       |
        [BitsPerPixel(64)]  Gbrap16le        = 87, // GBRA  | 4:4:4:4     |                                       |
        [BitsPerPixel(128)] Gbrapfbe         = 88, // GBRA  | 4:4:4:4     |                                       |
        [BitsPerPixel(128)] Gbrapfle         = 89, // GBRA  | 4:4:4:4     |                                       |
                                                                                                                  
        // CMYK ----------------------------------------------------------| ---------|------------------|---------|
        [BitsPerPixel(32)] Cmyk32            = 90, // CMYK  |             |          | 32bppCMYK        |         |
        [BitsPerPixel(64)] Cmyk64            = 91, // CMYK  |                        | 64bppCMYK        |         |
        [BitsPerPixel(40)] Cmyka40           = 92, // CMYKA |                        | 40bppCMYKA       |         |
        [BitsPerPixel(80)] Cmyka80           = 93, // CMYKA |                        | 80bppCMYKA       |         |
                                                                                                                  
        // Gray ----------------------------------------------------------| ---------|----------------- |         |
        [BitsPerPixel(1)]  BlackWhite        = 100, //                    |          | BlackWhite       |         |
        [BitsPerPixel(1)]  WhiteBlack        = 101, //                    |          |                  |         |
        [BitsPerPixel(2)]  Gray2             = 102, // Gray | 2           |          | 2bppGray         |         |
        [BitsPerPixel(4)]  Gray4             = 103, // Gray |             |          | 4bppGray         |         |
        [BitsPerPixel(8)]  Gray8             = 104, // Gray | 8           | byte     | 8bppGray         |         |
        [BitsPerPixel(8)]  Gray8le           = 105, // Gray | 8           |          |                  |         |
        [BitsPerPixel(9)]  Gray9be           = 106, // Gray | 9           |          |                  |         |
        [BitsPerPixel(9)]  Gray9le           = 107, // Gray | 9           |          |                  |         |
        [BitsPerPixel(16)] Gray10be          = 108, // Gray | 10          |          |                  |         |
        [BitsPerPixel(16)] Gray10le          = 109, // Gray | 10          |          |                  |         |
        [BitsPerPixel(16)] Gray12be          = 110, // Gray | 12          |          |                  |         |
        [BitsPerPixel(16)] Gray12le          = 111, // Gray | 12          |          |                  |         |
        [BitsPerPixel(16)] Gray16            = 112, // Gray | 16BE        |          | 16bppGray        | 16Gray  |
        [BitsPerPixel(16)] Gray16be          = 113, // Gray | 16          |          |                  |         |
        [BitsPerPixel(16)] Gray16le          = 114, // Gray | 16          |          |                  |         |
        [BitsPerPixel(16)] Gray16h           = 115, // Gray | 16          | f16      | 16bppGrayHalf    |         |
        [BitsPerPixel(32)] Gray32f           = 116, // Gray | 16          | f32      | 32bppGrayFloat   |         |
        [BitsPerPixel(16)] GrayAlpha16       = 117, // Gray | 8|8         |          |                  |         |
                                                                                                                   
        // Indexed Formats ---------------------------------------------------------------------------------------|
        [BitsPerPixel(1)] Indexed1           = 131, // Indexed |                     | 1bppIndexed | 1Monochrome  |
        [BitsPerPixel(2)] Indexed2           = 132, // Indexed |                     | 2bppIndexed | 2Indexed     |
        [BitsPerPixel(4)] Indexed4           = 134, // Indexed |                     | 4bppIndexed | 4Indexed     |
        [BitsPerPixel(8)] Indexed8           = 138, // Indexed |                     | 8bppIndexed | 8Indexed     |

        // AYUV -------------------------------------------------------------------
        Ayuv64be        = 160, // packed AYUV 4:4:4
        Ayuv64le        = 161, // packed AYUV 4:4:4

        // Bayer -------------------------------------------------------------------
        BayerBggr8      = 200, // Bayer |
        BayerRggb8      = 201, // Bayer |
        BayerGbrg8      = 202, // Bayer |
        BayerGrbg8      = 203, // Bayer |
        BayerBggr16be   = 204, // Bayer |
        BayerBggr16le   = 205, // Bayer |
        BayerRggb16be   = 206, // Bayer |
        BayerRggb16le   = 207, // Bayer |
        BayerGbrg16be   = 208, // Bayer |
        BayerGbrg16le   = 209, // Bayer |
        BayerGrbg16be   = 210, // Bayer |
        BayerGrbg16le   = 211, // Bayer |

        // NV -------------------------------------------------------------------
        Nv11            = 300, // YUV   | 4:1:1
        Nv12            = 301, // YUV   | 4:2:0
        Nv16            = 303, // YUV   | 4:2:2
        Nv20be          = 304, // YUV   | 4:2:2
        Nv20le          = 305, // YUV   | 4:2:2
        Nv21            = 306, // YUV   | 4:2:0 (swap U & V)

        [BitsPerPixel(16)] Uyvy422 = 400, // YUV | 4:2:2  
        Uyyvyy411       = 401, // YUV  | 4:1:1

        Xyz12be         = 500, // XYZ   | 4:4:4
        Xyz12le         = 501, // XYZ   | 4:4:4

        // YUV -------------------------------------------------------------------
        Yuv410p         = 510, // YUV   | 
        Yuv411p         = 511, // YUV   | 
        Yuv420p         = 520, // YUV   | 4:2:0               |  YCoCg 4:2:0
        Yuv420p9be      = 521, // YUV   | 
        Yuv420p9le      = 522, // YUV   | 
        Yuv420p10be     = 530, // YUV   | 
        Yuv420p10le     = 531, // YUV   | 
        Yuv420p12be     = 532, // YUV   | 4:2:0
        Yuv420p12le     = 533, // YUV   | 4:2:0
        Yuv420p14be     = 534, // YUV   | 4:2:0
        Yuv420p14le     = 535, // YUV   | 4:2:0
        Yuv420p16be     = 536, // YUV   | 
        Yuv420p16le     = 537, // YUV   | 
        Yuv422p         = 540, // YUV   | 4:4:4                | YCoCg 4:2:2
        Yuv422p9be      = 541, // YUV   | 
        Yuv422p9le      = 542, // YUV   | 
        Yuv422p10be     = 543, // YUV   | 
        Yuv422p10le     = 544, // YUV   | 
        Yuv422p12be     = 545, // YUV   | 4:2:2
        Yuv422p12le     = 546, // YUV   | 4:2:2
        Yuv422p14be     = 547, // YUV   | 4:2:2
        Yuv422p14le     = 548, // YUV   | 4:2:2
        Yuv422p16be     = 549, // YUV   | 
        Yuv422p16le     = 550, // YUV   | 
        Yuv440p         = 560, // YUV   | 4:4:0
        Yuv440p10le     = 561, // YUV   | 4:4:0 20bpp
        Yuv440p10be     = 562, // YUV   | 4:4:0 20bpp
        Yuv440p12le     = 563, // YUV   | 4:4:0 24bpp
        Yuv440p12be     = 564, // YUV   | 4:4:0 24bpp
        Yuv444p         = 570, // YUV   | 4:4:4                           | YCoCg 4:4:4 
        Yuv444p9be      = 571, // YUV   | 4:4:4
        Yuv444p9le      = 572, // YUV   | 4:4:4
        Yuv444p10be     = 573, // YUV   | 4:4:4
        Yuv444p10le     = 574, // YUV   | 4:4:4
        Yuv444p12be     = 575, // YUV   | 4:4:4
        Yuv444p12le     = 576, // YUV   | 4:4:4
        Yuv444p14be     = 577, // YUV   | 4:4:4
        Yuv444p14le     = 578, // YUV   | 4:4:4
        Yuv444p16be     = 579, // YUV   | 4:4:4
        Yuv444p16le     = 580, // YUV   | 4:4:4

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

        Imc1 = 1000,   // YUV 4:2:0 16bpp | planar
        Imc3 = 1001,   // YUV 4:2:0 16bpp | planar

        // Four CC Codecs

        [BitsPerPixel(16)] P016 = 1002, // 4:2:0      | planar
        [BitsPerPixel(10)] P010 = 1003, // 4:2:0fRgba | planar
        [BitsPerPixel(16)] P216 = 1004, // 4:2:2      | planar
        [BitsPerPixel(10)] P210 = 1005, // 4:2:2      | planar
        [BitsPerPixel(16)] Y216 = 1006, // 4:2:2      | packed
        [BitsPerPixel(10)] Y210 = 1007, // 4:2:2      | packed
        [BitsPerPixel(16)] Y416 = 1008, // 4:4:4      | packed
        [BitsPerPixel(10)] Y410 = 1009, // 4:4:4      | packed
                                                      
        /*
        YUV ----------------------
        AI44		| 4:4:4	 | Packed
        AYUV		| 4:4:4	 | Packed
        I420		| 4:2:0	 | Planar
        IYUV		| 4:2:0	 | Planar
        UYVY		| 4:2:2	 | Packed
        Y41P		| 4:1:1	 | Packed
        Y41T		| 4:1:1	 | Packed
        Y42T		| 4:2:2	 | Packed
        YUY2		| 4:2:2	 | Packed
        YVU9		| 8:4:4	 | Planar
        YV12		| 4:2:0	 | Planar
        YVYU		| 4:2:2  | Packed
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
 