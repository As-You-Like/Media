using Xunit;

namespace Carbon.Media.Tests
{
    public class PixelFormatTests
    {
        // Quick checks to make sure we never break these
        [Theory]
        [InlineData("Bgr24", PixelFormat.Bgr24, 2)]
        [InlineData("Bgra32", PixelFormat.Bgra32, 6)]
        [InlineData("BlackWhite", PixelFormat.BlackWhite, 10)]
        [InlineData("Cmyk32", PixelFormat.Cmyk32, 20)]
        public void Parse(string text, PixelFormat type, int id)
        {
            Assert.Equal(type, PixelFormatHelper.Parse(text));
            // Assert.Equal(id, (int)type);
        }

        /*
        [Fact]
        public void ColorChannelTests()
        {
            Assert.Equal(1, (int)ColorComponent.R);
            Assert.Equal(2, (int)ColorComponent.G);
            Assert.Equal(4, (int)ColorComponent.B);
            Assert.Equal(8, (int)ColorComponent.A);

            Assert.Equal(16, (int)ColorComponent.C);
            Assert.Equal(32, (int)ColorComponent.M);
            Assert.Equal(64, (int)ColorComponent.Y);
            Assert.Equal(128, (int)ColorComponent.K);

   
        }
        */

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
