using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class ScaleTests
	{
        [Fact]
        public void A()
        {
            var scale = Scale.Parse("scale(800,600)");

            Assert.Equal(800, scale.Width);
            Assert.Equal(600, scale.Height);

            Assert.Equal("scale(800,600,box)", scale.Canonicalize());
        }

        [Fact]
        public void B()
        {
            var scale = new Scale(800, 600, InterpolaterMode.Lanczos3);
            
            Assert.Equal("scale(800,600,lanczos3)", scale.Canonicalize());

            scale = Scale.Parse(scale.Canonicalize());

            Assert.Equal(800, scale.Width);
            Assert.Equal(600, scale.Height);
            Assert.Equal(InterpolaterMode.Lanczos3, scale.Mode);
        }
    }
}