namespace Carbon.Media
{
	public enum MediaCodecType
	{
		Unknown = 0,

		// -------------------- Audio Codecs (200-299) ---------------------------------------

		/// <summary>
		/// Advanced Audio Coding, MPEG-4 AAC
		/// Container: mpeg4
		/// Mime: audio/x-m4a
		/// </summary>
		Aac = 200,

		/// <summary>
		/// Audio Codec 3 
		/// Creator: Dolby Laboratories
		/// </summary>
		Ac3 = 205,

		/// <summary>
		/// Audio Interchange File Format 
		/// Container: aiff
		/// Mime: audio/aiff
		/// </summary>
		Aiff = 210,

		/// <summary>
		/// Apple Lossless
		/// Creator: Apple Inc.
		/// Extension: .m4a
		/// </summary>
		Alac = 215,

		/// <summary>
		/// Free Lossless Audio Codec
		/// Creator: Xiph Foundation
		/// </summary>
		Flac = 220,

		/// <summary>
		/// MPEG-1 Audio Layer 3
		/// Extension: .mp3
		/// Mime: audio/mpeg
		/// </summary>
		Mp3 = 230,

		/// <summary>
		/// Reserved
		/// </summary>
		Opus = 240,

		Pcm = 250,

		/// <summary>
		/// Vorbis
		/// Mimes: audio/ogg, audio/vorbis
		/// </summary>
		Vorbis = 260,

		/// <summary>
		/// Container: wav
		/// Mime: audio/wav
		/// </summary>
		Wav = 270,

		/// <summary>
		/// Windows Media Audio
		/// Creator: Microsoft
		/// Supported Containers: asf
		///  Mime: audio/x-ms-wma
		/// </summary>
		Wma = 280,

		// -------------------- Image Codecs (400-499) ---------------------------------------

		Bmp = 400,
		
		Gif = 410,

		Ico = 420,

		Jpeg = 430,

		Jpeg2000 = 431,
	
		Jxr = 432,

		Png = 440,

		Tiff = 450,

		WebP = 460,

		// -------------------- Video Codecs (900-999)  ---------------------------------------
		
		H261 = 901,
		H262 = 902,
		H263 = 903,		// MPEG-3
		H264 = 904,		// MPEG-4
		H265 = 905,		// Reserved

		Theora = 910,	// Derived from On2's VP3 Codec.

		Vc1 = 920,		// Windows Media Video V9

		Vp6E = 934,
		Vp6S = 935,
		Vp6 = 936,		// TrueMotion VP6
		Vp7 = 937,
		Vp8 = 938,		// libvpx (used in WebM)

		Wmv7 = 947,
		Wmv8 = 948,
		Wmv9 = 949
	}
}
