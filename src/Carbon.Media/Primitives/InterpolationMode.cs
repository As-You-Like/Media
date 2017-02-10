namespace Carbon.Media
{
    public enum InterpolaterMode
    {
        Unknown     = 0,
        Point       = 1,
        Box         = 2,
        Linear      = 3,
        Gaussian    = 4,
        Quadratic   = 5,
        Cubic       = 6,
        Lanczos3    = 7,
        Spline36    = 8
    }

    public static class InterpolaterExtensions
    {
        public static string ToLower(this InterpolaterMode value) =>
            value.ToString().ToLower();
    }

    public static class InterpolaterHelper
    {
        public static InterpolaterMode Parse(string text)
        {
            return text.ToEnum<InterpolaterMode>(true);
        }
    }
}
