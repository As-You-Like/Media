using System.Drawing;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public struct PaddedBox
    {
        public PaddedBox(Size size)
            : this(size.Width, size.Height) { }

        public PaddedBox(Size size, Padding margin)
            : this(size.Width, size.Height)
        {
            Padding = margin;
        }

        public PaddedBox(int width, int height)
        {
            X       = 0;
            Y       = 0;
            Width   = width;
            Height  = height;
            Padding = Padding.Zero;
        }
        
        public Padding Padding { get; set; }

        [DataMember(Name = "x")]
        public int X { get; set; }

        [DataMember(Name = "y")]
        public int Y { get; set; }

        // excluding padding
        [DataMember(Name = "width")]
        public int Width { get; set; }

        // excluding padding
        [DataMember(Name = "height")]
        public int Height { get; set; }

        public Size Size => new Size(Width, Height);

        public int OuterWidth  => Width + Padding.Left + Padding.Right;

        public int OuterHeight => Height + Padding.Top + Padding.Bottom;
    }
}