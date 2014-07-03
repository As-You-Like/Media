namespace Carbon.Media
{
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
	}
}
