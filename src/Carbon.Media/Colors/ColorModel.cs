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

        // Monochrome?
        Grayscale = 4,

        /// <summary>
        /// Y’CbCr separate colors into a luma component (Y’) and two chroma components (Cb and Cr). 
        /// </summary>
        YCbCr = 5,

        /// <summary>
        /// CIE L*a*b*
        /// </summary>
        Lab = 6
    }

    // CIE XYZ 
}