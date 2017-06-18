using System.Drawing;

using Xunit;

namespace Carbon.Media.Tests
{
    using static ResizeHelper;
    using static CropAnchor;

    public class VisualHelperTest
    {
        [Fact]
        public void PadTests()
        {
            var source = new Size(500, 500);
            var bounds = new Size(1000, 1000);

            var box = Pad(source, bounds, Center, upscale: false);

            Assert.Equal(500d, box.Width);
            Assert.Equal(500d, box.Height);

            Assert.Equal(250, box.Padding.Top);
            Assert.Equal(250, box.Padding.Right);
            Assert.Equal(250, box.Padding.Bottom);
            Assert.Equal(250, box.Padding.Left);
            
            Assert.Equal(1000d, box.OuterWidth);
            Assert.Equal(1000d, box.OuterHeight);

            box = Pad(source, bounds, Left, upscale: false);

            Assert.Equal(250, box.Padding.Top);
            Assert.Equal(500, box.Padding.Right);
            Assert.Equal(250, box.Padding.Bottom);
            Assert.Equal(0, box.Padding.Left);
  
            box = Pad(source, bounds, Top | Right, upscale: false);

            Assert.Equal(0, box.Padding.Top);
            Assert.Equal(0, box.Padding.Right);
            Assert.Equal(500, box.Padding.Bottom);
            Assert.Equal(500, box.Padding.Left);
        }

        [Fact]
        public void PadTests2()
        {
            var source = new Size(100, 200);  // 1x2            500x1000
            var bounds = new Size(1000, 1000);

            var box = ResizeHelper.Pad(source, bounds, CropAnchor.Center, upscale: true);

            Assert.Equal(500d, box.Width);
            Assert.Equal(1000d, box.Height);

            Assert.Equal(0, box.Padding.Top);
            Assert.Equal(250, box.Padding.Right);
            Assert.Equal(0, box.Padding.Bottom);
            Assert.Equal(250, box.Padding.Left);

            Assert.Equal(1000d, box.OuterWidth);
            Assert.Equal(1000d, box.OuterHeight);

            box = ResizeHelper.Pad(source, bounds, Right, upscale: true);

            Assert.Equal(500, box.Padding.Left);
            Assert.Equal(0, box.Padding.Right);
        }

        [Fact]
        public void GetDimensionsTest()
        {
            var source = new Size(500, 500);

            Assert.Equal(new Size(500, 500), Fit(source, bounds: new Size(600, 600)));
            Assert.Equal(new Size(500, 500), Fit(source, bounds: new Size(500, 500)));
            Assert.Equal(new Size(400, 400), Fit(source, bounds: new Size(400, 400)));
            Assert.Equal(new Size(235, 235), Fit(source, bounds: new Size(235, 290)));
            Assert.Equal(new Size(11, 11),   Fit(source, bounds: new Size(11, 15)));

            // Upscale
            Assert.Equal(new Size(600, 600), Fit(source, new Size(600, 600), upscale: true));


            source = new Size(5500, 1464);

            Assert.Equal(new Size(500, 133), Fit(source, new Size(500, 500)));
            Assert.Equal(new Size(400, 106), Fit(source, new Size(400, 400)));
            Assert.Equal(new Size(235, 62),  Fit(source, new Size(235, 290)));
            Assert.Equal(new Size(11, 2),    Fit(source, new Size(11, 15)));
        }

        [Fact]
        public void SquareImageTest()
        {
            var source = new Size(500, 500);

            Assert.Equal(new Size(500, 500), Max(source, new Rational(1, 1))); // Width = Height
            Assert.Equal(new Size(250, 500), Max(source, new Rational(1, 2))); // Width = 1/2 height
            Assert.Equal(new Size(125, 500), Max(source, new Rational(1, 4))); // Width = 1/4 width                    
            Assert.Equal(new Size(500, 250), Max(source, new Rational(2, 1))); // Width = 2x height
            Assert.Equal(new Size(500, 125), Max(source, new Rational(4, 1))); // Width = 4x height
        }

        [Fact]
        public void RetangleImageTest()
        {
            Size imageSize = new Size(468, 60);

            Assert.Equal(new Size(60, 60), Max(imageSize, new Rational(1, 1))); // Height = 1/1 Width
        }


        [Fact]
        public void OddSizedImageTest()
        {
            // Assert.Equal(new Size(1200, 225), GetMaxSize(new Size(1200, 502), 5.32545));		// Height = 5.32545x Width
            Assert.Equal(new Size(802, 3), Max(new Size(802, 570), new Rational(240, 1)));    // Height = 240x width
        }

        [Fact]
        public void CropRectTest()
        {
            var imageSize = new Size(1000, 1000);

            var targetSize = Aspect(1000, 500);

            var rect = CalculateCropRectangle(imageSize, targetSize, Center);

            Assert.Equal(0, rect.X);
            Assert.Equal(250, rect.Y);

            targetSize = Aspect(2, 1);

            rect = CalculateCropRectangle(imageSize, targetSize, Center);

            Assert.Equal(0, rect.X);
            Assert.Equal(250, rect.Y);
        }

        [Fact]
        public void CropTop()
        {
            var source = new Size(800, 600); // 4x3

            // 1x1 (distribute 200px horizontally)
            Assert.Equal(new Rectangle(100, 0, 600, 600), CalculateCropRectangle(source, Aspect(800, 800), Top));
            Assert.Equal(new Rectangle(0, 0, 800, 300),   CalculateCropRectangle(source, Aspect(1600, 600), Top));  

        }

        private static Rational Aspect(int width, int height) =>
            new Size(width, height).ToRational();
        

        [Fact]
        public void CropBottom()
        {
            var source = new Size(800, 600); // 4x3

            Assert.Equal(new Rectangle(100, 0, 600, 600), CalculateCropRectangle(source, Aspect(800, 800), Bottom)); // 100px to left & right
            Assert.Equal(new Rectangle(0, 0, 800, 600), CalculateCropRectangle(source, Aspect(800, 600), Bottom)); 
        }

        [Fact]
        public void ScaleUpCrop()
        {
            var source = new Size(800, 600);

            foreach (var size in new[] { new Size(800, 600), new Size(1600, 1200), new Size(3200, 2400) })
            {
                Assert.Equal(new Rectangle(0, 0, 800, 600), CalculateCropRectangle(source, size.ToRational(), Center));
            }
        }

        [Fact]
        public void ScaleDownCrop()
        {
            var source = new Size(800, 600);

            foreach (var size in new[] { new Size(800, 600), new Size(400, 300), new Size(200, 150) })
            {
                Assert.Equal(new Rectangle(0, 0, 800, 600), CalculateCropRectangle(source, size.ToRational(), Center));
            }
        }

        [Fact]
        public void CropRectTest2()
        {
            var imageSize = new Size(1000, 1000);

            var targetSize = new Size(1000, 500).ToRational();

            var destinationR = CalculateCropRectangle(imageSize, targetSize, Bottom);

            Assert.Equal(0, destinationR.X);
            Assert.Equal(500, destinationR.Y);
        }

        [Fact]
        public void ActualSizeCrop()
        {
            var imageSize = new Size(500, 500);

            var box = Aspect(500, 500);

            foreach (var anchor in new[] { Top, Left, Right, Bottom, Center })
            {
                var position = CalculateCropRectangle(imageSize, box, anchor);

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