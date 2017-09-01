namespace Carbon.Media
{
    public enum ColorModel
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

        Grayscale = 4,

        /// <summary>
        /// Y’CbCr separate colors into a luma component (Y’) and two chroma components (Cb and Cr). 
        /// </summary>
        YCbCr = 5
    }
}