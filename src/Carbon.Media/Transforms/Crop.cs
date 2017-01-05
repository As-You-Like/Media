using System;
using System.Numerics;

namespace Carbon.Media
{
    using Geometry;

    public struct Crop : ITransform
    {
        public Crop(Vector2 origin, Size size)
            : this(new Rectangle((int)origin.X, (int)origin.Y, size.Width, size.Height))
        { }

        public Crop(int x, int y, int width, int height)
        {
            #region Preconditions

            if (width <= 0)
                throw new ArgumentOutOfRangeException("width", width, "Must be greater than 0");

            if (height <= 0)
                throw new ArgumentOutOfRangeException("height", height, "Must be greater than 0");

            #endregion

            Rectangle = new Rectangle(x, y, width, height);
        }

        public Crop(Rectangle rectangle)
        {
            Rectangle = rectangle;
        }

        public Rectangle Rectangle { get; }

        public int Width => Rectangle.Width;

        public int Height => Rectangle.Height;

        public override string ToString()
        {
            // crop:0-0_100x100

            return string.Format("crop:{0}-{1}_{2}x{3}",
                /*0*/ Rectangle.X,
                /*1*/ Rectangle.Y,
                /*2*/ Rectangle.Width,
                /*3*/ Rectangle.Height
            );
        }

        public static Crop Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("crop:"))
            {
                key = key.Remove(0, 5);
            }

            #endregion

            // crop:0-0_100x100

            var locationString = key.Split('_')[0];
            var sizeString = key.Split('_')[1];

            int x = int.Parse(locationString.Split('-')[0]);
            int y = int.Parse(locationString.Split('-')[1]);
            int width = int.Parse(sizeString.Split('x')[0]);
            int height = int.Parse(sizeString.Split('x')[1]);

            return new Crop(x, y, width, height);
        }
    }
}

// GM SPEC
// <width>x<height>{+-}<x>{+-}<y>{%}

// 500x500-19-19
// 18-65-300x200
