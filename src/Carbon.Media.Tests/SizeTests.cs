using System.Drawing;
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
		public void ParseTests()
		{
			Assert.Equal(new Size(50, 51), SizeHelper.Parse("50x51"));
            Assert.Equal(Size.Empty,       SizeHelper.Parse("0x0"));

		}


        [Fact]
        public void TryParseTests()
        {
            Assert.True(SizeHelper.TryParse("0x0", out _));
            Assert.True(SizeHelper.TryParse("900x900", out _));

            Assert.True(SizeHelper.TryParse("1x2", out Size size));
            Assert.Equal(new Size(1, 2), size);

            Assert.False(SizeHelper.TryParse("100", out _));
            Assert.False(SizeHelper.TryParse("", out _));
            Assert.False(SizeHelper.TryParse("0x", out _));
            Assert.False(SizeHelper.TryParse("0x_", out _));
            Assert.False(SizeHelper.TryParse("_x0", out _));
            Assert.False(SizeHelper.TryParse("x0x9", out _));
        }
    }

    public class SizeFTests
    {

        [Fact]
        public void ParseTests()
        {
            Assert.Equal(new SizeF(50, 51), SizeHelper.Parse("50x51"));
            Assert.Equal(SizeF.Empty, SizeHelper.Parse("0x0"));

        }


        [Fact]
        public void TryParseTests()
        {
            Assert.True(SizeFHelper.TryParse("0x0", out _));
            Assert.True(SizeFHelper.TryParse("900x900", out _));

            Assert.True(SizeFHelper.TryParse("1x2", out SizeF a));
            Assert.Equal(new SizeF(1, 2), a);

            Assert.True(SizeFHelper.TryParse("1.5x2.5", out SizeF b));
            Assert.Equal(new SizeF(1.5f, 2.5f), b);

            Assert.False(SizeFHelper.TryParse("100", out _));
            Assert.False(SizeFHelper.TryParse("", out _));
            Assert.False(SizeFHelper.TryParse("0x", out _));
            Assert.False(SizeFHelper.TryParse("0x_", out _));
            Assert.False(SizeFHelper.TryParse("_x0", out _));
            Assert.False(SizeFHelper.TryParse("x0x9", out _));
        }
    }
}