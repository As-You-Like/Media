using System;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class PadTransform : IProcessor, ICanonicalizable
    {
        public PadTransform(int value)
        {
            if (value < 0) throw new ArgumentOutOfRangeException(nameof(value), value, "Must be >= 0");

            Top    = value;
            Right  = value;
            Bottom = value;
            Left   = value;
        }

        public PadTransform(int top, int right, int bottom, int left)
        {            
            if (top    < 0) throw new ArgumentOutOfRangeException(nameof(top),    top,    "Must be >= 0");
            if (right  < 0) throw new ArgumentOutOfRangeException(nameof(right),  right,  "Must be >= 0");
            if (bottom < 0) throw new ArgumentOutOfRangeException(nameof(bottom), bottom, "Must be >= 0");
            if (left   < 0) throw new ArgumentOutOfRangeException(nameof(left),   left,   "Must be >= 0");

            Top    = top;
            Right  = right;
            Bottom = bottom;
            Left   = left;
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
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("pad(");

            if (Top == Left && Top == Right && Top == Bottom)
            {
                sb.Append(Top);
            }
            else if (Top == Bottom && Left == Right)
            {
                sb.Append(Top);
                sb.Append(',');
                sb.Append(Right);
            }
            else
            {
                sb.Append(Top);
                sb.Append(',');
                sb.Append(Right);
                sb.Append(',');
                sb.Append(Bottom);
                sb.Append(',');
                sb.Append(Left);
            }

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();

        public static PadTransform Create(in CallSyntax syntax)
        {
            switch (syntax.Arguments.Length)
            {
                case 1:
                    return new PadTransform(int.Parse((string)syntax.Arguments[0].Value));
                case 2:
                    var a = int.Parse((string)syntax.Arguments[0].Value); // Top  & bottom
                    var b = int.Parse((string)syntax.Arguments[1].Value); // Left & right

                    return new PadTransform(a, b, a, b);
                case 4:
                    int top    = int.Parse((string)syntax.Arguments[0].Value);
                    int right  = int.Parse((string)syntax.Arguments[1].Value);
                    int bottom = int.Parse((string)syntax.Arguments[2].Value);
                    int left   = int.Parse((string)syntax.Arguments[3].Value);

                    return new PadTransform(top, right, bottom, left);
            }
            
            throw new Exception("Invalid pad arguments:" + string.Join(",", syntax.Arguments));
        }
    }
}