namespace Carbon.Media
{
	using System;
	using System.Drawing;

	using Carbon.Helpers;

	public class AnchoredResize : ITransform
	{
		private readonly int width;
		private readonly int height;
		private readonly Alignment anchor;

		public AnchoredResize(Size size, Alignment anchor)
			: this(size.Width, size.Height, anchor) { }

		public AnchoredResize(int width, int height, Alignment anchor)
		{
			#region Preconditions

			if (width <= 0)
				throw new ArgumentOutOfRangeException("width", width, "Must be greater than 0");

			if (height <= 0)
				throw new ArgumentOutOfRangeException("height", height, "Must be greater than 0");

			#endregion

			this.width = width;
			this.height = height;
			this.anchor = anchor;
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public Size Size 
		{
			get { return new Size(width, height); }
		}

		public Alignment Anchor
		{
			get { return anchor; }
		}

		public override string ToString()
		{
			// {width}x{height}-{anchorAbbreviation}

			// 100x100;fit=contain;anchor=center/

			// fit: cover,contain,crop,pad

			return string.Format("{0}x{1}-{2}", 
				/*0*/ width,
				/*1*/ height,
				/*2*/ anchor.ToAbbreviation()
			);
		}

		public static AnchoredResize Parse(string key)
		{
			#region Normalization

			if (key.StartsWith("resize:")) {
				key = key.Remove(0, 7);
			}

			#endregion

			var size = VisualHelper.ParseSize(key.Split('-')[0]);
			var anchor = AlignmentHelper.ParseAlignment(key.Split('-')[1]);

			return new AnchoredResize(size, anchor);
		}
	}
}