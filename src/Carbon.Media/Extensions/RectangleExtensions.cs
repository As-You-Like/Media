namespace Carbon.Geometry
{
    public static class RectangleExtensions
    {
        // TODO: Origin

        public static Rectangle Scale(this Rectangle rect, double scale) =>
            new Rectangle(
                x      : (int)(rect.X * scale),
                y      : (int)(rect.Y * scale),
                width  : (int)(rect.Width * scale),
                height : (int)(rect.Height * scale)
            );
    }
}