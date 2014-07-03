namespace Carbon.Media
{
	public struct Rectangle
	{
		private readonly int x;
		private readonly int y;
		private readonly int width;
		private readonly int height;

		public Rectangle(int x, int y, int width, int height)
		{
			this.x = x;
			this.y = y;
			this.width = width;
			this.height = height;
		}

		public int X
		{
			get { return x; }
		}

		public int Y
		{
			get { return y; }
		}

		public int Width
		{
			get { return width; }
		}

		public int Height
		{
			get { return height; }
		}

	}
}
