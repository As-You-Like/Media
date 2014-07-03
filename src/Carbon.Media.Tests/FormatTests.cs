namespace Carbon.Helpers.Tests
{
	using NUnit.Framework;

	using Carbon.Media;

	[TestFixture]
	public class FormatTests
	{
		[Test]
		public void CompressableTests()
		{
			Assert.IsTrue(FileFormat.IsCompressible("txt"));
			Assert.IsTrue(FileFormat.IsCompressible("css"));
			Assert.IsTrue(FileFormat.IsCompressible("js"));

			Assert.IsFalse(FileFormat.IsCompressible("woff"));
			Assert.IsFalse(FileFormat.IsCompressible("jpeg"));
			Assert.IsFalse(FileFormat.IsCompressible("gif"));
		}

		[Test]
		public void FeatureTests()
		{
			Assert.AreEqual(1, (int)MediaFeatures.None);
			Assert.AreEqual(2, (int)MediaFeatures.AlphaChannel);
			Assert.AreEqual(4, (int)MediaFeatures.Animated);
			Assert.AreEqual(8, (int)MediaFeatures.ColorProfile);
			// Assert.AreEqual(1, (int)MediaFeatures.None);
			// Assert.AreEqual(1, (int)MediaFeatures.None);
		}
	}
}