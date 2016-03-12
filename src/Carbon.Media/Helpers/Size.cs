using System;

namespace Carbon.Media
{
    public struct Size : ISize
    {
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }

        public int Height { get; }

        public override string ToString() => Width + "x" + Height;

        public static Size Parse(string size)
        {
            #region Preconditions

            if (size == null) throw new ArgumentNullException(nameof(size));

            if (!size.Contains("x")) throw new ArgumentException($"Invalid size. Was '{size}'.");

            #endregion

            var parts = size.Split('x');

            return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}