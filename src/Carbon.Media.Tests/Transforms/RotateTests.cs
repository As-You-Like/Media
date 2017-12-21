using Xunit;

namespace Carbon.Media.Processors.Tests
{
    public class RotateTests
	{
		[Fact]
		public void ParseValues()
		{
            Assert.Equal(0,   RotateTransform.Parse("0").Angle);
            Assert.Equal(180, RotateTransform.Parse("180").Angle);
            Assert.Equal(360, RotateTransform.Parse("360").Angle);
            Assert.Equal(0,   RotateTransform.Parse("0deg").Angle);
            Assert.Equal(180, RotateTransform.Parse("180deg").Angle);
            Assert.Equal(360, RotateTransform.Parse("360deg").Angle);
        }

		[Fact]
		public void FromPartialKey()
		{
            Assert.Equal(0,   RotateTransform.Parse("rotate(0)").Angle);
            Assert.Equal(360, RotateTransform.Parse("rotate(360)").Angle);
            Assert.Equal(360, RotateTransform.Parse("rotate(360deg)").Angle);
            // Assert.Equal(360, Rotate.Parse("rotate(1rad)").Angle);
        }
    }
}