namespace Carbon.Media
{
    // IS = ImageSharp
    // IM = ImageMagic

    public enum ColorSpace
    {
        Unknown	          = 0,
        
        // RGB Color Spaces ------
        sRGB               = 1,  // Based on ITU-R BT.709 standard.
        scRGB		       = 2,
        RGB	               = 3,  // FFmpeg#0, IS
        AdobeRGB           = 4,  // 
        AdobeWideGamutRGB  = 5,  //                     | Adobe Wide Gamut RGB
        // ProPhotoRGB,

        // CIE Color Spaces ------
        LAB                = 10, // ICC, IS             | Based on the human perception of color
        LUV                = 11, // IS
        UVW                = 12, //                     | 
        XYZ                = 13, // ICC                 | Mixture of tristimulus values X, Y, and Z

        // CMYK ------
        CMY	               = 20, // 
        CMYK               = 21, // IS

        // Cylindrical ------
      
        HCL	               = 40, // IM
        HCLp               = 41, // IM
        HLS	               = 42, // ICC, IS
        HSB	               = 43, // IM
        HSI	               = 44, // IM
        HSL	               = 45, // IM 
        HSV	               = 46, // ICC, IS
        HWB	               = 47, // IM
        LCHab              = 48, // IM, IS
        LCHuv              = 49, // IM, IS

        // Cinema? ------
        DciP3              = 64, //                    | DCI-P3
        Bt470              = 65, // FFmpeg#5           | BT.470
        Rec601             = 70, // IM                 | SD         | YCbCr
        Rec709             = 71, // FFmpeg#1, IM       | HD (Bt709) | RGB
        Rec2020Ncl         = 73, // FFmpeg#9           | 4K & 8K
        Rec2020Cl          = 74, // FFmpeg#10          
        Acsc               = 80, //                    | Academy Color Encoding System 
        Smpte170m          = 81, // FFmpeg#6           | SMPTE 170M
        Smpte240m          = 82, // FFmpeg#7           | SMPTE 240M
                                                        
        // YUV ------                                   
        ICtCp              = 90, // ?                   
        xvYCC              = 91, //                     | Extended-gamut YCC
        YCC                = 92, // IM
        YCbCr              = 93, // IS
        YCoCg              = 94, // 
        YDbDr              = 95, // IM
        YIQ                = 96, // IM
        YPbPr              = 97, // IM 
        YUV                = 98, // IM
        Yxy                = 99  // ICC, IS             | Expresses the XYZ values in terms of x and y chromaticity coordinates
    }
}

// https://en.wikipedia.org/wiki/List_of_color_spaces_and_their_uses