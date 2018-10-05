using Xunit;

namespace Carbon.Media.Tests
{
    public class ColorSpaceTests
    {
        [Fact]
        public void Parse()
        {
            Assert.Equal(ColorSpace.sRGB,     ColorSpaceHelper.Parse("sRgb"));
            Assert.Equal(ColorSpace.sRGB,     ColorSpaceHelper.Parse("sRGB"));
            Assert.Equal(ColorSpace.AdobeRGB, ColorSpaceHelper.Parse("AdobeRgb"));

            Assert.Equal(ColorSpace.RGB, ColorSpaceHelper.Parse("RGB"));
            Assert.Equal(ColorSpace.RGB, ColorSpaceHelper.Parse("rgb"));
            Assert.Equal(ColorSpace.CMYK, ColorSpaceHelper.Parse("cmyk"));
            Assert.Equal(ColorSpace.Gray, ColorSpaceHelper.Parse("grayscale"));
        }

        [Fact]
        public void TryParse()
        {
            Assert.True(ColorSpaceHelper.TryParse("RGB", out _));
            Assert.False(ColorSpaceHelper.TryParse("RGBq", out _));

        }

        [Fact]
        public void IdsAreStable()
        {
            Assert.Equal(4,  (int)ColorSpace.AdobeRGB);
            Assert.Equal(11, (int)ColorSpace.LUV);
            Assert.Equal(21, (int)ColorSpace.CMYK);
            Assert.Equal(42, (int)ColorSpace.HLS);
        }

        [Fact]
        public void DciP3InfoIsCorrect()
        {
            var colorSpace = ColorSpaceInfo.DciP3;
            
            Assert.Equal(ColorModel.RGB, colorSpace.Model);
            Assert.True(colorSpace.IsWideGamut);
        }
    }
}
