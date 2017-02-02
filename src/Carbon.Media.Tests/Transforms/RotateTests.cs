using Xunit;

namespace Carbon.Media.Tests
{	
	public class RotateTests
	{
		[Fact]
		public void FromFullKey()
		{
			var rotate = Rotate.Parse("360");

			Assert.Equal(360, rotate.Angle);
		}

		[Fact]
		public void FromPartialKey()
		{
			var rotate = Rotate.Parse("rotate(360)");

			Assert.Equal(360, rotate.Angle);
		}
	}
}