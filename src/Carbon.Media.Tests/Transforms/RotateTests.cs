using Xunit;

namespace Carbon.Media.Processing.Tests
{
    public class RotateTests
	{
		[Fact]
		public void FromPartialKey()
		{
            Assert.Equal(0,   Parse("rotate(0)").Angle);
            Assert.Equal(0,   Parse("rotate(0deg)").Angle);
            Assert.Equal(180, Parse("rotate(180)").Angle);
            Assert.Equal(180, Parse("rotate(180deg)").Angle);
            Assert.Equal(360, Parse("rotate(360)").Angle);
            Assert.Equal(360, Parse("rotate(360deg)").Angle);
        }

        // Assert.Equal(360, Rotate.Parse("rotate(1rad)").Angle);

        private static RotateTransform Parse(string text)
        {
            return RotateTransform.Create(CallSyntax.Parse(text));
        }
    }
}