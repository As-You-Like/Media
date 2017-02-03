using System;

using Xunit;

namespace Carbon.Media.Tests
{
    public class OrientationTests
    {
        [Fact]
        public void OrientationParse()
        {
            var orientation = (MediaOrientation)Enum.Parse(typeof(MediaOrientation), "1");

            Assert.Equal(MediaOrientation.Horizontal, orientation);
            Assert.Equal(MediaOrientation.Horizontal, OrientationHelper.Parse("1"));
        }
    }
}