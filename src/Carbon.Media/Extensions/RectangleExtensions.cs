namespace Carbon.Geometry
{
	public static class RectangleExtensions
	{
		public static Rectangle Scale(this Rectangle rect, float scale)
		{
			return new Rectangle(
				x		: (int)(rect.X * scale),
				y		: (int)(rect.Y * scale),
				width	: (int)(rect.Width * scale),
				height	: (int)(rect.Height * scale)
			);
		}
	}
}
