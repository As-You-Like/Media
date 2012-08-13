namespace Carbon.Media
{
	using System;
	using System.Collections.Generic;
	using System.Drawing;
	using System.Text;

	using Carbon.Helpers;

	public class MediaTransformation
	{
		protected readonly IMediaInfo source;
		protected readonly string format;
		protected readonly List<ITransform> transforms = new List<ITransform>();

		private string baseMediaPath = "";

		public MediaTransformation(IMediaInfo source, string format)
		{
			#region Preconditions

			if (source == null)
				throw new ArgumentNullException("source");

			if (format == null)
				throw new ArgumentNullException("format");

			#endregion

			this.format = format;
			this.source = source;
		}

		public string Format
		{
			get { return format; }
		}

		public IMediaInfo Source
		{
			get { return source; }
		}

		public string BaseMediaPath
		{
			get { return baseMediaPath; }
			set { baseMediaPath = value; }
		}

		public List<ITransform> Transforms
		{
			get { return transforms; }
		}

		#region Transform Helpers

		public bool HasTransforms
		{
			get { return transforms.Count > 0; }
		}

		#endregion

		#region Calculate Size 

		public Size CalculateSize(int width, int height)
		{
			var size = new Size(width, height);

			foreach (var transform in transforms)
			{
				if (transform is AnchoredResize) {
					var anchoredResize = (AnchoredResize)transform;

					size = anchoredResize.Size;
				}
				else if (transform is Resize) {
					var resize = (Resize)transform;

					size = resize.Size;
				}
				else if (transform is Crop) {
					var crop = (Crop)transform;

					size = crop.Rectangle.Size;
				}
				else if (transform is Rotate) {
					var rotate = (Rotate)transform;

					// TODO: Flip the size
				}
			}

			return size;
		}

		#endregion

		#region Helpers

		public static MediaTransformation ParseUrlPath(string path)
		{
			// 100/key/key.format

			var segments = path.Split('/', '.');

			int i = 1;

			var id = 0;
			var format = "";
			var transforms = new List<ITransform>();

			foreach (var segment in segments)
			{
				if (i == 1) 
				{
					id = Int32.Parse(segment);
				}
				else if (i == segments.Length) 
				{
					format = segment; // The last part
				}
				else
				{
					ITransform transform;

					var transformName = segment.Split(':')[0];

					switch (transformName)
					{
						case "crop":	transform = Crop.ParseKey(segment);			break;
						case "rotate":	transform = Rotate.ParseKey(segment);		break;
						default:
							if (segment.Contains("-")) {
								transform = AnchoredResize.ParseKey(segment);
							}
							else {
								transform = Resize.ParseKey(segment);
							}

							break;
					}

					transforms.Add(transform);
				}

				i++;
			}

			var rendition = new MediaTransformation(new MediaMock { Id = id }, format);

			foreach (var t in transforms)
			{
				rendition.Transforms.Add(t);
			}

			return rendition;
		}

		public string GetKey()
		{
			return source.Id + ":" + GetFullName();
		}

		public string GetUrlPath()
		{
			return source.Id + "/" + GetFullName();
		}

		public string GetFullName()
		{
			/* 
			10x10.gif			
			crop:0-0_10x10.jpeg		// A cropped image rendention (x=0,y=0,width=100,height=100)
			10x10-c/rotate:90.png	// A 10x10 image (anchored at it's center when resized) rotated 90 degrees
			200x100/rotate:90.png
			640x480.mp4
			*/

			var sb = new StringBuilder();

			foreach (var transform in transforms)
			{
				if(sb.Length != 0)
				{
					sb.Append("/");
				}

				sb.Append(transform.ToKey());
			}

			sb.Append(".");
			sb.Append(format);

			return sb.ToString();
		}

		#endregion

		public string Url
		{
			get
			{
				var key = GetUrlPath();

				return string.Format("{0}/{1}", BaseMediaPath, key);
			}
		}
	}

	internal class MediaMock : IMediaInfo
	{
		public int Id { get; set; }

		public Mime Type
		{
			get { throw new NotImplementedException(); }
		}

		public int Width
		{
			get { throw new NotImplementedException(); }
		}

		public int Height
		{
			get { throw new NotImplementedException(); }
		}

		public Uri Url
		{
			get { throw new NotImplementedException(); }
		}
	}
}
