namespace Carbon.Imaging
{
    public struct PixelFormatInfo
    {
        public PixelFormatInfo(int bitsPerPixel, ColorModel model, ColorChannels channels)
        {
            BitsPerPixel = bitsPerPixel;
            ColorModel = model;
            Channels = channels;
        }

        public int BitsPerPixel { get; }

        public ColorModel ColorModel { get; }

        public ColorChannels Channels { get; }

        public static PixelFormatInfo Get(PixelFormatType format)
        {
            switch (format)
            {
                case PixelFormatType.Bgr101010      : return new PixelFormatInfo(10, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Bgr24          : return new PixelFormatInfo( 8, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Bgr32          : return new PixelFormatInfo( 8, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Bgr555         : return new PixelFormatInfo( 5, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Bgr565         : return new PixelFormatInfo( 5, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Bgra32         : return new PixelFormatInfo( 8, ColorModel.RGB, ColorChannels.RGBA);

                case PixelFormatType.BlackWhite     : return new PixelFormatInfo(1, ColorModel.Grayscale, ColorChannels.K);

                case PixelFormatType.Cmyk32         : return new PixelFormatInfo(8, ColorModel.CMYK, ColorChannels.CMYK);
                case PixelFormatType.Cmyk64         : return new PixelFormatInfo(16, ColorModel.CMYK, ColorChannels.CMYK);
                case PixelFormatType.CmykAlpha40    : return new PixelFormatInfo(8, ColorModel.CMYK, ColorChannels.CMYKA);
                case PixelFormatType.CmykAlpha80    : return new PixelFormatInfo(16, ColorModel.CMYK, ColorChannels.CMYKA);

                case PixelFormatType.Gray2          : return new PixelFormatInfo(2, ColorModel.Grayscale, ColorChannels.K);
                case PixelFormatType.Gray4          : return new PixelFormatInfo(4, ColorModel.Grayscale, ColorChannels.K);
                case PixelFormatType.Gray8          : return new PixelFormatInfo(8, ColorModel.Grayscale, ColorChannels.K);
                case PixelFormatType.Gray16         : return new PixelFormatInfo(16, ColorModel.Grayscale, ColorChannels.K);
                case PixelFormatType.Gray32Float    : return new PixelFormatInfo(32, ColorModel.Grayscale, ColorChannels.K);

                case PixelFormatType.Pbgra32        : return new PixelFormatInfo(8, ColorModel.RGB, ColorChannels.RGBA);
                case PixelFormatType.Prgba128Float  : return new PixelFormatInfo(32, ColorModel.RGB, ColorChannels.RGBA);

                case PixelFormatType.Rgb24          : return new PixelFormatInfo(8, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Rgb48          : return new PixelFormatInfo(16, ColorModel.RGB, ColorChannels.RGB);
                case PixelFormatType.Rgba128Float   : return new PixelFormatInfo(32, ColorModel.RGB, ColorChannels.RGBA);
                case PixelFormatType.Rgba64         : return new PixelFormatInfo(16, ColorModel.RGB, ColorChannels.RGBA);

                default: return default(PixelFormatInfo);
            }
        }
    }

    public static class PixelFormatTypeExtensions
    {
        public static PixelFormatInfo GetInfo(this PixelFormatType format) => PixelFormatInfo.Get(format);
    }

}
