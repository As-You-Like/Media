using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class CropTransform : IProcessor, ICanonicalizable
    {
        private readonly Unit x;
        private readonly Unit y;
        private readonly Unit width;
        private readonly Unit height;

        public CropTransform(Unit x, Unit y, Unit width, Unit height)
        {
            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), width, "Must be greater than 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), height, "Must be greater than 0");
            
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public CropTransform(Rectangle rectangle)
        {
            this.x      = new Unit(rectangle.X);
            this.y      = new Unit(rectangle.Y);
            this.width  = new Unit(rectangle.Width);
            this.height = new Unit(rectangle.Height);
        }

        public Unit X => x;

        public Unit Y => y;

        public Unit Width => width;

        public Unit Height => height;

        public Rectangle GetRectangle()
        {
            return new Rectangle((int)x.Value, (int)y.Value, (int)width.Value, (int)height.Value);
        }

        public Rectangle GetRectangle(Size source) => new Rectangle(
            x      : (int)x.Value, 
            y      : (int)y.Value, 
            width  : (int)width.Value, 
            height : (int)height.Value
        );

        public CropTransform Scale(double xScale, double yScale) => new CropTransform(
            x      : (int)(x * xScale),
            y      : (int)(y * yScale),
            width  : (int)(width * xScale),
            height : (int)(height * yScale)
        );

        public CropTransform Scale(double scale) => new CropTransform(
            x       : (int)(x * scale),
            y       : (int)(y * scale),
            width   : (int)(width * scale),
            height  : (int)(height * scale)
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
            sb.Append(in x);
            sb.Append(',');
            sb.Append(in y);
            sb.Append(',');
            sb.Append(in width);
            sb.Append(',');
            sb.Append(in height);
            sb.Append(')');
        }

        #endregion

        // crop(0,0,100,100)
        // crop(0.5,0.5,0.5,0.5)
        // crop(x:10,y:100)
        
        public override string ToString() => Canonicalize();

        public static CropTransform Create(in CallSyntax syntax)
        {
            return new CropTransform(
                x      : Unit.Parse((string)syntax.Arguments[0].Value),
                y      : Unit.Parse((string)syntax.Arguments[1].Value),
                width  : Unit.Parse((string)syntax.Arguments[2].Value),
                height : Unit.Parse((string)syntax.Arguments[3].Value)
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
