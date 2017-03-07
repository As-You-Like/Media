using System;

using Xunit;

namespace Carbon.Media.Tests
{
    public class OrientationTests
    {
        [Fact]
        public void OrientationParse()
        {
            var orientation = (ExifOrientation)Enum.Parse(typeof(ExifOrientation), "1");

            Assert.Equal(ExifOrientation.Horizontal, orientation);
            Assert.Equal(ExifOrientation.Horizontal, OrientationHelper.Parse("1"));
        }
    }
}