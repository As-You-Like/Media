namespace Carbon.Media.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class ResizeTests
	{
		[Test]
		public void FromFullKey()
		{
			var resize = Resize.Parse("resize:85x20");

			Assert.AreEqual(85, resize.Width);
			Assert.AreEqual(20, resize.Height);
		}

		[Test]
		public void FromPartialKey()
		{
			var resize = Resize.Parse("85x20");

			Assert.AreEqual(85, resize.Width);
			Assert.AreEqual(20, resize.Height);
		}
	}
}