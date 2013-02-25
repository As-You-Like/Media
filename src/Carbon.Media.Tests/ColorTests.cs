namespace Carbon.Helpers.Tests
{
	using System;
	using System.Drawing;

	using NUnit.Framework;

	[TestFixture]
	public class ColorExtensionsTests
	{
		[Test]
		public void ToHex()
		{
			Assert.AreEqual("000000", Color.Black.ToHex());
			Assert.AreEqual("FFFFFF", Color.White.ToHex());
		}
	}
}