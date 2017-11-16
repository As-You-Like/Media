using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class Crop : ITransform
    {
        public Crop(Unit x, Unit y, Unit width, Unit height)
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

        public Crop(Rectangle rectangle)
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

        public Rectangle GetRectangle(Size source)
        {
            return new Rectangle((int)X.Value, (int)Y.Value, (int)Width.Value, (int)Height.Value);
        }

        public Crop Scale(double xScale, double yScale) =>
            new Crop(
                x      : (int)(X * xScale),
                y      : (int)(Y * yScale),
                width  : (int)(Width * xScale),
                height : (int)(Height * yScale)
            );

        public Crop Scale(double scale) =>
            new Crop(
                x       : (int)(X * scale),
                y       : (int)(Y * scale),
                width   : (int)(Width * scale),
                height  : (int)(Height * scale)
            );

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

        // OLD: crop:0-0_100x100
        // NEW: crop(0,0,100,100)
        public override string ToString() => Canonicalize();

        public static Crop Parse(string key)
        {
            string[] parts;

            // New Format
            // crop(0,0,100,100)
            // crop(0.5,0.5,0.5,0.5)
            // crop(x:10,y:100)

            if (key.StartsWith("crop("))
            {
                key = key.Remove(0, 5);

                key = key.Substring(0, key.Length - 1);

                parts = key.Split(Seperators.Comma);

                return new Crop(
                    x      : Unit.Parse(parts[0]),
                    y      : Unit.Parse(parts[1]),
                    width  : Unit.Parse(parts[2]),
                    height : Unit.Parse(parts[3])
                );
            }

            // Legacy FORMAT
            // crop:0-0_100x100

            #region Normalization

            if (key.StartsWith("crop:"))
            {
                key = key.Remove(0, 5);
            }

            #endregion

            // 0-0_100x100

            parts = key.Split(Seperators.Underscore); // '_'

            var locationParts = parts[0].Split(Seperators.Dash); // '-'
            var size = SizeHelper.Parse(parts[1]);

            Unit x = Unit.Parse(locationParts[0]), // '-'
                 y = Unit.Parse(locationParts[1]);

            return new Crop(x, y, size.Width, size.Height);
        }
    }
}

// GM SPEC
// <width>x<height>{+-}<x>{+-}<y>{%}

// 500x500-19-19
// 18-65-300x200
