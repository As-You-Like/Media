using System;

namespace Carbon.Media
{
    public enum InterpolaterMode : byte
    {
        //                                                             | FF | IS | MS |
        None            = 0,  //                                       ----------------
        NearestNeighbor = 1,  // AKA Point                             | x  |    | x  | 
        Box             = 2,  // AKA Average                           |    | x  | x  |
        Bilinear        = 3,  // AKA Linear, Bilinear, Triangle, Tent  | x  |    | x  |
        Bicubic         = 4,  //                                       | x  | x  |    | 
        CatmullRom      = 5,  //                                       |    | x  | x  | 
        Cubic           = 6,  //                                       |    |    | x  |  
        CubicSmoother   = 7,  //                                       |    |    | x  | 
        Gaussian        = 8,  //                                       | x  |    |    | 
        Hermite         = 9,  //                                       |    | x  |    |
        Lanczos2        = 10, //                                       |    | x  |    |
        Lanczos3        = 11, //                                       |    | x  | x  |                  
        Lanczos5        = 12, //                                       |    | x  |    |
        Lanczos8        = 13, //                                       |    |    |    |
        Mitchell        = 14, // Mitchell-Netravali                    |    | x  | x  |
        Quadratic       = 15, //                                       |    |    | x  |
        Robidoux        = 16, //                                       |    | x  |    |
        Spline36        = 17  //                                       |    |    | x  |
    }

    // Bicc, Triangle, Welch, Sinc (ffmpeg)

    public static class InterpolaterExtensions
    {
        public static string ToLower(this InterpolaterMode value)
        {
            switch (value)
            {
                case InterpolaterMode.Lanczos3: return "lanczos3";
            }

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
            }

            if (Enum.TryParse(text, true, out InterpolaterMode mode))
            {
                return mode;
            }

            throw new InvalidValueException(nameof(InterpolaterMode), text);
        }
    }
}