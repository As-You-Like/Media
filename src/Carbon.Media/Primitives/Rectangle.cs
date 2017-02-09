// TODO: Import Geometry when stable

using Carbon.Media;

namespace Carbon.Geometry
{
    public struct Rectangle
    {
        public Rectangle(Size size)
            : this(0, 0, size.Width, size.Height) { }

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

       // Inflate
    }
}