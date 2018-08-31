using System;
using Carbon.Media.Processing;
using Xunit;

namespace Carbon.Media.Tests
{
    public class MediaTransformTests
    {
        [Fact]
        public void A()
        {
            Assert.Throws<InvalidTransformException>(() => MediaTransformation.Parse("10888535;500x500-c/pixelate(5)//grayscale(0.1).png"));
            Assert.Throws<InvalidTransformException>(() => MediaTransformation.Parse("10888535;500x500-c/grayscale(-1)/grayscale(0.1).png"));
        }

        [Fact]
        public void OrientTest3()
        {
            var t = MediaTransformation.Parse("33695921;960x1280/rotate(90).jpeg");

            var transforms = t.GetTransforms();

            Assert.Equal("33695921", t.Source.Key);

            var resize = (transforms[0] as ResizeTransform);
            var rotate = (transforms[1] as RotateTransform);
            var encode = (transforms[2] as EncodeParameters);

            Assert.Equal((960, 1280), (resize.Width, resize.Height));
            Assert.Equal(90, rotate.Angle);
            Assert.Equal(FormatId.Jpeg, encode.Format);
        }

        [Fact]
        public void B()
        {
            try
            {
                var a = MediaTransformation.Parse("10888535;500x500-c/blur(2001).png");
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
                var a = MediaTransformation.Parse("10888535;500x500-c/blur(2000)/sepia(-1).png");
            }
            catch (InvalidTransformException ex)
            {
                Assert.Equal(2, ex.Index);

                // Assert.Equal("Must be >= 0", ex.Message);
            }
        }
    }
}