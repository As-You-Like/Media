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

            if (size == null)
                throw new ArgumentNullException(nameof(size));

            #endregion

            var parts = size.Split('x');

            if (parts.Length != 2)
            {
                throw new ArgumentException($"Invalid size. Was '{size}'.");

            }

            return new Size(int.Parse(parts[0]), int.Parse(parts[1]));
        }

        #region Equality

        public static bool operator == (Size a, Size b)
            => a.Width == b.Width && a.Height == b.Height;

        public static bool operator !=(Size a, Size b)
            => !(a == b);

        public override bool Equals(object obj)
        {
            if (!(obj is Size)) return false;

            var instance = (Size)obj;

            return (instance.Width == Width) && (instance.Height == Height);
        }

        public override int GetHashCode() => Width ^ Height;

        #endregion

    }
}