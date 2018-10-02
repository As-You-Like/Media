using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Carbon.Media
{

    // TODO: Replace with Carbon.Geography.Rectangle
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct BoundingBox : IEquatable<BoundingBox>
    {
        public BoundingBox(Rectangle rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height) { }

        public BoundingBox(RectangleF rectangle)
          : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height) { }

        public BoundingBox(double x, double y, double width, double height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        [DataMember(Name = "x", Order = 1)]
        public double X { get; }

        [DataMember(Name = "y", Order = 2)]
        public double Y { get; }

        [DataMember(Name = "width", Order = 3)]
        public double Width { get; }

        [DataMember(Name = "height", Order = 4)]
        public double Height { get; }

        public bool Equals(BoundingBox other) =>
            X == other.X &&
            Y == other.Y &&
            Width == other.Width &&
            Height == other.Height;
    }
}