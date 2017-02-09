namespace Carbon.Media
{
    public enum InterpolaterMode
    {
        Point,
        Box,
        Linear,
        Gaussian,
        Quadratic,
        Cubic,
        Lanczos3,
        Spline36
    }


    public static class InterpolaterExtensions
    {
        public static string ToLower(this InterpolaterMode value)
        {
            return value.ToString().ToLower();
        }
    }

    public static class InterpolaterHelper
    {
        public static InterpolaterMode Parse(string text)
        {
            return text.ToEnum<InterpolaterMode>(true);
        }
    }
}
