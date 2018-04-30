using System;
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

    public static class SizeHelper
    {
        public static Size Parse(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            int indexOfX = text.IndexOf('x');

            if (indexOfX == -1)
            {
                throw new ArgumentException($"Invalid size. Was '{text}'.");
            }

            return new Size(
                width: int.Parse(text.Substring(0, indexOfX)), 
                height: int.Parse(text.Substring(indexOfX + 1))
            );
        }
    }
}