using System.Drawing;

namespace Carbon.Media
{
    public static class SizeExtensions
    {
        public static Size Scale(this Size size, double scale) => new Size(
            width  : (int)(size.Width * scale),
            height : (int)(size.Height * scale)
        );

        public static bool FitsIn(this Size source, Size box) => 
            source.Width <= box.Width && source.Height <= box.Height;

        public static Rational ToRational(this Size size) => 
            new Rational(size.Width, size.Height);
    }
}