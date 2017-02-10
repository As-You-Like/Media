// TODO: Import Geometry when stable

using Carbon.Media;

namespace Carbon.Geometry
{
    public struct Box2
    {
        public Box2(Size size)
            : this( size.Width, size.Height) { }

        public Box2(Size size, Margin margin)
            : this(size.Width, size.Height)
        {
            Padding = margin;
        }

        public Box2(int width, int height)
        {
            Width = width;
            Height = height;
            Padding = Margin.Zero;
        }
        
        public Margin Padding;
  
        public int Width;

        public int Height;

        public Size Size => new Size(Width, Height);

        public int OuterWidth  => Width + Padding.Left + Padding.Right;

        public int OuterHeight => Height + Padding.Top + Padding.Bottom;


       // Inflate
    }
}