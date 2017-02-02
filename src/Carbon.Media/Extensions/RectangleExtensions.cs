namespace Carbon.Geometry
{
    public static class RectangleExtensions
    {
        // TODO: Origin

        public static Rectangle Scale(this Rectangle rect, double scale)
        {
            return new Rectangle(
                x      : (int)(rect.X * scale),
                y      : (int)(rect.Y * scale),
                width  : (int)(rect.Width * scale),
                height : (int)(rect.Height * scale)
            );
        }
    }
}

// Move this to Carbon.Geometry...
