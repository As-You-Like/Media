namespace Carbon.Media
{
    using static PixelFormat;
    using static ColorModel;
    using static ColorChannel;

    // ColorChannelInfo
    // Bits

    public struct PixelFormatInfo
    {
        public PixelFormatInfo(int bitsPerPixel, ColorModel model, ColorChannel[] channels)
        {
            BitsPerPixel = bitsPerPixel;
            ColorModel = model;
            Channels = channels;
        }

        public int BitsPerPixel { get; }

        public ColorModel ColorModel { get; }

        public ColorChannel[] Channels { get; }


        // Type (float, uint, Fixed)

        // IsPacked?

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

                case BlackWhite    : return new PixelFormatInfo( 1, Grayscale, new[] { K(1) });

                case Cmyk32        : return new PixelFormatInfo( 8, CMYK, new[] { C(8),  M(8),  Y(8),  K(8)  });
                case Cmyk64        : return new PixelFormatInfo(16, CMYK, new[] { C(16), M(16), Y(16), K(16) });
                case CmykAlpha40   : return new PixelFormatInfo( 8, CMYK, new[] { C(8),  M(8),  Y(8),  K(8),  A(8) });
                case CmykAlpha80   : return new PixelFormatInfo(16, CMYK, new[] { C(16), M(16), Y(16), K(16), A(16) });

                case Gray2         : return new PixelFormatInfo(2,  Grayscale, new[] { K(2) });
                case Gray4         : return new PixelFormatInfo(4,  Grayscale, new[] { K(4) });
                case Gray8         : return new PixelFormatInfo(8,  Grayscale, new[] { K(8) });
                case Gray16        : return new PixelFormatInfo(16, Grayscale, new[] { K(16) });
                case Gray32Float   : return new PixelFormatInfo(32, Grayscale, new[] { K(32) });

                case Pbgra32       : return new PixelFormatInfo( 8, RGB, new[] { B(8),  G(8),  R(8),  A(8) });
                case Prgba128Float : return new PixelFormatInfo(32, RGB, new[] { B(16), G(16), R(16), A(16) });

                case Rgb24         : return new PixelFormatInfo( 8, RGB, new[] { R(8),  G(8),  B(8) });
                case Rgb48         : return new PixelFormatInfo(16, RGB, new[] { R(16), G(16), B(16) });
                case Rgba128Float  : return new PixelFormatInfo(32, RGB, new[] { R(32), G(32), B(32), A(32) });
                case Rgba64        : return new PixelFormatInfo(16, RGB, new[] { R(16), G(16), B(16), A(16) });


                default: return default;
            }
        }
    }

    public static class PixelFormatTypeExtensions
    {
        public static PixelFormatInfo GetInfo(this PixelFormat format) => PixelFormatInfo.Get(format);
    }
}