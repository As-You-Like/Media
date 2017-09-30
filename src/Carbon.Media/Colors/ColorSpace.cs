namespace Carbon.Media
{
    public enum ColorSpace
    {
        Unknown	          = 0,
        
        /// <summary>
        /// The sRGB color space is based on the ITU-R BT.709 standard.
        /// It specifies a gamma of 2.2 and a white point of 6500 degrees K.
        /// </summary>
        sRGB              = 1,  
        
        /// <summary>
        /// scRGB is a wide color gamut RGB (Red Green Blue) color space created  by Microsoft 
        /// and HP that uses the same color primaries and white/black points as the sRGB color space 
        /// but allows coordinates below zero and greater than one. 
        /// The full range is -0.5 through just less than +7.5.
        /// </summary>
        scRGB		       = 2,
        
        RGB	               = 3,  //     | FFmpeg#0 | ImageSharp
        AdobeRGB           = 4,  // 
        AdobeWideGamutRGB  = 5,  //                                | Adobe Wide Gamut RGB

        CMY	               = 10, // 
        CMYK               = 11, //     | ImageSharp
        Gray               = 20,
        HCL	               = 30, //     | IM
        HCLp               = 31, //     | IM
        HLS	               = 32, // ICC | ImageSharp
        HSB	               = 33, //     | IM
        HSI	               = 34, //     | IM
        HSL	               = 35, //     | IM 
        HSV	               = 36, // ICC | ImageSharp
        HWB	               = 37, //     | IM
        
        // CIE Color Spaces
        Lab                = 40, // ICC | ImageSharp     | CIE L*a*b* color model (Lab) is based on the human perception of color
        Luv                = 41, //     | ImageSharp
        Uvw                = 42, //                      | CIE U*V*W*
        XYZ                = 43, // ICC |                | Expresses colors as mixture of the three tristimulus values X, Y, and Z. 
        
        // CieChAb 
        // CieChUv
        
        ICtCp              = 49, // 
        LCHab              = 50, //     | IM, ImageSharp
        LCHuv              = 51, //     | IM, ImageSharp
        LMS	               = 52, //     | IM
        Log	               = 53, //     | IM
                
        OHTA		       = 60, //     | IM
        
        DciP3              = 64, //                       | DCI-P3
        Bt470              = 65, //     | FFmpeg#5        | BT.470
        Rec601             = 70, //     | IM              | SD         | YCbCr
        Rec709             = 71, //     | FFmpeg#1, IM    | HD (Bt709) | YCbCr
        Rec2020Ncl         = 73, //     | FFmpeg#9        | 4K & 8K
        Rec2020Cl          = 74, //     | FFmpeg#10
        Acsc               = 80, //     |                 | Academy Color Encoding System 
        Smpte170m          = 78, //     | FFmpeg#6        | SMPTE 170M
        Smpte240m          = 79, //     | FFmpeg#7        | SMPTE 240M

        // Luma plus chroma/chrominance
        YCbCr              = 90, //     | ImageSharp
        YCoCg              = 91, // 
        YCC                = 92, //     | IM
        YIQ                = 93, //     | IM
        YDbDr              = 94, //     | IM
        YPbPr              = 95, //     | IM 
        YUV                = 96, //     | IM
        Yxy                = 97, // ICC | ImageSharp     | Yxy space expresses the XYZ values in terms of x and y chromaticity coordinates, somewhat analogous to the hue and saturation coordinates of HSV space. 
        xvYCC              = 110 //                      | Extended-gamut YCC
    }
}

// https://en.wikipedia.org/wiki/List_of_color_spaces_and_their_uses