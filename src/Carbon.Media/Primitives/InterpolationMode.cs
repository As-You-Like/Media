namespace Carbon.Media
{
    public enum InterpolaterMode
    {
        None        = 0,
        Point       = 1,
        Box         = 2,
        Linear      = 3,
        Gaussian    = 4,
        Quadratic   = 5,
        Cubic       = 6,
        Lanczos3    = 7, // Best for downscaling
        Spline36    = 8
    }

    public static class InterpolaterExtensions
    {
        public static string ToLower(this InterpolaterMode value) =>
            value.ToString().ToLower();
    }

    public static class InterpolaterHelper
    {
        public static InterpolaterMode Parse(string text) =>
            text.ToEnum<InterpolaterMode>(true);
    }
}
