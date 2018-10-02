namespace Carbon.Media.Metadata.Exif
{
	public enum ExifCompression
	{
		None         = 1, // Uncompressed
		CCITT        = 2, // CCITT.T3       |  modified Huffman RLE (CCITTRLE) 
        CCITTFAX3    = 3, // CCITT.T4
        CCITTFAX4    = 4, // CCITT.T6
        CCITT_T6     = 4,
		LZW          = 5, // LZW
        Ojpeg        = 6, // JPEG
        Jpeg         = 7,
        AdobeDeflate = 8,
        JBIGBW       = 9,
        JBIGColor    = 10,
		Next         = 32766,
        EpsonErf     = 32769,
        CCITTRLEW    = 32771,
		PackBits     = 32773, // PackBits
        Thunderscan  = 32809,
		IT8CTPAD     = 32895,
		IT8LW        = 32896,
		IT8MP        = 32897,
		IT8BL        = 32898,
		PixarFilm    = 32908,
		PixarLog     = 32909,
		Deflate      = 32946,
		Dcs          = 32947,
		JBIG         = 34661,
		SGILOG       = 34676,
		SGILOG24     = 34677,
		Jpeg2000     = 34712,
        NikonDcr     = 34713,
        KodakDcr     = 65000,
        PentaxPef    = 65535
    }
}