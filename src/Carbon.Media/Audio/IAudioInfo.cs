namespace Carbon.Media
{
	using System;

	public interface IAudioInfo
	{
		/// <summary>
		/// In kb/s
		/// </summary>
		int Bitrate { get; }

		/// <summary>
		/// The number of channels in the audio stream.
		/// e.g. mono:1, stereo:2, 5, ...
		/// </summary>
		int Channels { get; }

		MediaCodec Codec { get; }
		
		TimeSpan Duration { get; }

		/// <summary>
		/// The sampling rate defines the number of samples per second
		/// taken from a continuous signal to make a discrete signal.
		/// Measured in hertz (Hz), or samples per second 
		/// 
		/// 8,000 Hz : Telephone
		/// 11,025 Hz :	1/4 CD sampling Rate
		/// 22,050 Hz :	1/2 CD sampling Rate
		/// 44,100 Hz :	Audio CD, most popular MPEG-1 (VCD, SVCD, MP3) sampling rate
		/// 48,000 Hz :	TV, DVD, and films. 
		/// 96,000 Hz : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
		/// 192,000 Hz : DVD-Audio, BD-ROM (Blu-ray Disc)/HD-DVD audio tracks
		/// 2,822,400 Hz : SACD
		/// </summary>
		int SampleRate { get; }
	}
}