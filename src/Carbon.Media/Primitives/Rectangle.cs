// TODO: Import Geometry when stable

using System;

namespace Carbon.Media
{
    // Padding?

    public struct Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(Size size)
            : this(0, 0, size.Width, size.Height) { }

        public Rectangle(int x, int y, Size size)
          : this(x, y, size.Width, size.Height) { }

        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public int X;

        public int Y;

        public int Width;

        public int Height;

        public Size Size => new Size(Width, Height);

        public bool Equals(Rectangle other) =>
            X == other.X &&
            Y == other.Y &&
            Width == other.Width &&
            Height == other.Height;

        public override string ToString() =>
            $"{X},{Y},{Width},{Height}";
        
        // Inflate
    }
}