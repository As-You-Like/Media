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
		public void ColorChannelTests()
		{
			Assert.AreEqual(1,	(int)ColorChannels.R);
			Assert.AreEqual(2,	(int)ColorChannels.G);
			Assert.AreEqual(4,	(int)ColorChannels.B);
			Assert.AreEqual(8,	(int)ColorChannels.A);

			Assert.AreEqual(16,  (int)ColorChannels.C);
			Assert.AreEqual(32,  (int)ColorChannels.M);
			Assert.AreEqual(64,  (int)ColorChannels.Y);
			Assert.AreEqual(128, (int)ColorChannels.K);

			Assert.AreEqual(7,	 (int)ColorChannels.RGB);
			Assert.AreEqual(15,	 (int)ColorChannels.RGBA);
			Assert.AreEqual(240, (int)ColorChannels.CMYK);	
		}

		[Test]
		public void PixelFormatTests()
		{
			var bw = PixelFormatType.BlackWhite.GetInfo();

			Assert.AreEqual(1,						bw.BitsPerPixel);
			Assert.AreEqual(ColorChannels.K,		bw.Channels);
			Assert.AreEqual(ColorModel.Grayscale,	bw.ColorModel);

			Assert.AreEqual(10, (int)PixelFormatType.BlackWhite);
			Assert.AreEqual(20, (int)PixelFormatType.Cmyk32);

			var rgb24 = PixelFormatType.Rgb24.GetInfo();

			Assert.AreEqual(8,					rgb24.BitsPerPixel);
			Assert.AreEqual(ColorChannels.RGB,	rgb24.Channels);
			Assert.AreEqual(ColorModel.RGB,		rgb24.ColorModel);

			var rgba64 = PixelFormatType.Rgba64.GetInfo();

			Assert.AreEqual(16,					rgba64.BitsPerPixel);
			Assert.AreEqual(ColorChannels.RGBA, rgba64.Channels);
			Assert.AreEqual(ColorModel.RGB, rgba64.ColorModel);
		}

		/*
		[Test]
		public void FeatureTests()
		{
			Assert.AreEqual(1, (int)MediaFlags.None);
			Assert.AreEqual(2, (int)MediaFlags.AlphaChannel);
			Assert.AreEqual(4, (int)MediaFlags.Animated);
			Assert.AreEqual(8, (int)MediaFlags.ColorProfile);

			Assert.AreEqual(32, (int)MediaFlags.CMYK);
			// Assert.AreEqual(1, (int)MediaFeatures.None);
			// Assert.AreEqual(1, (int)MediaFeatures.None);
		}
		*/
	}
}