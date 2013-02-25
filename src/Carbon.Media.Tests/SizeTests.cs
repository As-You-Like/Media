namespace Carbon.Helpers.Tests
{
	using System.Drawing;

	using NUnit.Framework;

	[TestFixture]
	public class SizeExtensionTests
	{
		[Test]
		public void WithinTests()
		{
			Assert.IsTrue(new Size(50, 50).FitsIn(new Size(50, 50)));
			Assert.IsTrue(new Size(50, 55).FitsIn(new Size(50, 55)));
			Assert.IsTrue(new Size(55, 50).FitsIn(new Size(55, 50)));
			Assert.IsTrue(new Size(50, 50).FitsIn(new Size(100, 100)));

			Assert.IsFalse(new Size(50, 50).FitsIn(new Size(50, 49)));
			Assert.IsFalse(new Size(50, 50).FitsIn(new Size(49, 50)));
			Assert.IsFalse(new Size(51, 50).FitsIn(new Size(50, 50)));
			Assert.IsFalse(new Size(50, 51).FitsIn(new Size(50, 50)));
		}
	}
}