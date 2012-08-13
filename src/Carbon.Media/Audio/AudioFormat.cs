namespace Carbon.Media
{
	// TODO: Merge AudioFormat, VideoFormat, and ImageFormat into MediaFormat

	public enum AudioFormat : byte
	{
		/// <summary>
		/// Container: mpeg4
		/// Mime: audio/x-m4a
		/// </summary>
		Aac = 1,

		/// <summary>
		/// Container: aiff
		/// Mime: audio/aiff
		/// </summary>
		Aiff = 2,

		/// <summary>
		/// Mime: audio/mpeg
		/// </summary>
		Mp3 = 3,

		/// <summary>
		/// Container: wav
		/// Mime: audio/wav
		/// </summary>
		Wav = 4,

		/// <summary>
		/// Windows Media Audio
		/// Mime: audio/x-ms-wma
		/// </summary>
		Wma = 5
	}
}
