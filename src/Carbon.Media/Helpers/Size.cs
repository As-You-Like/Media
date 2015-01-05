namespace Carbon.Media
{
	using System;

	public struct Size : ISize
	{
		private readonly int width;
		private readonly int height;

		public Size(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

		public override string ToString()
		{
			return width + "x" + height;
		}

		public static Size Parse(string size)
		{
			#region Preconditions

			if (size == null)		throw new ArgumentNullException("size");

			if (!size.Contains("x")) throw new ArgumentException(string.Format("Invalid size. Was '{0}'.", size));

			#endregion

			var parts = size.Split('x');

			return new Size(Int32.Parse(parts[0]), Int32.Parse(parts[1]));
		}
	}
}