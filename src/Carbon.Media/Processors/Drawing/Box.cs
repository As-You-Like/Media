﻿using System;

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

        // Alignment?

        public Unit? X         { get; set; }  
        public Unit? Y         { get; set; }
        public Unit? Width     { get; set; } // 50% || 50px
        public Unit? Height    { get; set; }
        public Padding Padding { get; set; } = Padding.Zero;
    }

    public struct Padding : IEquatable<Padding>
    {
        public static readonly Padding Zero = new Padding();

        public Padding(Unit value)
        {
            #region Preconditions

            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value.Value, "Must be >= 0");

            #endregion

            Top = value;
            Right = value;            
            Bottom = value;
            Left = value;
        }

        public Padding(Unit top, Unit right, Unit bottom, Unit left)
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

        public Unit Top { get; }

        public Unit Right { get; }

        public Unit Bottom { get; }

        public Unit Left { get; }

        public override string ToString()
        {
            if (Top == Left && Top == Right && Top == Bottom)
            {
                return Top.ToString();
            }
            else if (Top == Bottom && Right == Left)
            {
                return Top.ToString() + "," + Right.ToString();
            }

            return $"{Top},{Right},{Bottom},{Left}";
        }
        
        public static Padding Parse(string text) =>
            new Padding(Unit.Parse(text));

        public bool Equals(Padding other)
        {
            return Left   == other.Left
                && Right  == other.Right
                && Top    == other.Top
                && Bottom == other.Bottom;
        }
    }
}