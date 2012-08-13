namespace Carbon.Media
{
	using System;

	// TODO: Rename
	public class MediaRenditionInfo
	{
		private readonly int width;
		private readonly int height;
		private readonly Uri url;

		public MediaRenditionInfo(int width, int height, Uri url)
		{
			this.width = width;
			this.height = height;
			this.url = url;
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public Uri Url
		{
			get { return url; }
		}

		public override string ToString()
		{
			return Url.ToString();
		}
	}
}