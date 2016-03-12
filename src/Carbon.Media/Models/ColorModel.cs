namespace Carbon.Media
{
    public enum ColorModel
    {
        Unknown = 0,

        RGB = 1,

        /// <summary>
        /// CMYK is a subtractive color model that is used in printing. 
        /// </summary>
        CMYK = 2,

        /// <summary>
        /// Indexed formats use a table of colors, called a palette. 
        /// </summary>
        Indexed = 3,

        Grayscale = 4,

        /// <summary>
        /// Y’CbCr separate colors into a luma component (Y’) and two chroma components (Cb and Cr). 
        /// Many JPEG files natively store image data using the Y’CbCr color model.
        /// </summary>
        YCbCr = 5
    }
}

/*
RGB/BGR Color Model
CMYK Color Model
n-channel Color Model
Indexed and Grayscale Color Models
Y’CbCr Color Model
*/


// The human visual system is less sensitive to changes in chroma than to luma,
// and Y’CbCr formats can take advantage of this reduced sensitivity by reducing 
// the amount of chroma data that is stored relative to luma. 
// They accomplish this by storing chroma and luma into separate planes and scaling
// each component plane to a different resolution. 
// This practice is known as chroma subsampling.
