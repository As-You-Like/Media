namespace Carbon.Media
{
    public enum ColorModel : byte
    {
        Unknown = 0,

        RGB = 1,

        /// <summary>
        /// CMYK is a subtractive color model used in printing. 
        /// </summary>
        CMYK = 2,

        /// <summary>
        /// Indexed formats use a table of colors, called a palette.
        /// </summary>
        Indexed = 3,

        /// <summary>
        /// Shades of a single color, typically black (grayscale)
        /// </summary>
        Monochrome = 4,

        /// <summary>
        /// Luma-Chrome System 
        /// </summary>
        YUV = 5,

        /// <summary>
        /// Y’CbCr separate colors into a luma component (Y’) and two chroma components (Cb/U and Cr/V).
        /// Scaled and offset YUV?
        /// </summary>
        YcbCr = YUV,

        /// <summary>
        /// CIE L*a*b*
        /// </summary>
        Lab = 6,

        Luv = 7
    }

    // YCC?
    // YCoCg
    // HSV
    // HLS
    // XYZ
    // LUV
    // LAB
    // CIE XYZ 
}