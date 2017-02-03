using System;

namespace Carbon.Media
{
    using Geometry;

    public sealed class Crop : ITransform
    {
        public Crop(int x, int y, int width, int height)
        {
            #region Preconditions

            if (width <= 0)
                throw new ArgumentOutOfRangeException(nameof(width), width, "Must be greater than 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException(nameof(height), height, "Must be greater than 0");

            #endregion

            Rectangle = new Rectangle(x, y, width, height);
        }

        public Crop(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public Rectangle Rectangle { get; }

        public int X => (int)Rectangle.X;

        public int Y => (int)Rectangle.Y;

        public int Width => (int)Rectangle.Width;

        public int Height => (int)Rectangle.Height;

        // OLD: crop:0-0_100x100
        // NEW: crop(0,0,100,100)
        public override string ToString()
            => $"crop({X},{Y},{Width},{Height})";

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
                    x      : int.Parse(parts[0]),
                    y      : int.Parse(parts[1]),
                    width  : int.Parse(parts[2]),
                    height : int.Parse(parts[3])
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

            var locationString = parts[0];
            var size = Size.Parse(parts[1]);

            int x = int.Parse(locationString.Split(Seperators.Dash)[0]), // '-'
                y = int.Parse(locationString.Split(Seperators.Dash)[1]);

            return new Crop(x, y, size.Width, size.Height);
        }
    }
}

// GM SPEC
// <width>x<height>{+-}<x>{+-}<y>{%}

// 500x500-19-19
// 18-65-300x200
