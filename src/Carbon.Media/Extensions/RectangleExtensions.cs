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

        public static Rectangle Scale(this Rectangle rect, double xScale, double yScale) =>
           new Rectangle(
               x      : (int)(rect.X * xScale),
               y      : (int)(rect.Y * yScale),
               width  : (int)(rect.Width * xScale),
               height : (int)(rect.Height * yScale)
           );
    }
}