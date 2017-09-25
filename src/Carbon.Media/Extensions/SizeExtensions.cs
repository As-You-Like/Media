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
        public static Size Parse(string size)
        {
            #region Preconditions

            if (size == null)
                throw new ArgumentNullException(nameof(size));

            #endregion

            var parts = size.Split(Seperators.x);

            if (parts.Length != 2)
            {
                throw new ArgumentException($"Invalid size. Was '{size}'.");
            }

            return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}