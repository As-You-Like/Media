namespace Carbon.Media.Tests
{
	using System;
	using System.Drawing.Imaging;

	using NUnit.Framework;

	[TestFixture]
	public class AnchoredResizeTests
	{
		[Test]
		public void FromFullKey()
		{
			var resize = AnchoredResize.ParseKey("resize:85x20-c");

			Assert.AreEqual(85, resize.Width);
			Assert.AreEqual(20, resize.Height);
			Assert.AreEqual(Alignment.Center, resize.Anchor);
		}

		[Test]
		public void FromPartialKey()
		{
			var resize = AnchoredResize.ParseKey("85x20-l");

			Assert.AreEqual(85, resize.Width);
			Assert.AreEqual(20, resize.Height);
			Assert.AreEqual(Alignment.Left, resize.Anchor);
		}
	}
}