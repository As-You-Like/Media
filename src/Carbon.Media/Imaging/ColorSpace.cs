namespace Carbon.Media
{
	public enum ColorSpace
	{
		Unknown	= 0,

        /// <summary>
        /// The sRGB color space is based on the ITU-R BT.709 standard.
        /// It specifies a gamma of 2.2 and a white point of 6500 degrees K.
        /// </summary>
        sRGB = 1,  
		
		/// <summary>
		/// scRGB is a wide color gamut RGB (Red Green Blue) color space created  by Microsoft 
		/// and HP that uses the same color primaries and white/black points as the sRGB color space 
		/// but allows coordinates below zero and greater than one. 
		/// The full range is -0.5 through just less than +7.5.
		/// </summary>
		scRGB		    = 2,

		RGB			    = 3,  // RGB         ffmpeg#0
		CMY			    = 10, // CMY
		CMYK		    = 11, // CMYK
		Gray		    = 20,
		HCL			    = 30, // *IM			http://bl.ocks.org/mbostock/3014589
		HCLp		    = 31, // *IM
		HLS			    = 32, // ICC
		HSB			    = 33, // *IM
		HSI			    = 34, // *IM
		HSL			    = 35, // *IM
		HSV			    = 36, // ICC
		HWB			    = 37, // *IM
                              
		Lab			    = 40, // ICC    | The CIE L*a*b* color model (Lab) is based on the human perception of color
		LCHab		    = 41, // *IM
		LCHuv		    = 41, // *IM
		LMS			    = 42, // *IM
		Log			    = 43, // *IM
		Luv			    = 44,

		Multichannel    = 50,

		OHTA		    = 60, //        | IM
                                
        Bt470bg         = 65, //        | ffmpeg#5
        Rec601_YCbCr    = 70, //        | IM                      | SD
		Rec709_YCbCr    = 71, //        | IM, ffmpeg#1 (Bt709)    | HD
        Rec2020_Ncl      = 73, //        | ffmpeg#9                | 4K & 8K
        Rec2020_Cl       = 74, //        | ffmpeg#10

        Smpte170m       = 78, //        | ffmpeg#6
        Smpte240m       = 79, //        | ffmpeg#7
        

        Transparent	    = 80, // *IM

		YCbCr		    = 90, // YCbr
        // YCoCg        = 90, // 
        YCC			    = 91, // *IM
		YIQ			    = 92, // *IM
		YDbDr		    = 93, // *IM
		YPbPr		    = 94, // *IM 
		YUV			    = 95, // *IM
		Yxy			    = 96, // ICC | Yxy space expresses the XYZ values in terms of x and y chromaticity coordinates, somewhat analogous to the hue and saturation coordinates of HSV space. 
		XYZ			    = 97, // ICC | XYZ space allows colors to be expressed as a mixture of the three tristimulus values X, Y, and Z. The term tristimulus comes from the fact that color perception results from the retina of the eye responding to three types of stimuli. After experimentation, the CIE set up a hypothetical set of primaries, XYZ, that correspond to the way the eye’s retina behaves.
    }
}
