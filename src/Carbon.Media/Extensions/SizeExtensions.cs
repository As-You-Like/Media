namespace Carbon.Helpers
{
	using System.Drawing;

	using Carbon.Math;

	public static class SizeExtensions
	{
		public static bool FitsIn(this Size source, Size target) 
		{
			return source.Width <= target.Width && source.Height <= target.Height;
		}

		public static Fraction ToFraction(this Size size)
		{
			return new Fraction(size.Width, size.Height);
		}
	}
}