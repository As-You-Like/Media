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

        public int X => Rectangle.X;

        public int Y => Rectangle.Y;

        public int Width => Rectangle.Width;

        public int Height => Rectangle.Height;

        // crop:0-0_100x100
        public override string ToString()
            => $"crop:{X}-{Y}_{Width}x{Height}";

        public static Crop Parse(string key)
        {
            // crop:0-0_100x100
            #region Normalization

            if (key.StartsWith("crop:"))
            {
                key = key.Remove(0, 5);
            }

            #endregion

            // 0-0_100x100

            var parts = key.Split(Seperators.Underscore); // '_'

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
