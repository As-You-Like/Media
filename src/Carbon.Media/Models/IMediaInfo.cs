namespace Carbon.Media
{
	public interface IMediaInfo
	{
		int Id { get; }

		string Format { get; }

		int Width { get; }

		int Height { get; }
	}
}