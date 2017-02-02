using Xunit;

namespace Carbon.Media.Tests
{
	public class SizeTests
	{
		[Fact]
		public void WithinTests()
		{
			Assert.True(new Size(50, 50).FitsIn(new Size(50, 50)));
			Assert.True(new Size(50, 55).FitsIn(new Size(50, 55)));
			Assert.True(new Size(55, 50).FitsIn(new Size(55, 50)));
			Assert.True(new Size(50, 50).FitsIn(new Size(100, 100)));

			Assert.False(new Size(50, 50).FitsIn(new Size(50, 49)));
			Assert.False(new Size(50, 50).FitsIn(new Size(49, 50)));
			Assert.False(new Size(51, 50).FitsIn(new Size(50, 50)));
			Assert.False(new Size(50, 51).FitsIn(new Size(50, 50)));
		}

		[Fact]
		public void ToStringTests()
		{
			Assert.Equal("50x51", new Size(50, 51).ToString());
			Assert.Equal("0x0", new Size(0, 0).ToString());
		}
	}
}