namespace Carbon.Media
{
    public static class SizeExtensions
    {
        public static bool FitsIn(this ISize source, Size box)
            => source.Width <= box.Width && source.Height <= box.Height;

        public static Rational ToRational(this ISize size)
            => new Rational(size.Width, size.Height);
    }
}