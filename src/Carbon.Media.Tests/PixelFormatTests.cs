using Xunit;

namespace Carbon.Media.Tests
{
    public class PixelFormatTests
    {
        [Theory]
        [InlineData("Bgr24",      PixelFormat.Bgr24)]
        [InlineData("Bgra32",     PixelFormat.Bgra32)]
        [InlineData("BlackWhite", PixelFormat.BlackWhite)]
        [InlineData("Cmyk32",     PixelFormat.Cmyk32)]
        public void Parse(string text, PixelFormat type)
        {
            Assert.Equal(type, PixelFormatHelper.Parse(text));
        }
        
        [Fact]
        public void ColorChannelTests()
        {
            Assert.Equal(1,  (int)ColorComponent.R);
            Assert.Equal(2,  (int)ColorComponent.G);
            Assert.Equal(3,  (int)ColorComponent.B);
            Assert.Equal(4,  (int)ColorComponent.A);
            Assert.Equal(5,  (int)ColorComponent.Cb);
            Assert.Equal(6,  (int)ColorComponent.Cr);
            Assert.Equal(7,  (int)ColorComponent.Y);
            Assert.Equal(10, (int)ColorComponent.Cyan);
            Assert.Equal(11, (int)ColorComponent.Magenta);
            Assert.Equal(12, (int)ColorComponent.Yellow);
            Assert.Equal(13, (int)ColorComponent.Key);
        }

        [Fact]
        public void A()
        {
            var bw = PixelFormat.BlackWhite.GetInfo();

            Assert.Equal(1, bw.BitsPerPixel);
            // Assert.Equal(ColorChannels.K, bw.Channels);
            Assert.Equal(ColorModel.Monochrome, bw.ColorModel);

            var rgb24 = PixelFormat.Rgb24.GetInfo();

            Assert.Equal(8, rgb24.BitsPerPixel);
            // Assert.Equal(ColorChannels.RGB, rgb24.Channels);
            Assert.Equal(ColorModel.RGB, rgb24.ColorModel);

            var rgba64 = PixelFormat.Rgba64.GetInfo();

            Assert.Equal(16, rgba64.BitsPerPixel);
            // Assert.Equal(ColorChannels.RGBA, rgba64.Channels);
            Assert.Equal(ColorModel.RGB, rgba64.ColorModel);
        }
    }
}
