namespace Carbon.Helpers.Tests
{
	using Xunit;

	using Carbon.Media;
	
	public class FormatTests
	{
		[Fact]
		public void FromPath()
		{
			Assert.Equal("pdf", FileFormat.FromPath("holiday_gift_center_1998.pdf"));
		}

		
		[Fact]
		public void CompressableTests()
		{
			Assert.True(FileFormat.IsCompressible("txt"));
			Assert.True(FileFormat.IsCompressible("css"));
			Assert.True(FileFormat.IsCompressible("js"));

			Assert.False(FileFormat.IsCompressible("woff"));
			Assert.False(FileFormat.IsCompressible("jpeg"));
			Assert.False(FileFormat.IsCompressible("gif"));
		}

		[Fact]
		public void ColorChannelTests()
		{
			Assert.Equal(1,	(int)ColorChannels.R);
			Assert.Equal(2,	(int)ColorChannels.G);
			Assert.Equal(4,	(int)ColorChannels.B);
			Assert.Equal(8,	(int)ColorChannels.A);

			Assert.Equal(16,  (int)ColorChannels.C);
			Assert.Equal(32,  (int)ColorChannels.M);
			Assert.Equal(64,  (int)ColorChannels.Y);
			Assert.Equal(128, (int)ColorChannels.K);

			Assert.Equal(7,	 (int)ColorChannels.RGB);
			Assert.Equal(15, (int)ColorChannels.RGBA);
			Assert.Equal(240, (int)ColorChannels.CMYK);	
		}

		[Fact]
		public void PixelFormatTests()
		{
			var bw = PixelFormatType.BlackWhite.GetInfo();

			Assert.Equal(1,						bw.BitsPerPixel);
			Assert.Equal(ColorChannels.K,		bw.Channels);
			Assert.Equal(ColorModel.Grayscale,	bw.ColorModel);

			Assert.Equal(10, (int)PixelFormatType.BlackWhite);
			Assert.Equal(20, (int)PixelFormatType.Cmyk32);

			var rgb24 = PixelFormatType.Rgb24.GetInfo();

			Assert.Equal(8,					rgb24.BitsPerPixel);
			Assert.Equal(ColorChannels.RGB,	rgb24.Channels);
			Assert.Equal(ColorModel.RGB,		rgb24.ColorModel);

			var rgba64 = PixelFormatType.Rgba64.GetInfo();

			Assert.Equal(16,					rgba64.BitsPerPixel);
			Assert.Equal(ColorChannels.RGBA, rgba64.Channels);
			Assert.Equal(ColorModel.RGB, rgba64.ColorModel);
		}

		/*
		[Fact]
		public void FeatureTests()
		{
			Assert.Equal(1, (int)MediaFlags.None);
			Assert.Equal(2, (int)MediaFlags.AlphaChannel);
			Assert.Equal(4, (int)MediaFlags.Animated);
			Assert.Equal(8, (int)MediaFlags.ColorProfile);

			Assert.Equal(32, (int)MediaFlags.CMYK);
			// Assert.Equal(1, (int)MediaFeatures.None);
			// Assert.Equal(1, (int)MediaFeatures.None);
		}
		*/
	}
}