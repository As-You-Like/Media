using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class CropTransform : IProcessor, ICanonicalizable
    {
        public CropTransform(Unit x, Unit y, Unit width, Unit height)
        {
            #region Preconditions

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), width, "Must be greater than 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), height, "Must be greater than 0");

            #endregion

            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public CropTransform(Rectangle rectangle)
        {
            X      = new Unit(rectangle.X);
            Y      = new Unit(rectangle.Y);
            Width  = new Unit(rectangle.Width);
            Height = new Unit(rectangle.Height);
        }

        public Unit X { get; }

        public Unit Y { get; }

        public Unit Width { get; }

        public Unit Height { get; }

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)X.Value, (int)Y.Value, (int)Width.Value, (int)Height.Value);
        }

        public Rectangle GetRectangle(Size source) => new Rectangle(
            x      : (int)X.Value, 
            y      : (int)Y.Value, 
            width  : (int)Width.Value, 
            height : (int)Height.Value
        );

        public CropTransform Scale(double xScale, double yScale) => new CropTransform(
            x      : (int)(X * xScale),
            y      : (int)(Y * yScale),
            width  : (int)(Width * xScale),
            height : (int)(Height * yScale)
        );

        public CropTransform Scale(double scale) => new CropTransform(
            x       : (int)(X * scale),
            y       : (int)(Y * scale),
            width   : (int)(Width * scale),
            height  : (int)(Height * scale)
        );

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("crop(");
            sb.Append(X.ToString());
            sb.Append(',');
            sb.Append(Y.ToString());
            sb.Append(',');
            sb.Append(Width.ToString());
            sb.Append(',');
            sb.Append(Height.ToString());
            sb.Append(')');
        }

        #endregion

        // crop(0,0,100,100)
        // crop(0.5,0.5,0.5,0.5)
        // crop(x:10,y:100)
        
        public override string ToString() => Canonicalize();

        public static CropTransform Create(CallSyntax syntax)
        {
            return new CropTransform(
                x      : Unit.Parse(syntax.Arguments[0].Value),
                y      : Unit.Parse(syntax.Arguments[1].Value),
                width  : Unit.Parse(syntax.Arguments[2].Value),
                height : Unit.Parse(syntax.Arguments[3].Value)
            );
        }

        public static CropTransform Parse(string text)
        {
            return Create(CallSyntax.Parse(text));
        }
    }
}

// GM SPEC
// <width>x<height>{+-}<x>{+-}<y>{%}

// 500x500-19-19
// 18-65-300x200
