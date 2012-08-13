namespace Carbon.Media
{
	using System;
	using System.Drawing;
	using System.Runtime.Serialization;
	using System.Text;

	using Carbon.Helpers;

	public class Resize : ITransform
	{
		private readonly int height;
		private readonly int width;

		public Resize(Size size) 
			: this(size.Width, size.Height) { }

		public Resize(int width, int height)
		{
			#region Preconditions

			if (width < 0 || width > 3200)
				throw new ArgumentOutOfRangeException("width", width, message: "Must be between 0 and 3200");

			if (height < 0 || height > 6500)
				throw new ArgumentOutOfRangeException("height", height, message: "Must be between 0 and 6500");
			
			#endregion

			this.width = width;
			this.height = height;
		}

		public int Height {
			get { return height; }
		}

		public int Width {
			get { return width; }
		}

		[IgnoreDataMember]
		public Size Size 
		{
			get { return new Size(width, height); }
		}

		public override string ToString()
		{
			return width + "x" + height;
		}

		public static Resize Parse(string key)
		{
			#region Normalization

			if (key.StartsWith("resize:")) {
				key = key.Remove(0, 7);
			}

			#endregion

			var size = VisualHelper.ParseSize(key);

			return new Resize(size);
		}
	}
}

/* 

Image Magic : 
-resize 64x64
-crop 40x30+10+10  (width,height,top,left)

-crop <width>x<height>{+-}<x>{+-}<y>{%}
 

*/