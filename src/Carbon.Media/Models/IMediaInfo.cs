namespace Carbon.Media
{
	using System;

	public interface IMediaInfo
	{
		int Id { get; }

		// byte[] Sha256 { get; }

		string Format { get; }

		int Width { get; }

		int Height { get; }
	}
}