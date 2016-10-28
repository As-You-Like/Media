namespace Carbon.Media
{
    public static class SizeExtensions
    {
        public static bool FitsIn(this ISize source, ISize target)
            => source.Width <= target.Width && source.Height <= target.Height;

        public static Size Scale(this ISize size, float scale)
            => new Size(
                width  : (int)(size.Width * scale),
                height : (int)(size.Height * scale)
            );

        public static Rational ToRational(this ISize size)
            => new Rational(size.Width, size.Height);
    }
}