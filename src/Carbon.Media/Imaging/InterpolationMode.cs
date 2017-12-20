namespace Carbon.Media
{
    public enum InterpolaterMode : byte
    {
        None            = 0,
        NearestNeighbor = 1, // AKA Point
        Box             = 2, // AKA Average
        Bilinear        = 3, // AKA Linear, Bilinear, Triangle, Tent
        CatmullRom      = 4, // AKA Catrom
        Cubic           = 5,
        CubicSmoother   = 6,
        Gaussian        = 7,
        Hermite         = 8,
        Lanczos2        = 9,  
        Lanczos3        = 10,
        Lanczos5        = 11,
        Lanczos8        = 12,
        Mitchell        = 13, // Mitchell-Netravali
        Quadratic       = 14,
        Robidoux        = 15,
        RobidouxSharp   = 16,
        Spline36        = 17 // ???
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
            switch (text)
            {
                case "box"     : return InterpolaterMode.Box;
                case "lanczos" : return InterpolaterMode.Lanczos3;
                default        : return text.ToEnum<InterpolaterMode>(true);
            }
        }
    }
}