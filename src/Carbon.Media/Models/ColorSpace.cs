namespace Carbon.Media
{
	public enum ColorSpace : byte
	{
		Unknown		= 0,

		// RGB
		sRGB		= 1,	// The sRGB color space is based on the ITU-R BT.709 standard. It specifies a gamma of 2.2 and a white point of 6500 degrees K.
		scRGB		= 2,	// scRGB is a wide color gamut RGB (Red Green Blue) color space created by Microsoft and HP that uses the same color primaries and white/black points as the sRGB color space but allows coordinates below zero and greater than one. The full range is -0.5 through just less than +7.5.
		RGB			= 3,

		CMY			= 10,	// CMY,		uncommon expect on low-end color printers
		CMYK		= 11,	// CMYK,	which models the way inks or dyes are applied to paper in printing

		Gray		= 20,	// Gray spaces are used for black-and-white and grayscale display and printing. A properly plotted gray space should have a fifty percent value as its midpoint.
		
		HCL			= 30,	// *IM			http://bl.ocks.org/mbostock/3014589
		HCLp		= 31,	// *IM
		HLS			= 32,	// ICC
		HSB			= 33,	// *IM
		HSI			= 34,   // *IM
		HSL			= 35,	// *IM
		HSV			= 36,	// ICC
		HWB			= 37,	// *IM

		Lab			= 40,	// ICC		The CIE L*a*b* color model (Lab) is based on the human perception of color. 
		LCHab		= 41,	// *IM
		LCHuv		= 41,	// *IM
		LMS			= 42,	// *IM
		Log			= 43,	// *IM
		Luv			= 44,

		Multichannel = 50,	// Multichannel mode images contain 256 levels of gray in each channel and are useful for specialized printing. 

		OHTA		= 60,	// IM*

		Rec601YCbCr = 70,	// *IM
		Rec709YCbCr = 71,	// *IM

		Transparent	= 80,	// *IM

		YCbCr		= 90,	// YCbr
		YCC			= 91,	// *IM
		YIQ			= 92,	// *IM
		YDbDr		= 93,	// *IM
		YPbPr		= 94,	// *IM 
		YUV			= 95,	// *IM
		Yxy			= 96,	// ICC		Yxy space expresses the XYZ values in terms of x and y chromaticity coordinates, somewhat analogous to the hue and saturation coordinates of HSV space. The coordinates are shown in the following formulas, used to convert XYZ into Yxy:
		XYZ			= 97	// ICC		XYZ space allows colors to be expressed as a mixture of the three tristimulus values X, Y, and Z. The term tristimulus comes from the fact that color perception results from the retina of the eye responding to three types of stimuli. After experimentation, the CIE set up a hypothetical set of primaries, XYZ, that correspond to the way the eye’s retina behaves.
	}


	public static class ICCColorSpace
	{
		public static ColorSpace Parse(string text)
		{
			switch (text.ToUpper())
			{
				case "CMY"  : return ColorSpace.CMY;
				case "CMYK" : return ColorSpace.CMYK;
				case "GRAY" : return ColorSpace.Gray;
				case "LAB"	: return ColorSpace.Lab;
				case "LUV"	: return ColorSpace.Luv;
				case "HSV"	: return ColorSpace.HSV;
				case "HLS"	: return ColorSpace.HLS;
				case "RGB"	: return ColorSpace.RGB;
				case "YCBR" : return ColorSpace.YCbCr;
				case "YXY"  : return ColorSpace.Yxy;
				case "XYZ"	: return ColorSpace.XYZ;
				default		: return ColorSpace.Unknown;

			}
		}
	}
}


// In the absence of color space information for an image, the general rule for color space inference is that UINT RGB and grayscale formats use the standard RGB color space (sRGB), 
// while fixed-point and floating-point RGB and grayscale formats use the extended RGB color space (scRGB). The CMYK color model uses an RWOP color space.

/* Image Magic Color Spaces
   CMY*         CMYK*        Gray*        HCL*
   HCLp*        HSB*         HSI*         HSL*
   HSV*         HWB*         Lab*         LCHab*
   LCHuv        LMS*         Log*         Luv*
   OHTA*        Rec601YCbCr  Rec709YCbCr* RGB*
   scRGB*		sRGB*        Transparent* XYZ*
   YCbCr*       YCC*         YDbDr*       YIQ*
   YPbPr*       YUV*
*/

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
