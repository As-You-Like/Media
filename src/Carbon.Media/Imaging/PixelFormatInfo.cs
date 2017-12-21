using System.Runtime.Serialization;

namespace Carbon.Media
{
    using static ColorChannel;
    using static ColorModel;
    using static PixelFormat;

    public readonly struct PixelFormatInfo
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
        public readonly int BitsPerPixel;

        [DataMember(Name = "colorModel", Order = 2)]
        public readonly ColorModel ColorModel;

        [DataMember(Name = "channels", Order = 3)]
        public readonly ColorChannel[] Channels;

        [DataMember(Name = "flags", Order = 4)]
        public readonly PixelFormatFlags Flags;

        public bool IsPacked => (Flags & PixelFormatFlags.Packed) != 0;

        public bool IsBigEndian => (Flags & PixelFormatFlags.BigEndian) != 0;

        public bool IsPlanar => (Flags & PixelFormatFlags.Planar) != 0;

        // PackedFormat?

        // Type (float, uint, Fixed)

        public static PixelFormatInfo Get(PixelFormat format)
        {
            switch (format)
            {
                case Bgr101010     : return new PixelFormatInfo(10, RGB, new[] { B(10), G(10), R(10) });
                case Bgr24         : return new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8)  });
                case Bgr32         : return new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8) });
                case Bgr555        : return new PixelFormatInfo( 5, RGB, new[] { B(5),  G(6),  R(7) });
                case Bgr565        : return new PixelFormatInfo( 5, RGB, new[] { B(5),  G(6),  R(7) });
                case Bgra32        : return new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8), A(8) });

                case Cmyk32        : return new PixelFormatInfo( 8, CMYK, new[] { Cyan(8),  Magenta(8),  Yellow(8),  Key(8)  });
                case Cmyk64        : return new PixelFormatInfo(16, CMYK, new[] { Cyan(16), Magenta(16), Yellow(16), Key(16) });
                case Cmyka40       : return new PixelFormatInfo( 8, CMYK, new[] { Cyan(8),  Magenta(8),  Yellow(8),  Key(8),  A(8) });
                case Cmyka80       : return new PixelFormatInfo(16, CMYK, new[] { Cyan(16), Magenta(16), Yellow(16), Key(16), A(16) });

                case BlackWhite    : return new PixelFormatInfo(1,  Monochrome, new[] { Key(1) });
                case Gray2         : return new PixelFormatInfo(2,  Monochrome, new[] { Key(2) });
                case Gray4         : return new PixelFormatInfo(4,  Monochrome, new[] { Key(4) });
                case Gray8         : return new PixelFormatInfo(8,  Monochrome, new[] { Key(8) });
                case Gray16        : return new PixelFormatInfo(16, Monochrome, new[] { Key(16) });
                case Gray32Float   : return new PixelFormatInfo(32, Monochrome, new[] { Key(32) });

                case Pbgra32       : return new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8),  A(8) });
                case Prgba128Float : return new PixelFormatInfo(32, RGB, new[] { B(16), G(16), R(16), A(16) });

                case Rgb24         : return new PixelFormatInfo( 8, RGB, new[] { R(8),  G(8),  B(8) });
                case Rgb48         : return new PixelFormatInfo(16, RGB, new[] { R(16), G(16), B(16) });
                case Rgba128Float  : return new PixelFormatInfo(32, RGB, new[] { R(32), G(32), B(32), A(32) });
                case Rgba64        : return new PixelFormatInfo(16, RGB, new[] { R(16), G(16), B(16), A(16) });


                default: throw new System.Exception("Unsupported pixelFormat:" + format);
            }
        }
    }

    public static class PixelFormatTypeExtensions
    {
        public static PixelFormatInfo GetInfo(this PixelFormat format) => PixelFormatInfo.Get(format);
    }
}