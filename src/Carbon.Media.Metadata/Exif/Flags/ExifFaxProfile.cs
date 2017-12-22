namespace Carbon.Media.Metadata
{
    public enum ExifFaxProfile
    {
        Unknown = 0,
        S       = 1, // Minimal b&w lossless
        F       = 2, // Extended b&w lossless
        J       = 3, // Lossless JBIG b&w
        C       = 4, // Lossy color & grayscale
        L       = 5, // Lossless color & grayscale
        M       = 6, // Mixed raster content
    }

}
