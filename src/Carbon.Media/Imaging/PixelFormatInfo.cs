using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    using static ColorChannel;
    using static ColorModel;

    [DataContract]
    public class PixelFormatInfo
    {
        public PixelFormatInfo(
            int bitsPerPixel,
            ColorModel model, 
            ColorChannel[] channels,
            PixelFormatFlags flags = PixelFormatFlags.None)
        {
            BitsPerPixel = bitsPerPixel;
            ColorModel   = model;
            Channels     = channels;
            Flags        = flags;
        }

        [DataMember(Name = "bitsPerPixel", Order = 1)]
        public int BitsPerPixel { get; }

        [DataMember(Name = "colorModel", Order = 2)]
        public ColorModel ColorModel { get; }

        [DataMember(Name = "channels", Order = 3)]
        public ColorChannel[] Channels { get; }

        [DataMember(Name = "flags", Order = 4)]
        public PixelFormatFlags Flags { get; }

        public bool IsPacked => (Flags & PixelFormatFlags.Packed) != 0;

        public bool IsBigEndian => (Flags & PixelFormatFlags.BigEndian) != 0;

        public bool IsPlanar => (Flags & PixelFormatFlags.Planar) != 0;
        
        public bool IsPremultiplied => (Flags & PixelFormatFlags.Premultiplied) != 0;
        
        // PackedFormat?

        // Type (float, uint, Fixed)

        public static readonly PixelFormatInfo Bgr101010     = new PixelFormatInfo(10, RGB, new[] { B(10), G(10), R(10) });
        public static readonly PixelFormatInfo Bgr24         = new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8)  });
        public static readonly PixelFormatInfo Bgr32         = new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8) });
        public static readonly PixelFormatInfo Bgr555        = new PixelFormatInfo( 5, RGB, new[] { B(5),  G(6),  R(7) });
        public static readonly PixelFormatInfo Bgr565        = new PixelFormatInfo( 5, RGB, new[] { B(5),  G(6),  R(7) });
        public static readonly PixelFormatInfo Bgra32        = new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8), A(8) });

        public static readonly PixelFormatInfo Cmyk32        =  new PixelFormatInfo( 8, CMYK, new[] { Cyan(8),  Magenta(8),  Yellow(8),  Key(8)  });
        public static readonly PixelFormatInfo Cmyk64        =  new PixelFormatInfo(16, CMYK, new[] { Cyan(16), Magenta(16), Yellow(16), Key(16) });
        public static readonly PixelFormatInfo Cmyka40       =  new PixelFormatInfo( 8, CMYK, new[] { Cyan(8),  Magenta(8),  Yellow(8),  Key(8),  A(8) });
        public static readonly PixelFormatInfo Cmyka80       =  new PixelFormatInfo(16, CMYK, new[] { Cyan(16), Magenta(16), Yellow(16), Key(16), A(16) });
                                                              
        public static readonly PixelFormatInfo BlackWhite    =  new PixelFormatInfo(1, Monochrome, new[] { Key(1) });
        public static readonly PixelFormatInfo Gray2         =  new PixelFormatInfo(2, Monochrome, new[] { Key(2) });
        public static readonly PixelFormatInfo Gray4         =  new PixelFormatInfo(4, Monochrome, new[] { Key(4) });
        public static readonly PixelFormatInfo Gray8         =  new PixelFormatInfo(8, Monochrome, new[] { Key(8) });
        public static readonly PixelFormatInfo Gray16        =  new PixelFormatInfo(16, Monochrome, new[] { Key(16) });
        public static readonly PixelFormatInfo Gray32Float   =  new PixelFormatInfo(32, Monochrome, new[] { Key(32) });
                                                              
        public static readonly PixelFormatInfo Pbgra32       = new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8),  A(8) }, PixelFormatFlags.Premultiplied);
        public static readonly PixelFormatInfo Prgba128Float = new PixelFormatInfo(32, RGB, new[] { B(16), G(16), R(16), A(16) }, PixelFormatFlags.Premultiplied);
                                                              
        public static readonly PixelFormatInfo Rgb24         =  new PixelFormatInfo( 8, RGB, new[] { R(8),  G(8),  B(8) });
        public static readonly PixelFormatInfo Rgb48         =  new PixelFormatInfo(16, RGB, new[] { R(16), G(16), B(16) });
        public static readonly PixelFormatInfo Rgba128Float  =  new PixelFormatInfo(32, RGB, new[] { R(32), G(32), B(32), A(32) });
        public static readonly PixelFormatInfo Rgba64        =  new PixelFormatInfo(16, RGB, new[] { R(16), G(16), B(16), A(16) });

        public static PixelFormatInfo Get(PixelFormat format)
        {
            switch (format)
            {
                case PixelFormat.Bgr101010     : return Bgr101010;
                case PixelFormat.Bgr24         : return Bgr24;
                case PixelFormat.Bgr32         : return Bgr32;   
                case PixelFormat.Bgr555        : return Bgr555;   
                case PixelFormat.Bgr565        : return Bgr565;  
                case PixelFormat.Bgra32        : return Bgra32;

                case PixelFormat.Cmyk32        : return Cmyk32;
                case PixelFormat.Cmyk64        : return Cmyk64; 
                case PixelFormat.Cmyka40       : return Cmyka40;
                case PixelFormat.Cmyka80       : return Cmyka80;

                case PixelFormat.BlackWhite    : return BlackWhite;
                case PixelFormat.Gray2         : return Gray2;
                case PixelFormat.Gray4         : return Gray4;
                case PixelFormat.Gray8         : return Gray8;
                case PixelFormat.Gray16        : return Gray16;
                case PixelFormat.Gray32Float   : return Gray32Float;

                case PixelFormat.Pbgra32       : return Pbgra32;
                case PixelFormat.Prgba128Float : return Prgba128Float;

                case PixelFormat.Rgb24         : return Rgb24;
                case PixelFormat.Rgb48         : return Rgb48;
                case PixelFormat.Rgba128Float  : return Rgba128Float;
                case PixelFormat.Rgba64        : return Rgba64;
            }

            throw new Exception("Invalid PixelFormat:" + format);
        }
    }

    public static class PixelFormatTypeExtensions
    {
        public static PixelFormatInfo GetInfo(this PixelFormat format) => PixelFormatInfo.Get(format);
    }
}