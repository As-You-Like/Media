namespace Carbon.Helpers.Tests
{
	using System.Drawing;

	using Carbon.Math;
	using Carbon.Media;

	using NUnit.Framework;

	[TestFixture]
	public class VisualHelperTest
	{
		[Test]
		public void GetDimensionsTest()
		{
			var imageSize = new Size(500, 500);

			Assert.AreEqual(new Size(500, 500), VisualHelper.CalculateScaledSize(imageSize, new Size(600, 600), ScaleMode.None));
			Assert.AreEqual(new Size(500, 500), VisualHelper.CalculateScaledSize(imageSize, new Size(500, 500), ScaleMode.None));
			Assert.AreEqual(new Size(400, 400), VisualHelper.CalculateScaledSize(imageSize, new Size(400, 400), ScaleMode.None));
			Assert.AreEqual(new Size(235, 235), VisualHelper.CalculateScaledSize(imageSize, new Size(235, 290), ScaleMode.None));
			Assert.AreEqual(new Size(11, 11), VisualHelper.CalculateScaledSize(imageSize, new Size(11, 15), ScaleMode.None));

			// Stretch
			Assert.AreEqual(new Size(600, 600), VisualHelper.CalculateScaledSize(imageSize, new Size(600, 600), ScaleMode.Stretch));

			imageSize = new Size(5500, 1464);

			Assert.AreEqual(new Size(500, 133), VisualHelper.CalculateScaledSize(imageSize, new Size(500, 500), ScaleMode.None));
			Assert.AreEqual(new Size(400, 106), VisualHelper.CalculateScaledSize(imageSize, new Size(400, 400), ScaleMode.None));
			Assert.AreEqual(new Size(235, 62), VisualHelper.CalculateScaledSize(imageSize, new Size(235, 290), ScaleMode.None));
			Assert.AreEqual(new Size(11, 2), VisualHelper.CalculateScaledSize(imageSize, new Size(11, 15), ScaleMode.None));
		}

		[Test]
		public void SquareImageTest()
		{
			var imageSize = new Size(500, 500);

			Assert.AreEqual(new Size(500, 500), VisualHelper.CalculateMaxSize(imageSize, new Fraction(1, 1)));	// Width = Height
			Assert.AreEqual(new Size(250, 500), VisualHelper.CalculateMaxSize(imageSize, new Fraction(1, 2)));	// Width = 1/2 height
			Assert.AreEqual(new Size(125, 500), VisualHelper.CalculateMaxSize(imageSize, new Fraction(1, 4)));	// Width = 1/4 width

			Assert.AreEqual(new Size(500, 250), VisualHelper.CalculateMaxSize(imageSize, new Fraction(2, 1)));	// Width = 2x height
			Assert.AreEqual(new Size(500, 125), VisualHelper.CalculateMaxSize(imageSize, new Fraction(4, 1)));	// Width = 4x height
		}

		[Test]
		public void RetangleImageTest()
		{
			Size imageSize = new Size(468, 60);

			Assert.AreEqual(new Size(60, 60), VisualHelper.CalculateMaxSize(imageSize, new Fraction(1, 1))); // Height = 1/1 Width
		}


		[Test]
		public void OddSizedImageTest()
		{
			// Assert.AreEqual(new Size(1200, 225), VisualHelper.GetMaxSize(new Size(1200, 502), 5.32545));		// Height = 5.32545x Width
			Assert.AreEqual(new Size(802, 3), VisualHelper.CalculateMaxSize(new Size(802, 570), new Fraction(240, 1)));	// Height = 240x width
		}

		[Test]
		public void CropRectTest()
		{
			var imageSize = new Size(1000, 1000);

			var targetSize = new Size(1000, 500);

			Rectangle destinationR = VisualHelper.CalculateCropRectangle(imageSize, targetSize, Alignment.Center);

			Assert.AreEqual(0, destinationR.Left);
			Assert.AreEqual(-250, destinationR.Top);
		}

		[Test]
		public void CalculateLargestSizeHavingAspect()
		{
			var size = new Size(1000, 1000);
			var targetAspect = new Fraction(1, 1); // 1:1
			var result = new Size(0, 0);

			result = VisualHelper.CalculateMaxSize(size, targetAspect);

			Assert.AreEqual(new Size(1000, 1000), result);

			// -----------------------------------------------------------------------------------------------

			targetAspect = new Fraction(2, 1); // 2:1 (width 2x height)

			result = VisualHelper.CalculateMaxSize(size, targetAspect);

			Assert.AreEqual(new Size(1000, 500), result);

			// -----------------------------------------------------------------------------------------------

			targetAspect = new Fraction(3, 1); // 3:1 (width 3x height)

			result = VisualHelper.CalculateMaxSize(size, targetAspect);

			Assert.AreEqual(new Size(1000, 333), result);  // 333.3 (round down)

			// -----------------------------------------------------------------------------------------------

			targetAspect = new Fraction(4, 1); // 3:1 (width 3x height)

			result = VisualHelper.CalculateMaxSize(size, targetAspect);

			Assert.AreEqual(new Size(1000, 250), result);  // 333.3 (round down)

			// -----------------------------------------------------------------------------------------------

			targetAspect = new Fraction(1, 2); // 1:2 (width 0.5 height)

			result = VisualHelper.CalculateMaxSize(size, targetAspect);

			Assert.AreEqual(new Size(500, 1000), result);  // 333.3 (round down)
		}
	}
}