namespace Carbon.Media
{
	using System;

	public enum PixelFormat : byte
	{	
		Unknown			= 0,

		Bgr101010		= 1,   // sRGB format with 32 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 10 bits per pixel (BPP).
		Bgr24			= 2,   // sRGB format with 24 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 8 bits per pixel (BPP).
		Bgr32			= 3,   // sRGB format with 32 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 8 bits per pixel (BPP).
		Bgr555			= 4,   // sRGB format with 16 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 5 bits per pixel (BPP).
		Bgr565			= 5,   // sRGB format with 16 bits per pixel (BPP). Each color channel (blue, green, and red) is allocated 5, 6, and 5 bits per pixel (BPP) respectively.
		Bgra32			= 6,   // sRGB format with 32 bits per pixel (BPP). Each channel (blue, green, red, and alpha) is allocated 8 bits per pixel (BPP).
		BlackWhite		= 7,   // Black and white pixel format which displays one bit of data per pixel as either black or white.
		Cmyk32			= 8,   // 32 bits per pixel (BPP) with each color channel (cyan, magenta, yellow, and black) allocated 8 bits per pixel (BPP).
		Gray16			= 9,   // 16 bits-per-pixel grayscale channel, allowing 65536 shades of gray. This format has a gamma of 1.0.
		Gray2			= 10,  // 2 bits-per-pixel grayscale channel, allowing 4 shades of gray.
		Gray32Float		= 11,  // Gray32Float displays a 32 bits per pixel (BPP) grayscale channel, allowing over 4 billion shades of gray. This format has a gamma of 1.0.
		Gray4			= 12,  // 4 bits-per-pixel grayscale channel, allowing 16 shades of gray.
		Gray8			= 13,  // 8 bits-per-pixel grayscale channel, allowing 256 shades of gray.
		Indexed1		= 14,  // Paletted bitmap with 2 colors.
		Indexed2		= 15,  // Paletted bitmap with 4 colors.
		Indexed4		= 16,  // Paletted bitmap with 16 colors.
		Indexed8		= 17,  // Paletted bitmap with 256 colors.
		Pbgra32			= 18,  // sRGB format with 32 bits per pixel (BPP). Each channel (blue, green, red, and alpha) is allocated 8 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value.
		Prgba128Float	= 19,  // ScRGB format with 128 bits per pixel (BPP). Each channel (red, green, blue, and alpha) is allocated 32 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value. This format has a gamma of 1.0.
		Prgba64			= 20,  // sRGB format with 64 bits per pixel (BPP). Each channel (blue, green, red, and alpha) is allocated 32 bits per pixel (BPP). Each color channel is pre-multiplied by the alpha value. This format has a gamma of 1.0.
		Rgb128Float		= 21,  // ScRGB format with 128 bits per pixel (BPP). Each color channel is allocated 32 BPP. This format has a gamma of 1.0.
		Rgb24			= 22,  // sRGB format with 24 bits per pixel (BPP). Each color channel (red, green, and blue) is allocated 8 bits per pixel (BPP).
		Rgb48			= 23,  // sRGB format with 48 bits per pixel (BPP). Each color channel (red, green, and blue) is allocated 16 bits per pixel (BPP). This format has a gamma of 1.0.
		Rgba128Float	= 24,  // ScRGB format with 128 bits per pixel (BPP). Each color channel is allocated 32 bits per pixel (BPP). This format has a gamma of 1.0.
		Rgba64			= 25,  // sRGB format with 64 bits per pixel (BPP). Each channel (red, green, blue, and alpha) is allocated 16 bits per pixel (BPP). This format has a gamma of 1.0.				  
	}

	public static class PixelFormatHelper
	{
		public static PixelFormat Parse(string text)
		{
			PixelFormat format;

			Enum.TryParse<PixelFormat>(text, out format);

			return format;
		}

		public static ColorSpace GetColorSpace(PixelFormat format)
		{
			switch (format)
			{
				case PixelFormat.Bgr101010		:
				case PixelFormat.Bgr24			:
				case PixelFormat.Bgr32			:
				case PixelFormat.Bgr555			:
				case PixelFormat.Bgr565			:
				case PixelFormat.Bgra32			: return ColorSpace.sRGB;
				
				case PixelFormat.BlackWhite		: return ColorSpace.Gray;

				case PixelFormat.Cmyk32			: return ColorSpace.CMYK;

				case PixelFormat.Gray16			:
				case PixelFormat.Gray2			:
				case PixelFormat.Gray32Float	:	
				case PixelFormat.Gray4			:
				case PixelFormat.Gray8			: return ColorSpace.Gray;

				case PixelFormat.Pbgra32		: return ColorSpace.sRGB;
				case PixelFormat.Prgba128Float	: return ColorSpace.scRGB;

				case PixelFormat.Rgb24			: 
				case PixelFormat.Rgb48			: return ColorSpace.sRGB;
				case PixelFormat.Rgba128Float	: return ColorSpace.scRGB;
				case PixelFormat.Rgba64			: return ColorSpace.sRGB;

				default							: return ColorSpace.Unknown;

			}
		}
	}
}