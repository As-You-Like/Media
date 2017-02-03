// TODO: Import Geometry when stable

namespace Carbon.Geometry
{
    public struct Rectangle
    {
        public Rectangle(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public double X { get; }

        public double Y { get; }

        public double Width { get; }

        public double Height { get; }

       // Inflate
    }
}