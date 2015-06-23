namespace Carbon.Media.Tests
{
	using System;

	using Xunit;

	
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