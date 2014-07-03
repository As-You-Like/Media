namespace Carbon.Helpers
{
	using Carbon.Math;
	using Carbon.Media;

	public static class SizeExtensions
	{
		public static bool FitsIn(this ISize source, ISize target) 
		{
			return source.Width <= target.Width && source.Height <= target.Height;
		}

		public static Size Scale(this Size size, float scale)
		{
			return new Size(
				width  : (int)((float)size.Width * scale),
				height : (int)((float)size.Height * scale)
			);
		}

		public static Rational ToRational(this ISize size)
		{
			return new Rational(size.Width, size.Height);
		}
	}
}