namespace Carbon.Media
{
	using System;
	using System.Drawing;

	// TODO: Rename
	public class MediaRenditionInfo
	{
		private readonly int width;
		private readonly int height;
		private readonly Uri url;

		private double pixelRatio;

		public MediaRenditionInfo(Size size, Uri url)
			: this(size.Width, size.Height, url) { }

		public MediaRenditionInfo(int width, int height, Uri url)
		{
			this.width = width;
			this.height = height;
			this.url = url;

			this.pixelRatio = 1.0d;
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public double PixelRatio
		{
			get { return pixelRatio; }
			set { pixelRatio = value; }
		}

		public MediaRenditionInfo Scale(float scale)
		{
			var spec = 
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