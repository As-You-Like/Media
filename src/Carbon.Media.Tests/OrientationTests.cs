using System.Drawing;

using Xunit;

namespace Carbon.Media.Tests
{
    public class OrientationTests
    {
        [Fact]
        public void GetOrientedSize()
        {
            var size = new Size(100, 200);

            foreach (var orientation in new[] {
                ExifOrientation.None,
                ExifOrientation.Horizontal,
                ExifOrientation.FlipHorizontal,
                ExifOrientation.FlipVertical })
            {
                Assert.Equal(size, OrientationHelper.GetOrientatedSize(size, orientation));             
            }

            foreach (var orientation in new[] {
                ExifOrientation.Transverse,
                ExifOrientation.Transpose,
                ExifOrientation.Rotate90,
                ExifOrientation.Rotate270 })
            {
                Assert.Equal(new Size(200, 100), OrientationHelper.GetOrientatedSize(size, orientation));
            }
        }

        [Fact]
        public void ParseNames()
        {
            Assert.Equal(ExifOrientation.Horizontal, OrientationHelper.Parse("h"));
            Assert.Equal(ExifOrientation.Rotate90,   OrientationHelper.Parse("rotate90"));
            Assert.Equal(ExifOrientation.Rotate180,  OrientationHelper.Parse("rotate180"));
            Assert.Equal(ExifOrientation.Rotate270,  OrientationHelper.Parse("rotate270"));
        }

        [Fact]
        public void ParseCodes()
        {
            Assert.Equal(ExifOrientation.Horizontal,     OrientationHelper.Parse("1"));
            Assert.Equal(ExifOrientation.FlipHorizontal, OrientationHelper.Parse("2"));
            Assert.Equal(ExifOrientation.Rotate180,      OrientationHelper.Parse("3"));
            Assert.Equal(ExifOrientation.FlipVertical,   OrientationHelper.Parse("4"));
            Assert.Equal(ExifOrientation.Transpose,      OrientationHelper.Parse("5"));
            Assert.Equal(ExifOrientation.Rotate90,       OrientationHelper.Parse("6"));
            Assert.Equal(ExifOrientation.Transverse,     OrientationHelper.Parse("7"));
            Assert.Equal(ExifOrientation.Rotate270,      OrientationHelper.Parse("8"));
        }
    }
}