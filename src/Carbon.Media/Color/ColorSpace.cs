namespace Carbon.Media
{
    public enum ColorSpace
    {                                                                                                                
        Unknown = 0, 
        //                                                                      | ICC  | FFMPEG | CSS |
                                                                                       
        // RGB Color Spaces ------                                              |      |   x    |     |
        sRGB               = 1,  // IEC 61966-2-1                               |      |        |  x* |
        scRGB		       = 2,  //                                             |      |        |     |
        RGB	               = 3,  //                                             |      |        |  x  |
        AdobeRGB           = 4,  //                                             |      |        |     |
        AdobeWideGamutRGB  = 5,  // Adobe Wide Gamut RGB                        |      |        |     |
        
        // -- Grayscale -------------
        Gray               = 7, //                                              |  x   |        |     |

        // CIE Color Spaces ------                                              |      |        |     |
        LAB                = 10, // CIE L*a*b*                                  |  x   |        |  x  |
        LUV                = 11, //                                             |  x   |        |     |
        UVW                = 12, //                     |                       |      |        |     |
        XYZ                = 13, // Mixture of tristimulus values X, Y, and Z   |  x   |        |     |
                                                                                       
        // CMYK ------                                                          |      |        |     |
        CMY	               = 20, //                                             |  x   |        |     |
        CMYK               = 21, //                                             |  x   |        |     |
                                                                                       
        // Cylindrical ------                                                   |      |        |     |
        HCL	               = 40, //                                             |      |        |     |
        HCLp               = 41, //                                             |      |        |     |
        HLS	               = 42, //                                             |  x   |        |     |
        HSB	               = 43, //                                             |      |        |     |
        HSI	               = 44, //                                             |      |        |     |
        HSL	               = 45, //                                             |      |        |  x  |
        HSV	               = 46, //                                             |  x   |        |     |
        HWB	               = 47, //                                             |      |        |  x  |
        LCHab              = 48, //                                             |      |        |     |
        LCHuv              = 49, //                                             |      |        |     |
                                                                                       
        // Cinema? ------                                                       |      |        |     |
        DciP3              = 64, // DCI-P3                                      |      |        |  x  |
        Bt470              = 65, // BT.470                                      |      |   x    |     |
        Rec601             = 70, // SD         | YCbCr                          |      |        |     |
        Rec709             = 71, // HD (Bt709) | RGB                            |      |   x    |     |
        Rec2020Ncl         = 73, // 4K & 8K                                     |      |   x    |     |
        Rec2020Cl          = 74, // ITU-R BT2020 constant luminance system      |      |   x    |  x  |
                                                                                       
        Smpte170m          = 81, // SMPTE 170M                                  |      |   x    |     |
        Smpte240m          = 82, // SMPTE 240M                                  |      |   x    |     |
        Smpte2085          = 83, // Y'D'zD'x                                    |      |   x    |     |
                                                                                       
        // YUV ------                                                           |      |        |     |
        ICtCp              = 90, //                                             |      |        |     |
        xvYCC              = 91, // Extended-gamut YCC                          |      |        |     |
        YCC                = 92, //                                             |      |        |     |
        YCbCr              = 93, //                                             | YCbr |        |     |
        YCoCg              = 94, //                                             |      |        |     |
        YDbDr              = 95, //                                             |      |        |     |
        YIQ                = 96, //                                             |      |        |     |
        YPbPr              = 97, //                                             |      |        |     |
        YUV                = 98, //                                             |      |        |     |
        Yxy                = 99  //                                             |  x   |        |     |
    }                                                                                        
}

// https://en.wikipedia.org/wiki/List_of_color_spaces_and_their_uses

// https://drafts.csswg.org/css-color/#predefined

// BT709      | ITU-R BT1361 / IEC 61966-2-4 xvYCC709 / SMPTE RP177 Annex B
// BT.470     | ITU-R BT601-6 625 / ITU-R BT1358 625 / ITU-R BT1700 625 PAL & SECAM / IEC 61966-2-4 xvYCC601
// SMPTE 170M | ITU-R BT601-6 525 / ITU-R BT1358 525 / ITU-R BT1700 NTSC)