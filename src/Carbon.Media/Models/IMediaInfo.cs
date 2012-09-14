namespace Carbon.Media
{
	using System;

	public interface IMediaInfo
	{
		int Id { get; }

		string Format { get; }

		int Width { get; }

		int Height { get; }

		Uri Url { get; }
	}
}