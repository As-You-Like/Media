﻿namespace Carbon.Helpers.Tests
{
    using Carbon.Media;

    using Xunit;


    public class VisualHelperTest
    {
        [Fact]
        public void GetDimensionsTest()
        {
            var imageSize = new Size(500, 500);

            Assert.Equal(new Size(500, 500), VisualHelper.CalculateScaledSize(imageSize, new Size(600, 600), ScaleMode.None));
            Assert.Equal(new Size(500, 500), VisualHelper.CalculateScaledSize(imageSize, new Size(500, 500), ScaleMode.None));
            Assert.Equal(new Size(400, 400), VisualHelper.CalculateScaledSize(imageSize, new Size(400, 400), ScaleMode.None));
            Assert.Equal(new Size(235, 235), VisualHelper.CalculateScaledSize(imageSize, new Size(235, 290), ScaleMode.None));
            Assert.Equal(new Size(11, 11), VisualHelper.CalculateScaledSize(imageSize, new Size(11, 15), ScaleMode.None));

            // Stretch
            Assert.Equal(new Size(600, 600), VisualHelper.CalculateScaledSize(imageSize, new Size(600, 600), ScaleMode.Stretch));

            imageSize = new Size(5500, 1464);

            Assert.Equal(new Size(500, 133), VisualHelper.CalculateScaledSize(imageSize, new Size(500, 500), ScaleMode.None));
            Assert.Equal(new Size(400, 106), VisualHelper.CalculateScaledSize(imageSize, new Size(400, 400), ScaleMode.None));
            Assert.Equal(new Size(235, 62), VisualHelper.CalculateScaledSize(imageSize, new Size(235, 290), ScaleMode.None));
            Assert.Equal(new Size(11, 2), VisualHelper.CalculateScaledSize(imageSize, new Size(11, 15), ScaleMode.None));
        }

        [Fact]
        public void SquareImageTest()
        {
            var imageSize = new Size(500, 500);

            Assert.Equal(new Size(500, 500), VisualHelper.CalculateMaxSize(imageSize, new Rational(1, 1))); // Width = Height
            Assert.Equal(new Size(250, 500), VisualHelper.CalculateMaxSize(imageSize, new Rational(1, 2))); // Width = 1/2 height
            Assert.Equal(new Size(125, 500), VisualHelper.CalculateMaxSize(imageSize, new Rational(1, 4))); // Width = 1/4 width

            Assert.Equal(new Size(500, 250), VisualHelper.CalculateMaxSize(imageSize, new Rational(2, 1))); // Width = 2x height
            Assert.Equal(new Size(500, 125), VisualHelper.CalculateMaxSize(imageSize, new Rational(4, 1))); // Width = 4x height
        }

        [Fact]
        public void RetangleImageTest()
        {
            Size imageSize = new Size(468, 60);

            Assert.Equal(new Size(60, 60), VisualHelper.CalculateMaxSize(imageSize, new Rational(1, 1))); // Height = 1/1 Width
        }


        [Fact]
        public void OddSizedImageTest()
        {
            // Assert.Equal(new Size(1200, 225), VisualHelper.GetMaxSize(new Size(1200, 502), 5.32545));		// Height = 5.32545x Width
            Assert.Equal(new Size(802, 3), VisualHelper.CalculateMaxSize(new Size(802, 570), new Rational(240, 1)));    // Height = 240x width
        }

        [Fact]
        public void CropRectTest()
        {
            var imageSize = new Size(1000, 1000);

            var targetSize = new Size(1000, 500);

            var destinationR = VisualHelper.CalculateCropRectangle(imageSize, targetSize, Alignment.Center);

            //Assert.Equal(0, destinationR.Left);
            // Assert.Equal(-250, destinationR.Top);

            Assert.Equal(0, destinationR.X);
            Assert.Equal(-250, destinationR.Y);
        }

        [Fact]
        public void CalculateLargestSizeHavingAspect()
        {
            var size = new Size(1000, 1000);
            var targetAspect = new Rational(1, 1); // 1:1
            var result = new Size(0, 0);

            result = VisualHelper.CalculateMaxSize(size, targetAspect);

            Assert.Equal(new Size(1000, 1000), result);

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(2, 1); // 2:1 (width 2x height)

            result = VisualHelper.CalculateMaxSize(size, targetAspect);

            Assert.Equal(new Size(1000, 500), result);

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(3, 1); // 3:1 (width 3x height)

            result = VisualHelper.CalculateMaxSize(size, targetAspect);

            Assert.Equal(new Size(1000, 333), result);  // 333.3 (round down)

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(4, 1); // 3:1 (width 3x height)

            result = VisualHelper.CalculateMaxSize(size, targetAspect);

            Assert.Equal(new Size(1000, 250), result);  // 333.3 (round down)

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(1, 2); // 1:2 (width 0.5 height)

            result = VisualHelper.CalculateMaxSize(size, targetAspect);

            Assert.Equal(new Size(500, 1000), result);  // 333.3 (round down)
        }
    }
}