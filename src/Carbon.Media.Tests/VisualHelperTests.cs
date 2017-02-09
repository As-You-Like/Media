using Xunit;

namespace Carbon.Media.Tests
{
    public class VisualHelperTest
    {
        [Fact]
        public void GetDimensionsTest()
        {
            var source = new Size(500, 500);

            Assert.Equal(new Size(500, 500), ResizeHelper.Fit(source, bounds: new Size(600, 600)));
            Assert.Equal(new Size(500, 500), ResizeHelper.Fit(source, bounds: new Size(500, 500)));
            Assert.Equal(new Size(400, 400), ResizeHelper.Fit(source, bounds: new Size(400, 400)));
            Assert.Equal(new Size(235, 235), ResizeHelper.Fit(source, bounds: new Size(235, 290)));
            Assert.Equal(new Size(11, 11),   ResizeHelper.Fit(source, bounds: new Size(11, 15)));

            // Upscale
            Assert.Equal(new Size(600, 600), ResizeHelper.Fit(source, new Size(600, 600), upscale: true));


            source = new Size(5500, 1464);

            Assert.Equal(new Size(500, 133), ResizeHelper.Fit(source, new Size(500, 500)));
            Assert.Equal(new Size(400, 106), ResizeHelper.Fit(source, new Size(400, 400)));
            Assert.Equal(new Size(235, 62),  ResizeHelper.Fit(source, new Size(235, 290)));
            Assert.Equal(new Size(11, 2),    ResizeHelper.Fit(source, new Size(11, 15)));
        }

        [Fact]
        public void SquareImageTest()
        {
            var source = new Size(500, 500);

            Assert.Equal(new Size(500, 500), ResizeHelper.Max(source, new Rational(1, 1))); // Width = Height
            Assert.Equal(new Size(250, 500), ResizeHelper.Max(source, new Rational(1, 2))); // Width = 1/2 height
            Assert.Equal(new Size(125, 500), ResizeHelper.Max(source, new Rational(1, 4))); // Width = 1/4 width                    
            Assert.Equal(new Size(500, 250), ResizeHelper.Max(source, new Rational(2, 1))); // Width = 2x height
            Assert.Equal(new Size(500, 125), ResizeHelper.Max(source, new Rational(4, 1))); // Width = 4x height
        }

        [Fact]
        public void RetangleImageTest()
        {
            Size imageSize = new Size(468, 60);

            Assert.Equal(new Size(60, 60), ResizeHelper.Max(imageSize, new Rational(1, 1))); // Height = 1/1 Width
        }


        [Fact]
        public void OddSizedImageTest()
        {
            // Assert.Equal(new Size(1200, 225), VisualHelper.GetMaxSize(new Size(1200, 502), 5.32545));		// Height = 5.32545x Width
            Assert.Equal(new Size(802, 3), ResizeHelper.Max(new Size(802, 570), new Rational(240, 1)));    // Height = 240x width
        }

        [Fact]
        public void CropRectTest()
        {
            var imageSize = new Size(1000, 1000);

            var targetSize = new Size(1000, 500);

            var destinationR = ResizeHelper.CalculateCropRectangle(imageSize, targetSize, CropAnchor.Center);

            Assert.Equal(0, destinationR.X);
            Assert.Equal(-250, destinationR.Y);
        }

        [Fact]
        public void CropRectTest2()
        {
            var imageSize = new Size(1000, 1000);

            var targetSize = new Size(1000, 500);

            var destinationR = ResizeHelper.CalculateCropRectangle(imageSize, targetSize, CropAnchor.Bottom);

            Assert.Equal(0, destinationR.X);
            Assert.Equal(-500, destinationR.Y);
        }

        [Fact]
        public void ActualSizeCrop()
        {
            var imageSize = new Size(500, 500);

            var box = new Size(500, 500);

            foreach (var anchor in new[] { CropAnchor.Top, CropAnchor.Left, CropAnchor.Right, CropAnchor.Bottom, CropAnchor.Center })
            {
                var position = ResizeHelper.CalculateCropRectangle(imageSize, box, anchor);

                Assert.Equal(0, position.X);
                Assert.Equal(0, position.Y);
            }
        }

        [Fact]
        public void CalculateLargestSizeHavingAspect()
        {
            var size = new Size(1000, 1000);
            var targetAspect = new Rational(1, 1); // 1:1
            var result = new Size(0, 0);

            result = ResizeHelper.Max(size, targetAspect);

            Assert.Equal(new Size(1000, 1000), result);

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(2, 1); // 2:1 (width 2x height)

            result = ResizeHelper.Max(size, targetAspect);

            Assert.Equal(new Size(1000, 500), result);

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(3, 1); // 3:1 (width 3x height)

            result = ResizeHelper.Max(size, targetAspect);

            Assert.Equal(new Size(1000, 333), result);  // 333.3 (round down)

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(4, 1); // 3:1 (width 3x height)

            result = ResizeHelper.Max(size, targetAspect);

            Assert.Equal(new Size(1000, 250), result);  // 333.3 (round down)

            // -----------------------------------------------------------------------------------------------

            targetAspect = new Rational(1, 2); // 1:2 (width 0.5 height)

            result = ResizeHelper.Max(size, targetAspect);

            Assert.Equal(new Size(500, 1000), result);  // 333.3 (round down)
        }
    }
}