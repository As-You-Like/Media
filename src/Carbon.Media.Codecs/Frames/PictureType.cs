namespace Carbon.Media
{
    public enum PictureType : byte
    {  
        None = 0,
        I    = 1, // Intra
        P    = 2, // Predicted
        B    = 3, // Bipredictive
        S    = 4,
        SI   = 5, // Switching I
        SP   = 6, // Switching P
        BI   = 7  // BiType
    }
}




// https://en.wikipedia.org/wiki/Video_compression_picture_types