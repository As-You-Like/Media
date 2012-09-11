namespace Carbon.Media.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class RotateTests
	{
		[Test]
		public void FromFullKey()
		{
			var rotate = Rotate.Parse("360");

			Assert.AreEqual(360, rotate.Angle);
		}

		[Test]
		public void FromPartialKey()
		{
			var rotate = Rotate.Parse("rotate(360)");

			Assert.AreEqual(360, rotate.Angle);
		}
	}
}