using System;

namespace Carbon.Media
{
    public readonly struct Padding : IEquatable<Padding>
    {
        public static readonly Padding Zero = default;

        public Padding(int top, int right, int bottom, int left)
        {
            Top    = top;
            Right  = right;
            Bottom = bottom;
            Left   = left;
        }

        public Padding(int topAndBottom, int leftAndRight)
        {
            Top    = topAndBottom;
            Right  = leftAndRight;
            Bottom = topAndBottom;
            Left   = leftAndRight;
        }

        public Padding(int value)
        {
            Top    = value;
            Right  = value;
            Bottom = value;
            Left   = value;
        }

        public readonly int Top;

        public readonly int Right;

        public readonly int Bottom;

        public readonly int Left;
        
        public static Padding operator +(Padding lhs, Padding rhs) 
        {
            return new Padding(
                top    : lhs.Top    + rhs.Top,
                right  : lhs.Right  + rhs.Right,
                bottom : lhs.Bottom + rhs.Bottom,
                left   : lhs.Left   + rhs.Left
            );
        }

        public override string ToString()
        {
            var same = Top == Right && Top == Bottom && Top == Left;

            if (same)
            {
                return Top.ToString();
            }

            if (Top == Bottom && Right == Left)
            {
                return $"{Top},{Right}";
            }

            return $"{Top},{Right},{Bottom},{Left}";
        }
        
        // TODO Parse

        #region Equality

        public bool Equals(Padding other) =>
            Top == other.Top && 
            Right == other.Right && 
            Bottom == other.Bottom && 
            Left == other.Left;

        public override bool Equals(object obj)
        {
            return obj is Padding padding && padding.Equals(this);
        }
        
        public override int GetHashCode()
        {
            return (Top, Right, Bottom, Left).GetHashCode();
        }

        #endregion
    }
}