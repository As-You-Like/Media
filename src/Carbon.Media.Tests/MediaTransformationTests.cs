using System;
using Xunit;

namespace Carbon.Media.Tests
{
    public class MediaTransformTests
    {
        [Fact]
        public void A()
        {
            Assert.Throws<InvalidTransformException>(() => MediaTransformation.ParsePath("10888535;500x500-c/pixelate(5)//grayscale(0.1).png"));
            Assert.Throws<InvalidTransformException>(() => MediaTransformation.ParsePath("10888535;500x500-c/grayscale(-1)/grayscale(0.1).png"));
        }

        [Fact]
        public void B()
        {
            try
            {
                var a = MediaTransformation.ParsePath("10888535;500x500-c/blur(2001).png");
            }
            catch (InvalidTransformException ex)
            {
                Assert.Equal(1, ex.Index);

                // Assert.Equal("Must be between 0 and 2,000", ex.InnerException.Message);
                Assert.Equal(typeof(ArgumentOutOfRangeException), ex.InnerException.GetType());
            }
        }

        [Fact]
        public void C()
        {
            try
            {
                var a = MediaTransformation.ParsePath("10888535;500x500-c/blur(2000)/sepia(-1).png");
            }
            catch (InvalidTransformException ex)
            {
                Assert.Equal(2, ex.Index);

                // Assert.Equal("Must be >= 0", ex.Message);
            }
        }
    }
}