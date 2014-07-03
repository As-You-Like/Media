namespace Carbon.Media
{
	using System;

	using Carbon.Helpers;

	public struct MediaRenditionInfo : ISize
	{
		private readonly int width;
		private readonly int height;
		private readonly string url;

		private float pixelRatio;

		public MediaRenditionInfo(MediaTransformation transformation, Uri baseUrl)
			: this(transformation, baseUrl.ToString().TrimEnd('/') + '/' + transformation.GetPath()) { }

		public MediaRenditionInfo(ISize size, string url)
			: this(size.Width, size.Height, url) { }

		public MediaRenditionInfo(int width, int height, string url)
		{
			this.width = width;
			this.height = height;
			this.url = url;

			this.pixelRatio = 1.0f;
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public float PixelRatio
		{
			get { return pixelRatio; }
			set { pixelRatio = value; }
		}

		public bool IsEmpty
		{
			get { return width == 0 || height == 0; }
		}

		public MediaRenditionInfo Resample(string name)
		{
			var dotIndex = url.LastIndexOf('.');

			var lessExtension = url.Substring(0, dotIndex);
			var extension = url.Substring(dotIndex);

			var newUrl = string.Format("{0}/resample({1}){2}", 
				/*0*/ lessExtension,
				/*1*/ name, 
				/*2*/ extension
			);

			return new MediaRenditionInfo(width, height, newUrl);
		}

		public MediaRenditionInfo WithFormat(string format)
		{
			var dotIndex = url.LastIndexOf('.');

			var newUrl = url.Substring(0, dotIndex) + "." + format;

			return new MediaRenditionInfo(width, height, newUrl);
		}

		public MediaRenditionInfo Scale(float scale)
		{
			var u = new Uri(url);

			var a = MediaTransformation.ParsePath(u.AbsolutePath);

			var b = new MediaTransformation(a.Source, a.Format);

			foreach (var transform in a.GetTransforms())
			{
				if (transform is Resize)
				{
					var resize = (Resize)transform;

					b.Transform(new Resize(resize.Size.Scale(scale)));
				}
				else if (transform is AnchoredResize)
				{
					var resize = (AnchoredResize)transform;

					b.Transform(new AnchoredResize(resize.Size.Scale(scale), resize.Anchor));
				}
				else if (transform is Crop)
				{
					var crop = (Crop)transform;

					b.Transform(new Crop(crop.Rectangle.Scale(scale)));
				}
				else
				{
					b.Transform(transform);
				}
			}

			var newUrl = string.Format("{0}://{1}/{2}", u.Scheme, u.Host, b.GetPath());

			return new MediaRenditionInfo(b.Width, b.Height, newUrl);
		}

		public string Url
		{
			get { return url; }
		}

		public override string ToString()
		{
			return url;
		}
	}
}