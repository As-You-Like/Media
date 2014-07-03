namespace Carbon.Media
{
	using System;

	public struct Crop : ITransform
	{
		private readonly Rectangle rectangle;

		public Crop(Point origin, Size size)
			: this(new Rectangle(origin.X, origin.Y, size.Width, size.Height)) { }

		public Crop(int x, int y, int width, int height)
		{
			#region Preconditions

			if (width <= 0)
				throw new ArgumentOutOfRangeException("width", width, "Must be greater than 0");

			if (height <= 0)
				throw new ArgumentOutOfRangeException("height", height, "Must be greater than 0");

			#endregion

			this.rectangle = new Rectangle(x, y, width, height);
		}

		public Crop(Rectangle rectangle) {
			this.rectangle = rectangle;
		}

		public Rectangle Rectangle
		{
			get { return rectangle; }
		}

		public int Width
		{
			get { return rectangle.Width; }
		}

		public int Height
		{
			get { return rectangle.Height; }
		}

		public override string ToString()
		{
			// crop:0-0_100x100

			return string.Format("crop:{0}-{1}_{2}x{3}",
				/*0*/ rectangle.X, 
				/*1*/ rectangle.Y, 
				/*2*/ rectangle.Width, 
				/*3*/ rectangle.Height
			);
		}

		public static Crop Parse(string key)
		{
			#region Normalization

			if(key.StartsWith("crop:")) {
				key = key.Remove(0, 5);
			}

			#endregion

			// crop:0-0_100x100

			var locationString = key.Split('_')[0];
			var sizeString = key.Split('_')[1];

			int x = Int32.Parse(locationString.Split('-')[0]);
			int y = Int32.Parse(locationString.Split('-')[1]);
			int width = Int32.Parse(sizeString.Split('x')[0]);
			int height = Int32.Parse(sizeString.Split('x')[1]);

			return new Crop(x, y, width, height);
		}
	}
}

// GM SPEC
// <width>x<height>{+-}<x>{+-}<y>{%}

// 500x500-19-19
// 18-65-300x200
