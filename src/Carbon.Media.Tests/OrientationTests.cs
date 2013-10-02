namespace Carbon.Media.Tests
{
	using System;

	using NUnit.Framework;

	[TestFixture]
	public class OrientationTests
	{
		[Test]
		public void OrientationParse()
		{
			var orientation = (MediaOrientation)Enum.Parse(typeof(MediaOrientation), "1");

			Assert.AreEqual(MediaOrientation.Horizontal, orientation);
			Assert.AreEqual(MediaOrientation.Horizontal, OrientationHelper.Parse("1"));
		}
	}
}
