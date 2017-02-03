using System;

namespace Carbon.Media
{
    public class Box
    {
        public Box() { }

        public Box(Unit x, Unit y, Unit width, Unit height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Unit? X          { get; set; }  
        public Unit? Y          { get; set; }
        public Unit? Width      { get; set; } // e.g. 50% || 50px
        public Unit? Height     { get; set; }
        public Padding Padding  { get; set; } = Padding.Zero;
    }

    public struct Padding : IEquatable<Padding>
    {
        public static Padding Zero = new Padding();

        public Padding(Unit value)
        {
            Left = value;
            Right = value;
            Top = value;
            Bottom = value;
        }

        public Unit Left { get; }

        public Unit Right { get; }

        public Unit Top { get; }

        public Unit Bottom { get; }

        public override string ToString()
        {
            return Left.Value.ToString();
        }

        public static Padding Parse(string text)
        {
            return new Padding(Unit.Parse(text));
        }

        public bool Equals(Padding other)
        {
            return Left.Equals(other.Left)
                && Right.Equals(other.Right)
                && Top.Equals(other.Right)
                && Bottom.Equals(other.Right);
        }
    }
}