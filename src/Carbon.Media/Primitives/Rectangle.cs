// TODO: Import Geometry when stable

using System;
using Carbon.Media;

namespace Carbon.Geometry
{
    public struct Rectangle : IEquatable<Rectangle>
    {
        public Rectangle(Size size)
            : this(0, 0, size.Width, size.Height) { }

        public Rectangle(int x, int y, Size size)
          : this(x, y, size.Width, size.Height) { }

        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public double X;

        public double Y;

        public double Width;

        public double Height;

        public Size Size => new Size((int)Width, (int)Height);

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