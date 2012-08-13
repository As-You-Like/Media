namespace Carbon.Media
{
	public static class MediaContainerExtensions
	{
		public static string GetDefaultFormat(this MediaContainer container)
		{
			switch (container)
			{
				case MediaContainer.Ogg:	return "ogg";
				case MediaContainer.Flv:	return "flv";
				case MediaContainer.Mp4:	return "mp4";
				case MediaContainer.WebM:	return "webm";

				default:					return null;
			}
		}
	}
}
