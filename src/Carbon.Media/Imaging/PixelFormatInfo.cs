namespace Carbon.Media
{
    using static PixelFormat;
    using static ColorModel;


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
                case Bgr101010     : return new PixelFormatInfo(10, RGB, ColorChannels.BGR);
                case Bgr24         : return new PixelFormatInfo( 8, RGB, ColorChannels.BGR);
                case Bgr32         : return new PixelFormatInfo( 8, RGB, ColorChannels.BGR);
                case Bgr555        : return new PixelFormatInfo( 5, RGB, ColorChannels.BGR);
                case Bgr565        : return new PixelFormatInfo( 5, RGB, ColorChannels.BGR);
                case Bgra32        : return new PixelFormatInfo( 8, RGB, ColorChannels.BGRA);

                case BlackWhite    : return new PixelFormatInfo( 1, Grayscale, ColorChannels.K);

                case Cmyk32        : return new PixelFormatInfo( 8, CMYK, ColorChannels.CMYK);
                case Cmyk64        : return new PixelFormatInfo(16, CMYK, ColorChannels.CMYK);
                case CmykAlpha40   : return new PixelFormatInfo( 8, CMYK, ColorChannels.CMYKA);
                case CmykAlpha80   : return new PixelFormatInfo(16, CMYK, ColorChannels.CMYKA);

                case Gray2         : return new PixelFormatInfo(2,  Grayscale, ColorChannels.K);
                case Gray4         : return new PixelFormatInfo(4,  Grayscale, ColorChannels.K);
                case Gray8         : return new PixelFormatInfo(8,  Grayscale, ColorChannels.K);
                case Gray16        : return new PixelFormatInfo(16, Grayscale, ColorChannels.K);
                case Gray32Float   : return new PixelFormatInfo(32, Grayscale, ColorChannels.K);

                case Pbgra32       : return new PixelFormatInfo( 8, RGB, ColorChannels.RGBA);
                case Prgba128Float : return new PixelFormatInfo(32, RGB, ColorChannels.RGBA);

                case Rgb24         : return new PixelFormatInfo( 8, RGB, ColorChannels.RGB);
                case Rgb48         : return new PixelFormatInfo(16, RGB, ColorChannels.RGB);
                case Rgba128Float  : return new PixelFormatInfo(32, RGB, ColorChannels.RGBA);
                case Rgba64        : return new PixelFormatInfo(16, RGB, ColorChannels.RGBA);

                default: return default;
            }
        }
    }

    public static class PixelFormatTypeExtensions
    {
        public static PixelFormatInfo GetInfo(this PixelFormat format) => PixelFormatInfo.Get(format);
    }
}