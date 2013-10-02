namespace Carbon.Helpers.Tests
{
	using System.Drawing;

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
	}
}