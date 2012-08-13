namespace Carbon.Media.Tests
{
	using System;
	using System.Drawing.Imaging;

	using NUnit.Framework;

	[TestFixture]
	public class CropTests
	{
		[Test]
		public void FromFullKey()
		{
			var crop = Crop.ParseKey("crop:10-0_85x20");

			Assert.AreEqual(10, crop.Rectangle.X);
			Assert.AreEqual(0, crop.Rectangle.Y);
			Assert.AreEqual(85, crop.Rectangle.Width);
			Assert.AreEqual(20, crop.Rectangle.Height);
		}

		[Test]
		public void FromPartialKey()
		{
			var crop = Crop.ParseKey("0-0_85x20");

			Assert.AreEqual(0, crop.Rectangle.X);
			Assert.AreEqual(0, crop.Rectangle.Y);
			Assert.AreEqual(85, crop.Rectangle.Width);
			Assert.AreEqual(20, crop.Rectangle.Height);
		}
	}
}