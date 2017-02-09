using System;
using System.Text;

namespace Carbon.Media
{
    public sealed class Pad : IProcessor
    {
        public Pad(int value)
        {
            #region Preconditions

            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), value, "Must be 0 or greater");

            #endregion

            Top = value;
            Right = value;
            Bottom = value;
            Left = value;
        }

        public Pad(int top, int right, int bottom, int left)
        {
            #region Preconditions
            
            if (top < 0)
                throw new ArgumentOutOfRangeException(nameof(top), top, "Must be 0 or greater");

            if (right < 0)
                throw new ArgumentOutOfRangeException(nameof(right), right, "Must be 0 or greater");

            if (bottom <= 0)
                throw new ArgumentOutOfRangeException(nameof(bottom), bottom, "Must be 0 or greater");

            if (left <= 0)
                throw new ArgumentOutOfRangeException(nameof(left), left, "Must be 0 or greater");

            #endregion

            Top = top;
            Right = right;
            Bottom = bottom;
            Left = left;
        }

        public int Top { get; }

        public int Right { get; }

        public int Left { get; }

        public int Bottom { get; }        
       
        // pad(0,0,0,0)
        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("pad(");

            if (Top == Left && Top == Right && Top == Bottom)
            {
                sb.Append(Top);
            }
            else
                {
                sb.Append(Top);
                sb.Append(",");
                sb.Append(Right);
                sb.Append(",");
                sb.Append(Bottom);
                sb.Append(",");
                sb.Append(Left);
            }

            sb.Append(")");

            return sb.ToString();
        }

        public override string ToString() =>
            Canonicalize();

        public static Pad Parse(string segment)
        {
            #region Normalization

            int argStart = segment.IndexOf('(') + 1;
            
            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            #endregion
  
            if (segment.Contains(","))
            {
                var parts = segment.Split(Seperators.Comma);
            
                int top = 0, right = 0, bottom = 0, left = 0;

                for (var i = 0; i < parts.Length; i++)
                {
                    var part = parts[i];

                    switch (i)
                    {
                        case 0: top    = int.Parse(part); break;
                        case 1: right  = int.Parse(part); break;
                        case 2: bottom = int.Parse(part); break;
                        case 3: left   = int.Parse(part);  break;
                    }
                }

                return new Pad(top, right, bottom, left);
            }
            else
            {
                return new Pad(int.Parse(segment));
            }
        }
    }
}