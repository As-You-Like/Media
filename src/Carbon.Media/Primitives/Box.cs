using System.Drawing;

namespace Carbon.Media
{
    public struct Box
    {
        public Box(Size size)
            : this(size.Width, size.Height) { }

        public Box(Size size, Padding margin)
            : this(size.Width, size.Height)
        {
            Padding = margin;
        }

        public Box(int width, int height)
        {
            X       = 0;
            Y       = 0;
            Width   = width;
            Height  = height;
            Padding = Padding.Zero;
        }
        
        public Padding Padding;
  
        public int X;

        public int Y;

        // excluding padding
        public int Width;

        // excluding padding
        public int Height;

        public Size Size => new Size(Width, Height);

        public int OuterWidth  => Width + Padding.Left + Padding.Right;

        public int OuterHeight => Height + Padding.Top + Padding.Bottom;
    }
}