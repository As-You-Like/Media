namespace Carbon.Media
{
	public enum ColorSpace
	{
		Unknown = 0,

		sRGB = 1,			// The sRGB color space is based on the ITU-R BT.709 standard. It specifies a gamma of 2.2 and a white point of 6500 degrees K.
		ScRGB = 2,			// scRGB is a wide color gamut RGB (Red Green Blue) color space created by Microsoft and HP that uses the same color primaries and white/black points as the sRGB color space but allows coordinates below zero and greater than one. The full range is -0.5 through just less than +7.5.
		RGB = 3,
		CMY	 = 5,			// CMY, which is not very common except on low-end color printers
		CMYK = 4,			// CMYK, which models the way inks or dyes are applied to paper in printing

		Gray = 5,			// Gray spaces typically have a single component, ranging from black to white, as shown in Figure 2-1. Gray spaces are used for black-and-white and grayscale display and printing. A properly plotted gray space should have a fifty percent value as its midpoint.
		Multichannel = 6,	// Multichannel mode images contain 256 levels of gray in each channel and are useful for specialized printing. 

		YCbCr	= 7,		// YCbr
		
		// ICC Color Profiles 
		
		HSV	= 10,
		HLS	= 11,
		Lab	= 12,	// The CIE L*a*b* color model (Lab) is based on the human perception of color. 
		Luv	= 13,

		Yxy = 14,	// Yxy space expresses the XYZ values in terms of x and y chromaticity coordinates, somewhat analogous to the hue and saturation coordinates of HSV space. The coordinates are shown in the following formulas, used to convert XYZ into Yxy:
		XYZ = 15,	// There are several CIE-based color spaces, but all are derived from the fundamental XYZ space. The XYZ space allows colors to be expressed as a mixture of the three tristimulus values X, Y, and Z. The term tristimulus comes from the fact that color perception results from the retina of the eye responding to three types of stimuli. After experimentation, the CIE set up a hypothetical set of primaries, XYZ, that correspond to the way the eye’s retina behaves.
	}

	public static class ICCColorSpace
	{
		public static ColorSpace Parse(string text)
		{
			switch (text.ToUpper())
			{
				case "XYZ"	: return ColorSpace.XYZ;
				case "LAB"	: return ColorSpace.Lab;
				case "LUV"	: return ColorSpace.Luv;
				case "YCBR"	: return ColorSpace.YCbCr;
				case "YXY"	: return ColorSpace.Yxy;
				case "RGB"	: return ColorSpace.RGB;
				case "GRAY"	: return ColorSpace.Gray;
				case "HSV"	: return ColorSpace.HSV;
				case "HLS"	: return ColorSpace.HLS;
				case "CMYK" : return ColorSpace.CMYK;
				case "CMY"	: return ColorSpace.CMY;
				default		: return ColorSpace.Unknown;

			}
		}
	}
}

/*
XYZData ‘XYZ ’ 58595A20h
labData ‘Lab ’ 4C616220h
luvData ‘Luv ’ 4C757620h
YCbCrData ‘YCbr’ 59436272h
YxyData ‘Yxy ’ 59787920h
rgbData ‘RGB ’ 52474220h
grayData ‘GRAY’ 47524159h
hsvData ‘HSV ’ 48535620h
hlsData ‘HLS ’ 484C5320h
cmykData ‘CMYK’ 434D594Bh
cmyData ‘CMY ’ 434D5920h
2colourData ‘2CLR’ 32434C52h
3colourData (if not listed above) ‘3CLR’ 33434C52h
4colourData (if not listed above) ‘4CLR’ 34434C52h
5colourData ‘5CLR’ 35434C52h
6colourData ‘6CLR’ 36434C52h
7colourData ‘7CLR’ 37434C52h
8colourData ‘8CLR’ 38434C52h
9colourData ‘9CLR’ 39434C52h
10colourData ‘ACLR’ 41434C52h
11colourData ‘BCLR’ 42434C52h
12colourData ‘CCLR’ 43434C52h
13colourData ‘DCLR’ 44434C52h
14colourData ‘ECLR’ 45434C52h
15colourData ‘FCLR’ 46434C52h
*/

// Starting with Windows 8.1, the Windows Imaging Component (WIC) JPEG codec supports reading and writing image data in its native YCbCr form
