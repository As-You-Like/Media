namespace Carbon.Helpers
{
	using Carbon.Media;

	public static class RectangleExtensions
	{
		public static Rectangle Scale(this Rectangle rect, float scale)
		{
			return new Rectangle(
				x		: (int)((float)rect.X * scale),
				y		: (int)((float)rect.Y * scale),
				width	: (int)((float)rect.Width * scale),
				height	: (int)((float)rect.Height * scale)
			);
		}
	}
}
