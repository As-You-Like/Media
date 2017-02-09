using System;

using Xunit;

namespace Carbon.Media.Tests
{
    public class OrientationTests
    {
        [Fact]
        public void OrientationParse()
        {
            var orientation = (ImageOrientation)Enum.Parse(typeof(ImageOrientation), "1");

            Assert.Equal(ImageOrientation.Horizontal, orientation);
            Assert.Equal(ImageOrientation.Horizontal, OrientationHelper.Parse("1"));
        }
    }
}