using System;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class Pad : IProcessor
    {
        public Pad(int value)
        {
            #region Preconditions

            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "Must be >= 0");

            #endregion

            Top = value;
            Right = value;
            Bottom = value;
            Left = value;
        }

        public Pad(int top, int right, int bottom, int left)
        {
            #region Preconditions
            
            if (top < 0)     throw new ArgumentOutOfRangeException(nameof(top),    top,    "Must be >= 0");
            if (right < 0)   throw new ArgumentOutOfRangeException(nameof(right),  right,  "Must be >= 0");
            if (bottom <= 0) throw new ArgumentOutOfRangeException(nameof(bottom), bottom, "Must be >= 0");
            if (left <= 0)   throw new ArgumentOutOfRangeException(nameof(left),   left,   "Must be >= 0");

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
       
        // pad(10)
        // pad(0,0,0,0)
        // pad(10,20)
        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("pad(");
          
            if (Top == Left && Top == Right && Top == Bottom)
            {
                sb.Append(Top);
            }
            else if (Top == Bottom && Left == Right)
            {
                sb.Append(Top);
                sb.Append(",");
                sb.Append(Right);
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
            
            if (!segment.Contains(","))
            {       
                return new Pad(int.Parse(segment));
            }

            string[] parts = segment.Split(Seperators.Comma);
                       
            if (parts.Length == 2)
            {
                var a = int.Parse(parts[0]); // Top & Bottom
                var b = int.Parse(parts[1]); // Left & Right
                
                return new Pad(a, b, a, b);
            }
            else if (parts.Length == 4)
            {                              
                int top    = int.Parse(parts[0]); 
                int right  = int.Parse(parts[1]); 
                int bottom = int.Parse(parts[2]);
                int left   = int.Parse(parts[3]); 

                return new Pad(top, right, bottom, left);
            }

            throw new Exception("Unexpected");
        }
    }
}