namespace Carbon.Media
{
	using System;

	public interface IMediaInfo
	{
		int Id { get; }

		// e.g. image/jpeg
		Mime Type { get; }

		int Width { get; }

		int Height { get; }

		Uri Url { get; }
	}
}