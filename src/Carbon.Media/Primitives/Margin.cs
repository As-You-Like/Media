using System;

namespace Carbon.Media
{
    public struct Margin : IEquatable<Margin>
    {
        public static readonly Margin Zero = new Margin(0);

        public Margin(int top, int right, int bottom, int left)
        {
            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public Margin(int topAndBottom, int leftAndRight)
        {
            Top = topAndBottom;
            Right = leftAndRight;
            Bottom = topAndBottom;
            Left = leftAndRight;
        }

        public Margin(int value)
        {
            Top = value;
            Right = value;
            Bottom = value;
            Left = value;
        }

        public int Top { get; }

        public int Right { get; }

        public int Bottom { get; }

        public int Left { get; }

        public override string ToString()
        {
            var same = Top == Right && Top == Bottom && Top == Left;

            if (same) return Top.ToString();


            if (Top == Bottom && Right == Left)
            {
                return $"{Top},{Right}";
            }

            return $"{Top},{Right},{Bottom},{Left}";
        }

        public bool Equals(Margin other)
        {
            return Top == other.Top
                && Right == other.Right
                && Bottom == other.Bottom
                && Left == other.Left;
        }
    }
}
