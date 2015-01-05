namespace Carbon.Media
{
	using System;

	// Avoid conflict with System.Windows.PixelFormat

	public enum PixelFormatType : byte
	{	
		Unknown			= 0,

		Bgr101010		= 1,   // sRGB format with 32 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 10 bits per pixel (BPP).
		Bgr24			= 2,   // sRGB format with 24 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 8 bits per pixel (BPP).
		Bgr32			= 3,   // sRGB format with 32 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 8 bits per pixel (BPP).
		Bgr555			= 4,   // sRGB format with 16 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 5 bits per pixel (BPP).
		Bgr565			= 5,   // sRGB format with 16 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 5, 6, and 5 bits per pixel (BPP) respectively.	
		Bgra32			= 6,   // sRGB format with 32 bits per pixel (BPP). Each channel (blue, green, red, and alpha) is allocated 8 bits per pixel (BPP).
		Bgra555			= 7,   // Future
		
		BlackWhite		= 10,   // Black and white pixel format which displays one bit of data per pixel as either black or white.
		
		// CMYK
		Cmyk32			= 20,  // 32 bits per pixel (BPP) with each color channel (cyan, magenta, yellow, and black) allocated 8 bits per pixel (BPP).
		Cmyk64			= 21,  // Future
		CmykAlpha40		= 22,  // Future
		CmykAlpha80		= 23,  // Future

		Gray16			= 30,  // 16 bits-per-pixel grayscale channel, allowing 65536 shades of gray. This format has a gamma of 1.0.
		Gray2			= 31,  // 2 bits-per-pixel grayscale channel, allowing 4 shades of gray.
		Gray32Float		= 32,  // Gray32Float displays a 32 bits per pixel (BPP) grayscale channel, allowing over 4 billion shades of gray. This format has a gamma of 1.0.
		Gray4			= 33,  // 4 bits-per-pixel grayscale channel, allowing 16 shades of gray.
		Gray8			= 34,  // 8 bits-per-pixel grayscale channel, allowing 256 shades of gray.
		
		// Indexed Formats (30)
		Indexed1		= 40,  // Paletted bitmap with 2 colors.
		Indexed2		= 41,  // Paletted bitmap with 4 colors.
		Indexed4		= 42,  // Paletted bitmap with 16 colors.
		Indexed8		= 43,  // Paletted bitmap with 256 colors.
		
		// P?
		Pbgra32			= 50,  // sRGB format with 32 bits per pixel (BPP). Each channel (blue, green, red, and alpha) is allocated 8 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value.
		Prgba128Float	= 51,  // ScRGB format with 128 bits per pixel (BPP). Each channel (red, green, blue, and alpha) is allocated 32 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value. This format has a gamma of 1.0.
		Prgba64			= 52,  // sRGB format with 64 bits per pixel (BPP). Each channel (blue, green, red, and alpha) is allocated 32 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value. This format has a gamma of 1.0.
		
		// RGB
		Rgb128Float		= 60,  // ScRGB format with 128 bits per pixel (BPP). Each color channel is allocated 32 BPP. This format has a gamma of 1.0.
		Rgb24			= 61,  // sRGB format with 24 bits per pixel (BPP). Each color channel (red, green, and blue) is allocated 8 bits per pixel (BPP).
		Rgb48			= 62,  // sRGB format with 48 bits per pixel (BPP). Each color channel (red, green, and blue) is allocated 16 bits per pixel (BPP). This format has a gamma of 1.0.
		Rgba1010102		= 63, // Future 
		Rgba1010102XR	= 64, // Future 
		Rgba128Float	= 65, // ScRGB format with 128 bits per pixel (BPP). Each color channel is allocated 32 bits per pixel (BPP). This format has a gamma of 1.0.
		Rgba64			= 66  // sRGB format with 64 bits per pixel (BPP). Each channel (red, green, blue, and alpha) is allocated 16 bits per pixel (BPP). This format has a gamma of 1.0.				  
	}

	/*
	GUID_WICPixelFormat32bppCMYK		4	8	32	UINT
	GUID_WICPixelFormat64bppCMYK		4	16	64	UINT
	GUID_WICPixelFormat40bppCMYKAlpha	5	8	40	UINT
	GUID_WICPixelFormat80bppCMYKAlpha	5	16	80	UINT
	*/

	public struct PixelFormatInfo
	{
		private readonly int bitsPerPixel;
		private readonly ColorModel model;
		private readonly ColorChannels channels;

		public PixelFormatInfo(int bitsPerPixel, ColorModel model, ColorChannels channels)
		{
			this.bitsPerPixel = bitsPerPixel;
			this.model = model;
			this.channels = channels;
		}

		public int BitsPerPixel
		{
			get { return bitsPerPixel; }
		}

		public ColorModel ColorModel
		{
			get { return model; }
		}

		public ColorChannels Channels
		{
			get { return channels; }
		}

		/*
		Pixel formats in themselves do not have a color space. 
		Generally, color space is a semantic interpretation of the pixel values that depends on the context of the bitmap.
		Some images identify a color context that defines the color space of the image. (Using a color profile)
		Only in the absence of a color context should the color space be inferred.
		*/

		// Bits per pixel
		// Channel Count
		// etc
	}

	[Flags]
	public enum ColorChannels : byte
	{
		Unknown = 0,

		R = 1,
		G = 2,
		B = 4,
		A = 8,
		C = 16,		// cyan
		M = 32,		// magenta
		Y = 64,		// yellow
		K = 128,	// key (black)

		RGB = R | G | B,
		RGBA = R | G | B | A,
		CMYK = C | M | Y | K,
		CMYKA = C | M | Y | K | A
	}

	public static class PixelFormatHelper
	{
		public static PixelFormatType Parse(string text)
		{
			PixelFormatType format;

			Enum.TryParse<PixelFormatType>(text, out format);

			return format;
		}

		public static PixelFormatInfo GetInfo(this PixelFormatType format)
		{
			switch (format)
			{
				case PixelFormatType.Bgr101010		: return new PixelFormatInfo(10, ColorModel.RGB, ColorChannels.RGB);
				case PixelFormatType.Bgr24			: return new PixelFormatInfo(8,  ColorModel.RGB, ColorChannels.RGB);
				case PixelFormatType.Bgr32			: return new PixelFormatInfo(8,  ColorModel.RGB, ColorChannels.RGB);		
				case PixelFormatType.Bgr555			: return new PixelFormatInfo(5,  ColorModel.RGB, ColorChannels.RGB);
				case PixelFormatType.Bgr565			: return new PixelFormatInfo(5,  ColorModel.RGB, ColorChannels.RGB);
				case PixelFormatType.Bgra32			: return new PixelFormatInfo(8,  ColorModel.RGB, ColorChannels.RGBA);

				case PixelFormatType.BlackWhite		: return new PixelFormatInfo(1,  ColorModel.Grayscale, ColorChannels.K);

				case PixelFormatType.Cmyk32			: return new PixelFormatInfo(8,  ColorModel.CMYK, ColorChannels.CMYK);
				case PixelFormatType.Cmyk64			: return new PixelFormatInfo(16, ColorModel.CMYK, ColorChannels.CMYK);
				case PixelFormatType.CmykAlpha40	: return new PixelFormatInfo(8,  ColorModel.CMYK, ColorChannels.CMYKA);
				case PixelFormatType.CmykAlpha80	: return new PixelFormatInfo(16, ColorModel.CMYK, ColorChannels.CMYKA);

				case PixelFormatType.Gray2			: return new PixelFormatInfo(2,  ColorModel.Grayscale, ColorChannels.K);
				case PixelFormatType.Gray4			: return new PixelFormatInfo(4,  ColorModel.Grayscale, ColorChannels.K);
				case PixelFormatType.Gray8			: return new PixelFormatInfo(8,  ColorModel.Grayscale, ColorChannels.K);
				case PixelFormatType.Gray16			: return new PixelFormatInfo(16, ColorModel.Grayscale, ColorChannels.K);
				case PixelFormatType.Gray32Float	: return new PixelFormatInfo(32, ColorModel.Grayscale, ColorChannels.K);

				case PixelFormatType.Pbgra32		: return new PixelFormatInfo(8,  ColorModel.RGB, ColorChannels.RGBA);
				case PixelFormatType.Prgba128Float	: return new PixelFormatInfo(32, ColorModel.RGB, ColorChannels.RGBA);

				case PixelFormatType.Rgb24			: return new PixelFormatInfo(8 , ColorModel.RGB, ColorChannels.RGB);
				case PixelFormatType.Rgb48			: return new PixelFormatInfo(16, ColorModel.RGB, ColorChannels.RGB);
				case PixelFormatType.Rgba128Float	: return new PixelFormatInfo(32, ColorModel.RGB, ColorChannels.RGBA);
				case PixelFormatType.Rgba64			: return new PixelFormatInfo(16, ColorModel.RGB, ColorChannels.RGBA);

				default: return default(PixelFormatInfo);
			}
		}
	}
}