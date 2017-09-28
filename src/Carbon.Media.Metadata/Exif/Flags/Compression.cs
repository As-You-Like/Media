namespace Carbon.Media.Metadata
{
	public enum Compression
	{
		None         = 1,
		CCITT        = 2, // CCITT modified Huffman RLE (CCITTRLE)
		CCITTFAX3    = 3,
		CCITTFAX4    = 4,
		CCITT_T6     = 4,
		LZW          = 5,
		Ojpeg        = 6,
		Jpeg         = 7,
		Next         = 32766,
		CCITTRLEW    = 32771,
		PackBits     = 32773,
		THUNDERSCAN  = 32809,
		IT8CTPAD     = 32895,
		IT8LW        = 32896,
		IT8MP        = 32897,
		IT8BL        = 32898,
		PixarFilm    = 32908,
		PixarLog     = 32909,
		Deflate      = 32946,
		AdobeDeflate = 8,
		Dcs          = 32947,
		Jbig         = 34661,
		SGILOG       = 34676,
		SGILOG24     = 34677,
		Jp2000       = 34712,
	}
}