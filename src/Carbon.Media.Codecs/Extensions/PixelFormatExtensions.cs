using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public static class PixelFormatExtensions
    {
        public static PixelFormat ToFormat(this AVPixelFormat format)
        {
            switch (format)
            {
                // Ayuv
                case AVPixelFormat.AV_PIX_FMT_AYUV64BE       : return PixelFormat.Ayuv64be;
                case AVPixelFormat.AV_PIX_FMT_AYUV64LE       : return PixelFormat.Ayuv64le;
                                                             
                // ARGB & Abgr32                             
                case AVPixelFormat.AV_PIX_FMT_ARGB           : return PixelFormat.Argb32;
                case AVPixelFormat.AV_PIX_FMT_ABGR           : return PixelFormat.Abgr32;
                                                             
                // RGB                                       
                case AVPixelFormat.AV_PIX_FMT_RGB4           : return PixelFormat.Rgb4;     
                case AVPixelFormat.AV_PIX_FMT_RGB8           : return PixelFormat.Rgb8;     
                case AVPixelFormat.AV_PIX_FMT_RGB444BE       : return PixelFormat.Rgb444be; 
                case AVPixelFormat.AV_PIX_FMT_RGB444LE       : return PixelFormat.Rgb444le; 
                case AVPixelFormat.AV_PIX_FMT_RGB555BE       : return PixelFormat.Rgb555be; 
                case AVPixelFormat.AV_PIX_FMT_RGB555LE       : return PixelFormat.Rgb555le; 
                case AVPixelFormat.AV_PIX_FMT_RGB565BE       : return PixelFormat.Rgb565be; 
                case AVPixelFormat.AV_PIX_FMT_RGB565LE       : return PixelFormat.Rgb565le; 
                case AVPixelFormat.AV_PIX_FMT_RGB24          : return PixelFormat.Rgb24;   
                case AVPixelFormat.AV_PIX_FMT_RGBA           : return PixelFormat.Rgba32;   
                case AVPixelFormat.AV_PIX_FMT_RGB48BE        : return PixelFormat.Rgb48be;  
                case AVPixelFormat.AV_PIX_FMT_RGB48LE        : return PixelFormat.Rgb48le;   
                                                             
                // BGR                                       
                case AVPixelFormat.AV_PIX_FMT_BGR4           : return PixelFormat.Bgr4;
                case AVPixelFormat.AV_PIX_FMT_BGR8           : return PixelFormat.Bgr8; 
                case AVPixelFormat.AV_PIX_FMT_BGR24          : return PixelFormat.Bgr24;
                case AVPixelFormat.AV_PIX_FMT_BGRA           : return PixelFormat.Bgra32;
                case AVPixelFormat.AV_PIX_FMT_BGR555BE       : return PixelFormat.Bgr555be;
                case AVPixelFormat.AV_PIX_FMT_BGR555LE       : return PixelFormat.Bgr555le;
                case AVPixelFormat.AV_PIX_FMT_BGR565BE       : return PixelFormat.Bgr565be;
                case AVPixelFormat.AV_PIX_FMT_BGR565LE       : return PixelFormat.Bgr565le;
                case AVPixelFormat.AV_PIX_FMT_BGR48BE        : return PixelFormat.Bgr48be;
                case AVPixelFormat.AV_PIX_FMT_BGR48LE        : return PixelFormat.Bgr48le;
                                                             
                                                             
                // Gray                                      
                case AVPixelFormat.AV_PIX_FMT_GRAY8          : return PixelFormat.Gray8;
                case AVPixelFormat.AV_PIX_FMT_GRAY9BE        : return PixelFormat.Gray9be;
                case AVPixelFormat.AV_PIX_FMT_GRAY9LE        : return PixelFormat.Gray9le;
                case AVPixelFormat.AV_PIX_FMT_GRAY10BE       : return PixelFormat.Gray10be;
                case AVPixelFormat.AV_PIX_FMT_GRAY10LE       : return PixelFormat.Gray10le;
                case AVPixelFormat.AV_PIX_FMT_GRAY12BE       : return PixelFormat.Gray12be;
                case AVPixelFormat.AV_PIX_FMT_GRAY12LE       : return PixelFormat.Gray12le;
                case AVPixelFormat.AV_PIX_FMT_GRAY16BE       : return PixelFormat.Gray16be;
                case AVPixelFormat.AV_PIX_FMT_GRAY16LE       : return PixelFormat.Gray16le;
                case AVPixelFormat.AV_PIX_FMT_MONOBLACK      : return PixelFormat.BlackWhite;
                case AVPixelFormat.AV_PIX_FMT_MONOWHITE      : return PixelFormat.WhiteBlack;
                    
                // Bayer
                case AVPixelFormat.AV_PIX_FMT_BAYER_BGGR8    : return PixelFormat.BayerBggr8;
                case AVPixelFormat.AV_PIX_FMT_BAYER_RGGB8    : return PixelFormat.BayerRggb8;
                case AVPixelFormat.AV_PIX_FMT_BAYER_GBRG8    : return PixelFormat.BayerGbrg8; 
                case AVPixelFormat.AV_PIX_FMT_BAYER_GRBG8    : return PixelFormat.BayerGrbg8;
                case AVPixelFormat.AV_PIX_FMT_BAYER_BGGR16LE : return PixelFormat.BayerBggr16le;
                case AVPixelFormat.AV_PIX_FMT_BAYER_BGGR16BE : return PixelFormat.BayerBggr16be;
                case AVPixelFormat.AV_PIX_FMT_BAYER_RGGB16LE : return PixelFormat.BayerRggb16le;
                case AVPixelFormat.AV_PIX_FMT_BAYER_RGGB16BE : return PixelFormat.BayerRggb16be;
                case AVPixelFormat.AV_PIX_FMT_BAYER_GBRG16LE : return PixelFormat.BayerGbrg16le;
                case AVPixelFormat.AV_PIX_FMT_BAYER_GBRG16BE : return PixelFormat.BayerGbrg16be;
                case AVPixelFormat.AV_PIX_FMT_BAYER_GRBG16LE : return PixelFormat.BayerGrbg16le;
                case AVPixelFormat.AV_PIX_FMT_BAYER_GRBG16BE : return PixelFormat.BayerGrbg16be;

                case AVPixelFormat.AV_PIX_FMT_NV12           : return PixelFormat.Nv12;      
                case AVPixelFormat.AV_PIX_FMT_NV16           : return PixelFormat.Nv16;       
                case AVPixelFormat.AV_PIX_FMT_NV20BE         : return PixelFormat.Nv20be;      
                case AVPixelFormat.AV_PIX_FMT_NV20LE         : return PixelFormat.Nv20le;     
                case AVPixelFormat.AV_PIX_FMT_NV21           : return PixelFormat.Nv21;     
                   
                // YUV                        
                case AVPixelFormat.AV_PIX_FMT_YUV410P        : return PixelFormat.Yuv410p;  
                case AVPixelFormat.AV_PIX_FMT_YUV411P        : return PixelFormat.Yuv411p;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P        : return PixelFormat.Yuv420p;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P9BE     : return PixelFormat.Yuv420p9be;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P9LE     : return PixelFormat.Yuv420p9le;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P10BE    : return PixelFormat.Yuv420p10be;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P10LE    : return PixelFormat.Yuv420p10le;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P12BE    : return PixelFormat.Yuv420p12be;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P12LE    : return PixelFormat.Yuv420p12le;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P14BE    : return PixelFormat.Yuv420p14be;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P14LE    : return PixelFormat.Yuv420p14le;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P16BE    : return PixelFormat.Yuv420p16be;  
                case AVPixelFormat.AV_PIX_FMT_YUV420P16LE    : return PixelFormat.Yuv420p16le;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P        : return PixelFormat.Yuv422p;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P9BE     : return PixelFormat.Yuv422p9be;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P9LE     : return PixelFormat.Yuv422p9le;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P10BE    : return PixelFormat.Yuv422p10be;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P10LE    : return PixelFormat.Yuv422p10le;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P12BE    : return PixelFormat.Yuv422p12be;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P12LE    : return PixelFormat.Yuv422p12le;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P14BE    : return PixelFormat.Yuv422p14be;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P14LE    : return PixelFormat.Yuv422p14le;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P16BE    : return PixelFormat.Yuv422p16be;  
                case AVPixelFormat.AV_PIX_FMT_YUV422P16LE    : return PixelFormat.Yuv422p16le;  
                case AVPixelFormat.AV_PIX_FMT_YUV440P        : return PixelFormat.Yuv440p;  
                case AVPixelFormat.AV_PIX_FMT_YUV440P10LE    : return PixelFormat.Yuv440p10le;  
                case AVPixelFormat.AV_PIX_FMT_YUV440P10BE    : return PixelFormat.Yuv440p10be;  
                case AVPixelFormat.AV_PIX_FMT_YUV440P12LE    : return PixelFormat.Yuv440p12le;  
                case AVPixelFormat.AV_PIX_FMT_YUV440P12BE    : return PixelFormat.Yuv440p12be;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P        : return PixelFormat.Yuv444p;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P9BE     : return PixelFormat.Yuv444p9be;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P9LE     : return PixelFormat.Yuv444p9le;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P10BE    : return PixelFormat.Yuv444p10be;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P10LE    : return PixelFormat.Yuv444p10le;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P12BE    : return PixelFormat.Yuv444p12be;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P12LE    : return PixelFormat.Yuv444p12le;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P14BE    : return PixelFormat.Yuv444p14be;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P14LE    : return PixelFormat.Yuv444p14le;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P16BE    : return PixelFormat.Yuv444p16be;  
                case AVPixelFormat.AV_PIX_FMT_YUV444P16LE    : return PixelFormat.Yuv444p16le;  

                // YUVA
                case AVPixelFormat.AV_PIX_FMT_YUVA420P       : return PixelFormat.Yuva420p; 
                case AVPixelFormat.AV_PIX_FMT_YUVA420P9BE    : return PixelFormat.Yuva420p9be ; 
                case AVPixelFormat.AV_PIX_FMT_YUVA420P9LE    : return PixelFormat.Yuva420p9le ; 
                case AVPixelFormat.AV_PIX_FMT_YUVA420P10BE   : return PixelFormat.Yuva420p10be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA420P10LE   : return PixelFormat.Yuva420p10le; 
                case AVPixelFormat.AV_PIX_FMT_YUVA420P16BE   : return PixelFormat.Yuva420p16be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA420P16LE   : return PixelFormat.Yuva420p16le; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P       : return PixelFormat.Yuva422p; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P9BE    : return PixelFormat.Yuva422p9be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P9LE    : return PixelFormat.Yuva422p9le; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P10BE   : return PixelFormat.Yuva422p10be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P10LE   : return PixelFormat.Yuva422p10le; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P16BE   : return PixelFormat.Yuva422p16be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA422P16LE   : return PixelFormat.Yuva422p16le; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P       : return PixelFormat.Yuva444p; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P9BE    : return PixelFormat.Yuva444p9be ; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P9LE    : return PixelFormat.Yuva444p9le ; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P10BE   : return PixelFormat.Yuva444p10be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P10LE   : return PixelFormat.Yuva444p10le; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P16BE   : return PixelFormat.Yuva444p16be; 
                case AVPixelFormat.AV_PIX_FMT_YUVA444P16LE   : return PixelFormat.Yuva444p16le;

                // YUVJ
                case AVPixelFormat.AV_PIX_FMT_YUVJ411P       : return PixelFormat.Yuvj411p;
                case AVPixelFormat.AV_PIX_FMT_YUVJ420P       : return PixelFormat.Yuvj420p;
                case AVPixelFormat.AV_PIX_FMT_YUVJ422P       : return PixelFormat.Yuvj422p;
                case AVPixelFormat.AV_PIX_FMT_YUVJ440P       : return PixelFormat.Yuvj440p;
                case AVPixelFormat.AV_PIX_FMT_YUVJ444P       : return PixelFormat.Yuvj444p;

                // YUYV
                case AVPixelFormat.AV_PIX_FMT_YUYV422        : return PixelFormat.Yuyv422;     

                default: throw new System.Exception("Unsupported pixel format:" + format);
            }
        }
        public static AVPixelFormat ToAVFormat(this PixelFormat format)
        {
            switch (format)
            {
                // Ayuv
                case PixelFormat.Ayuv64be      : return AVPixelFormat.AV_PIX_FMT_AYUV64BE;
                case PixelFormat.Ayuv64le      : return AVPixelFormat.AV_PIX_FMT_AYUV64LE;

                // ARGB & Abgr32               
                case PixelFormat.Argb32        : return AVPixelFormat.AV_PIX_FMT_ARGB;
                case PixelFormat.Abgr32        : return AVPixelFormat.AV_PIX_FMT_ABGR;
                                               
                // RGB                         
                case PixelFormat.Rgb4          : return AVPixelFormat.AV_PIX_FMT_RGB4;
                case PixelFormat.Rgb8          : return AVPixelFormat.AV_PIX_FMT_RGB8;
                case PixelFormat.Rgb444be      : return AVPixelFormat.AV_PIX_FMT_RGB444BE;
                case PixelFormat.Rgb444le      : return AVPixelFormat.AV_PIX_FMT_RGB444LE;
                case PixelFormat.Rgb555be      : return AVPixelFormat.AV_PIX_FMT_RGB555BE;
                case PixelFormat.Rgb555le      : return AVPixelFormat.AV_PIX_FMT_RGB555LE;
                case PixelFormat.Rgb565be      : return AVPixelFormat.AV_PIX_FMT_RGB565BE;
                case PixelFormat.Rgb565le      : return AVPixelFormat.AV_PIX_FMT_RGB565LE;
                case PixelFormat.Rgb24         : return AVPixelFormat.AV_PIX_FMT_RGB24;
                case PixelFormat.Rgba32        : return AVPixelFormat.AV_PIX_FMT_RGBA;
                case PixelFormat.Rgb48be       : return AVPixelFormat.AV_PIX_FMT_RGB48BE;
                case PixelFormat.Rgb48le       : return AVPixelFormat.AV_PIX_FMT_RGB48LE;

                // BGR                         
                case PixelFormat.Bgr4          : return AVPixelFormat.AV_PIX_FMT_BGR4;
                case PixelFormat.Bgr8          : return AVPixelFormat.AV_PIX_FMT_BGR8;
                case PixelFormat.Bgr24         : return AVPixelFormat.AV_PIX_FMT_BGR24;
                case PixelFormat.Bgra32        : return AVPixelFormat.AV_PIX_FMT_BGRA;
                case PixelFormat.Bgr555be      : return AVPixelFormat.AV_PIX_FMT_BGR555BE;
                case PixelFormat.Bgr555le      : return AVPixelFormat.AV_PIX_FMT_BGR555LE;
                case PixelFormat.Bgr565be      : return AVPixelFormat.AV_PIX_FMT_BGR565BE;
                case PixelFormat.Bgr565le      : return AVPixelFormat.AV_PIX_FMT_BGR565LE;
                case PixelFormat.Bgr48be       : return AVPixelFormat.AV_PIX_FMT_BGR48BE;
                case PixelFormat.Bgr48le       : return AVPixelFormat.AV_PIX_FMT_BGR48LE;


                // Gray
                case PixelFormat.Gray8         : return AVPixelFormat.AV_PIX_FMT_GRAY8;
                case PixelFormat.Gray9be       : return AVPixelFormat.AV_PIX_FMT_GRAY9BE;
                case PixelFormat.Gray9le       : return AVPixelFormat.AV_PIX_FMT_GRAY9LE;
                case PixelFormat.Gray10be      : return AVPixelFormat.AV_PIX_FMT_GRAY10BE;
                case PixelFormat.Gray10le      : return AVPixelFormat.AV_PIX_FMT_GRAY10LE;
                case PixelFormat.Gray12be      : return AVPixelFormat.AV_PIX_FMT_GRAY12BE;
                case PixelFormat.Gray12le      : return AVPixelFormat.AV_PIX_FMT_GRAY12LE;
                case PixelFormat.Gray16be      : return AVPixelFormat.AV_PIX_FMT_GRAY16BE;
                case PixelFormat.Gray16le      : return AVPixelFormat.AV_PIX_FMT_GRAY16LE;
                case PixelFormat.BlackWhite    : return AVPixelFormat.AV_PIX_FMT_MONOBLACK;
                case PixelFormat.WhiteBlack    : return AVPixelFormat.AV_PIX_FMT_MONOWHITE;
                    
                // Bayer
                case PixelFormat.BayerBggr8    : return AVPixelFormat.AV_PIX_FMT_BAYER_BGGR8;   
                case PixelFormat.BayerRggb8    : return AVPixelFormat.AV_PIX_FMT_BAYER_RGGB8;  
                case PixelFormat.BayerGbrg8    : return AVPixelFormat.AV_PIX_FMT_BAYER_GBRG8;
                case PixelFormat.BayerGrbg8    : return AVPixelFormat.AV_PIX_FMT_BAYER_GRBG8;   
                case PixelFormat.BayerBggr16le : return AVPixelFormat.AV_PIX_FMT_BAYER_BGGR16LE;
                case PixelFormat.BayerBggr16be : return AVPixelFormat.AV_PIX_FMT_BAYER_BGGR16BE;
                case PixelFormat.BayerRggb16le : return AVPixelFormat.AV_PIX_FMT_BAYER_RGGB16LE;
                case PixelFormat.BayerRggb16be : return AVPixelFormat.AV_PIX_FMT_BAYER_RGGB16BE;
                case PixelFormat.BayerGbrg16le : return AVPixelFormat.AV_PIX_FMT_BAYER_GBRG16LE;
                case PixelFormat.BayerGbrg16be : return AVPixelFormat.AV_PIX_FMT_BAYER_GBRG16BE;
                case PixelFormat.BayerGrbg16le : return AVPixelFormat.AV_PIX_FMT_BAYER_GRBG16LE;
                case PixelFormat.BayerGrbg16be : return AVPixelFormat.AV_PIX_FMT_BAYER_GRBG16BE;

                // NV
                case PixelFormat.Nv11          : throw new Exception("ffmpeg does not implement NV11");
                case PixelFormat.Nv12          : return AVPixelFormat.AV_PIX_FMT_NV12;
                case PixelFormat.Nv16          : return AVPixelFormat.AV_PIX_FMT_NV16;
                case PixelFormat.Nv20be        : return AVPixelFormat.AV_PIX_FMT_NV20BE;
                case PixelFormat.Nv20le        : return AVPixelFormat.AV_PIX_FMT_NV20LE;
                case PixelFormat.Nv21          : return AVPixelFormat.AV_PIX_FMT_NV21;
                                               
                                               
                // YUV                         
                case PixelFormat.Yuv410p       : return AVPixelFormat.AV_PIX_FMT_YUV410P;
                case PixelFormat.Yuv411p       : return AVPixelFormat.AV_PIX_FMT_YUV411P;
                case PixelFormat.Yuv420p       : return AVPixelFormat.AV_PIX_FMT_YUV420P;
                case PixelFormat.Yuv420p9be    : return AVPixelFormat.AV_PIX_FMT_YUV420P9BE;
                case PixelFormat.Yuv420p9le    : return AVPixelFormat.AV_PIX_FMT_YUV420P9LE;
                case PixelFormat.Yuv420p10be   : return AVPixelFormat.AV_PIX_FMT_YUV420P10BE;
                case PixelFormat.Yuv420p10le   : return AVPixelFormat.AV_PIX_FMT_YUV420P10LE;
                case PixelFormat.Yuv420p12be   : return AVPixelFormat.AV_PIX_FMT_YUV420P12BE;
                case PixelFormat.Yuv420p12le   : return AVPixelFormat.AV_PIX_FMT_YUV420P12LE;
                case PixelFormat.Yuv420p14be   : return AVPixelFormat.AV_PIX_FMT_YUV420P14BE;
                case PixelFormat.Yuv420p14le   : return AVPixelFormat.AV_PIX_FMT_YUV420P14LE;
                case PixelFormat.Yuv420p16be   : return AVPixelFormat.AV_PIX_FMT_YUV420P16BE;
                case PixelFormat.Yuv420p16le   : return AVPixelFormat.AV_PIX_FMT_YUV420P16LE;
                case PixelFormat.Yuv422p       : return AVPixelFormat.AV_PIX_FMT_YUV422P;
                case PixelFormat.Yuv422p9be    : return AVPixelFormat.AV_PIX_FMT_YUV422P9BE;
                case PixelFormat.Yuv422p9le    : return AVPixelFormat.AV_PIX_FMT_YUV422P9LE;
                case PixelFormat.Yuv422p10be   : return AVPixelFormat.AV_PIX_FMT_YUV422P10BE;
                case PixelFormat.Yuv422p10le   : return AVPixelFormat.AV_PIX_FMT_YUV422P10LE;
                case PixelFormat.Yuv422p12be   : return AVPixelFormat.AV_PIX_FMT_YUV422P12BE;
                case PixelFormat.Yuv422p12le   : return AVPixelFormat.AV_PIX_FMT_YUV422P12LE;
                case PixelFormat.Yuv422p14be   : return AVPixelFormat.AV_PIX_FMT_YUV422P14BE;
                case PixelFormat.Yuv422p14le   : return AVPixelFormat.AV_PIX_FMT_YUV422P14LE;
                case PixelFormat.Yuv422p16be   : return AVPixelFormat.AV_PIX_FMT_YUV422P16BE;
                case PixelFormat.Yuv422p16le   : return AVPixelFormat.AV_PIX_FMT_YUV422P16LE;
                case PixelFormat.Yuv440p       : return AVPixelFormat.AV_PIX_FMT_YUV440P;
                case PixelFormat.Yuv440p10le   : return AVPixelFormat.AV_PIX_FMT_YUV440P10LE;
                case PixelFormat.Yuv440p10be   : return AVPixelFormat.AV_PIX_FMT_YUV440P10BE;
                case PixelFormat.Yuv440p12le   : return AVPixelFormat.AV_PIX_FMT_YUV440P12LE;
                case PixelFormat.Yuv440p12be   : return AVPixelFormat.AV_PIX_FMT_YUV440P12BE;
                case PixelFormat.Yuv444p       : return AVPixelFormat.AV_PIX_FMT_YUV444P;
                case PixelFormat.Yuv444p9be    : return AVPixelFormat.AV_PIX_FMT_YUV444P9BE;
                case PixelFormat.Yuv444p9le    : return AVPixelFormat.AV_PIX_FMT_YUV444P9LE;
                case PixelFormat.Yuv444p10be   : return AVPixelFormat.AV_PIX_FMT_YUV444P10BE;
                case PixelFormat.Yuv444p10le   : return AVPixelFormat.AV_PIX_FMT_YUV444P10LE;
                case PixelFormat.Yuv444p12be   : return AVPixelFormat.AV_PIX_FMT_YUV444P12BE;
                case PixelFormat.Yuv444p12le   : return AVPixelFormat.AV_PIX_FMT_YUV444P12LE;
                case PixelFormat.Yuv444p14be   : return AVPixelFormat.AV_PIX_FMT_YUV444P14BE;
                case PixelFormat.Yuv444p14le   : return AVPixelFormat.AV_PIX_FMT_YUV444P14LE;
                case PixelFormat.Yuv444p16be   : return AVPixelFormat.AV_PIX_FMT_YUV444P16BE;
                case PixelFormat.Yuv444p16le   : return AVPixelFormat.AV_PIX_FMT_YUV444P16LE;

                // YUVA
                case PixelFormat.Yuva420p      : return AVPixelFormat.AV_PIX_FMT_YUVA420P;
                case PixelFormat.Yuva420p9be   : return AVPixelFormat.AV_PIX_FMT_YUVA420P9BE;
                case PixelFormat.Yuva420p9le   : return AVPixelFormat.AV_PIX_FMT_YUVA420P9LE;
                case PixelFormat.Yuva420p10be  : return AVPixelFormat.AV_PIX_FMT_YUVA420P10BE;
                case PixelFormat.Yuva420p10le  : return AVPixelFormat.AV_PIX_FMT_YUVA420P10LE;
                case PixelFormat.Yuva420p16be  : return AVPixelFormat.AV_PIX_FMT_YUVA420P16BE;
                case PixelFormat.Yuva420p16le  : return AVPixelFormat.AV_PIX_FMT_YUVA420P16LE;
                case PixelFormat.Yuva422p      : return AVPixelFormat.AV_PIX_FMT_YUVA422P;
                case PixelFormat.Yuva422p9be   : return AVPixelFormat.AV_PIX_FMT_YUVA422P9BE;
                case PixelFormat.Yuva422p9le   : return AVPixelFormat.AV_PIX_FMT_YUVA422P9LE;
                case PixelFormat.Yuva422p10be  : return AVPixelFormat.AV_PIX_FMT_YUVA422P10BE;
                case PixelFormat.Yuva422p10le  : return AVPixelFormat.AV_PIX_FMT_YUVA422P10LE;
                case PixelFormat.Yuva422p16be  : return AVPixelFormat.AV_PIX_FMT_YUVA422P16BE;
                case PixelFormat.Yuva422p16le  : return AVPixelFormat.AV_PIX_FMT_YUVA422P16LE;
                case PixelFormat.Yuva444p      : return AVPixelFormat.AV_PIX_FMT_YUVA444P;
                case PixelFormat.Yuva444p9be   : return AVPixelFormat.AV_PIX_FMT_YUVA444P9BE;
                case PixelFormat.Yuva444p9le   : return AVPixelFormat.AV_PIX_FMT_YUVA444P9LE;
                case PixelFormat.Yuva444p10be  : return AVPixelFormat.AV_PIX_FMT_YUVA444P10BE;
                case PixelFormat.Yuva444p10le  : return AVPixelFormat.AV_PIX_FMT_YUVA444P10LE;
                case PixelFormat.Yuva444p16be  : return AVPixelFormat.AV_PIX_FMT_YUVA444P16BE;
                case PixelFormat.Yuva444p16le  : return AVPixelFormat.AV_PIX_FMT_YUVA444P16LE;
                    
                // YUVJ
                case PixelFormat.Yuvj411p       : return AVPixelFormat.AV_PIX_FMT_YUVJ411P;
                case PixelFormat.Yuvj420p       : return AVPixelFormat.AV_PIX_FMT_YUVJ420P;
                case PixelFormat.Yuvj422p       : return AVPixelFormat.AV_PIX_FMT_YUVJ422P;
                case PixelFormat.Yuvj440p       : return AVPixelFormat.AV_PIX_FMT_YUVJ440P;
                case PixelFormat.Yuvj444p       : return AVPixelFormat.AV_PIX_FMT_YUVJ444P;

                // YUYV                        
                case PixelFormat.Yuyv422       : return AVPixelFormat.AV_PIX_FMT_YUYV422;

                default: throw new Exception("Unsupported pixel format:" + format);
            }
        }
    }
}
