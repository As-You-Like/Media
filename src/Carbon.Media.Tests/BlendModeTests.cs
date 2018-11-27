using Xunit;

namespace Carbon.Media.Tests
{
    public class BlendModeTests
    {
        [Fact]
        public void Parse()
        {
            Assert.Equal(BlendMode.Darken,      BlendModeHelper.Parse("DARKEN"));
            Assert.Equal(BlendMode.Multiply,    BlendModeHelper.Parse("MULTIPLY"));
            Assert.Equal(BlendMode.Lighten,     BlendModeHelper.Parse("LIGHTEN"));
            Assert.Equal(BlendMode.Screen,      BlendModeHelper.Parse("SCREEN"));
            Assert.Equal(BlendMode.Difference,  BlendModeHelper.Parse("DIFFERENCE"));
            Assert.Equal(BlendMode.Exclusion,   BlendModeHelper.Parse("EXCLUSION"));
            Assert.Equal(BlendMode.Hue,         BlendModeHelper.Parse("HUE"));
            Assert.Equal(BlendMode.Color,       BlendModeHelper.Parse("COLOR"));
        }

        [Fact]
        public void CanParseAllCssBlendModes()
        {
            Assert.Equal(BlendMode.Normal,      BlendModeHelper.Parse("normal"));
            Assert.Equal(BlendMode.Multiply,    BlendModeHelper.Parse("multiply"));
            Assert.Equal(BlendMode.Screen,      BlendModeHelper.Parse("screen"));
            Assert.Equal(BlendMode.Overlay,     BlendModeHelper.Parse("overlay"));
            Assert.Equal(BlendMode.Darken,      BlendModeHelper.Parse("darken"));
            Assert.Equal(BlendMode.Lighten,     BlendModeHelper.Parse("lighten"));
            Assert.Equal(BlendMode.ColorDodge,  BlendModeHelper.Parse("color-dodge"));
            Assert.Equal(BlendMode.ColorBurn,   BlendModeHelper.Parse("color-burn"));
            Assert.Equal(BlendMode.HardLight,   BlendModeHelper.Parse("hard-light"));
            Assert.Equal(BlendMode.SoftLight,   BlendModeHelper.Parse("soft-light"));
            Assert.Equal(BlendMode.Difference,  BlendModeHelper.Parse("difference"));
            Assert.Equal(BlendMode.Exclusion,   BlendModeHelper.Parse("exclusion"));
            Assert.Equal(BlendMode.Hue,         BlendModeHelper.Parse("hue"));
            Assert.Equal(BlendMode.Saturation,  BlendModeHelper.Parse("saturation"));
            Assert.Equal(BlendMode.Color,       BlendModeHelper.Parse("color"));
            Assert.Equal(BlendMode.Luminosity,  BlendModeHelper.Parse("luminosity"));
        }
    }
}
