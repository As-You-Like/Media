namespace Carbon.Media
{
	using System;

	public interface IMediaInfo
	{
		int Id { get; } // TODO: Key

		string Format { get; }

		int Width { get; }

		int Height { get; }

		Uri Url { get; }
	}
}