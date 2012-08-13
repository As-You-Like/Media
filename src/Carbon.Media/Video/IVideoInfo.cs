namespace Carbon.Media
{
	using System;

	public interface IVideoInfo
	{
		MediaCodec Codec { get; } // TODO: Break out audio and video codecs

		TimeSpan Duration { get; }

		int Width { get; }

		int Height { get; }

		double FrameRate { get; }

		VideoFormat Format { get; }
	}
}