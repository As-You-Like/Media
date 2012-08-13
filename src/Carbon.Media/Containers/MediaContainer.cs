namespace Carbon.Media
{
	public enum MediaContainer
	{
		/// <summary>
		/// Advanced Systems Format
		/// Creator: Microsoft
		/// Extensions: .asf, .wma (audio), .wmv (video)
		/// Media types: audio,video
		/// </summary>
		Asf = 1,

		/// <summary>
		/// Audio Video Interleave 
		/// Creator: Microsoft
		/// Extension : .avi
		/// Media types: audio,video
		/// </summary>
		Avi = 2,

		/// <summary>
		/// Flash Video
		/// Creator: Adobe Systems
		/// Extension: .flv, .f4v
		/// Media types: audio,video
		/// </summary>
		Flv = 3, 

		/// <summary>
		/// MPEG-4 Part 14 
		/// Extension: .mp4
		/// Media types: audio,video
		/// </summary>
		Mp4 = 4,

		/// <summary>
		/// Creator: Xiph Foundation
		/// Extension: .oga (audio), .ogv (video)
		/// Media types: audio,video
		/// </summary>
		Ogg = 5,

		/// <summary>
		/// Quicktime video container
		/// Creator: Apple
		/// Extension: .mov, .qt
		/// Media types: audio,video
		/// </summary>
		Quicktime = 6,

		/// <summary>
		/// Waveform Audio Format
		/// Creator: Microsoft / IBM
		/// Extension : .wav
		/// Media types: audio
		/// </summary>
		Wav = 7,

		/// <summary>
		/// Media types: audio,video
		/// </summary>
		WebM = 8
	}
}
