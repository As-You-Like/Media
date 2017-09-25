﻿using Xunit;

namespace Carbon.Media.Tests
{
    public class FileFormatTests
    {
        [Theory]
        [InlineData(".GIF", "gif")]
        [InlineData(".jpg", "jpeg")]
        [InlineData(".MpG", "mpeg")]
        public void Normalize(string input, string normalized)
        {
            Assert.Equal(normalized, FileFormat.Normalize(input));
        }

        [Theory]
        [InlineData("a/asfasdf.GIF", "gif")]
        [InlineData("234234(adasf.gif)/a/asfasdf.pNg", "png")]
        public void FromPaths(string input, string normalized)
        {
            Assert.Equal(normalized, FileFormat.FromPath(input));
        }

        [Fact]
        public void FromPath()
        {
            Assert.Equal("pdf", FileFormat.FromPath("holiday_gift_center_1998.pdf"));
        }

        /*
		[Fact]
		public void CompressableTests()
		{
			Assert.True(FileFormat.IsCompressible("txt"));
			Assert.True(FileFormat.IsCompressible("css"));
			Assert.True(FileFormat.IsCompressible("js"));

			Assert.False(FileFormat.IsCompressible("woff"));
			Assert.False(FileFormat.IsCompressible("jpeg"));
			Assert.False(FileFormat.IsCompressible("gif"));
		}
        */

        /*
		[Fact]
		public void FeatureTests()
		{
			Assert.Equal(1, (int)MediaFlags.None);
			Assert.Equal(2, (int)MediaFlags.AlphaChannel);
			Assert.Equal(4, (int)MediaFlags.Animated);
			Assert.Equal(8, (int)MediaFlags.ColorProfile);

			Assert.Equal(32, (int)MediaFlags.CMYK);
			// Assert.Equal(1, (int)MediaFeatures.None);
			// Assert.Equal(1, (int)MediaFeatures.None);
		}
		*/
    }
}