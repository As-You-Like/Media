﻿using System;

namespace Carbon.Media
{
    public struct Padding : IEquatable<Padding>
    {
        public static readonly Padding Zero = new Padding(0);

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

        public int Top { get; }

        public int Right { get; }

        public int Bottom { get; }

        public int Left { get; }
        
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

            if (same) return Top.ToString();

            if (Top == Bottom && Right == Left)
            {
                return $"{Top},{Right}";
            }

            return $"{Top},{Right},{Bottom},{Left}";
        }


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

        #endregion

    }
}