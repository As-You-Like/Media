namespace Carbon.Media
{
	using System;

	public interface IFrameInfo
	{
		TimeSpan? Offset { set; }

		int Height { get; }

		int Width { get; }

		Uri Url { get; }
	}
}