using System;

namespace Carbon.Media.Drawing
{
    // A box with raw units...

    public class UnboundBox
    {
        public UnboundBox() { }

        public UnboundBox(Unit x, Unit y, Unit width, Unit height)
        {
            X      = x;
            Y      = y;
            Width  = width;
            Height = height;
        }

        // Alignment?

        public Unit? X                { get; set; }  
        public Unit? Y                { get; set; }
        public Unit? Width            { get; set; } // 50% || 50px
        public Unit? Height           { get; set; }
        public UnboundPadding Padding { get; set; }
    }

    public readonly struct UnboundPadding : IEquatable<UnboundPadding>
    {
        public static readonly UnboundPadding Zero = new UnboundPadding();

        public UnboundPadding(Padding value)
        {
            Top    = value.Top;
            Right  = value.Right;
            Bottom = value.Bottom;
            Left   = value.Left;
        }

        public UnboundPadding(Unit value)
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), value.Value, "Must be >= 0");

            Top = value;
            Right = value;            
            Bottom = value;
            Left = value;
        }

        public UnboundPadding(Unit top, Unit right, Unit bottom, Unit left)
        {
            #region Preconditions

            if (top < 0)    throw new ArgumentOutOfRangeException(nameof(top),    top.Value,    "Must be >= 0");
            if (right < 0)  throw new ArgumentOutOfRangeException(nameof(right),  right.Value,  "Must be >= 0");
            if (bottom < 0) throw new ArgumentOutOfRangeException(nameof(bottom), bottom.Value, "Must be >= 0");
            if (left < 0)   throw new ArgumentOutOfRangeException(nameof(left),   left.Value,   "Must be >= 0");

            #endregion

            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public readonly Unit Top;

        public readonly Unit Right;

        public readonly Unit Bottom;

        public readonly Unit Left;

        public override string ToString()
        {
            if (Top == Left && Top == Right && Top == Bottom)
            {
                return Top.ToString();
            }
            else if (Top == Bottom && Right == Left)
            {
                return $"{Top},{Right}";
            }

            return $"{Top},{Right},{Bottom},{Left}";
        }

        public static UnboundPadding Parse(string text)
        {
            return new UnboundPadding(Unit.Parse(text));
        }

        public bool Equals(UnboundPadding other) =>
            Left   == other.Left && 
            Right  == other.Right && 
            Top    == other.Top &&
            Bottom == other.Bottom;
    }
}