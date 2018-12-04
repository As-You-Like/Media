using System;

namespace Carbon.Media
{
    public readonly struct Illuminant : IEquatable<Illuminant>
    {
        public static Illuminant A   = new Illuminant(0.44757, 0.40745);
        public static Illuminant D50 = new Illuminant(0.34567, 0.35850); // Horizon Light. ICC profile PCS | CIE 1931 2°
        public static Illuminant D55 = new Illuminant(0.33242, 0.34743); // Mid-morning / Mid-afternoon Daylight
        public static Illuminant D65 = new Illuminant(0.31271, 0.32902); // Noon Daylight: Television, sRGB color space
        public static Illuminant D75 = new Illuminant(0.29902, 0.31485); // North sky Daylight

        public static Illuminant F1  = new Illuminant(0.31310, 0.33727); 
        public static Illuminant F2  = new Illuminant(0.37208, 0.37529); 
        public static Illuminant F3  = new Illuminant(0.40910, 0.39430); 
        public static Illuminant F4  = new Illuminant(0.44018, 0.40329); 
        public static Illuminant F5  = new Illuminant(0.31379, 0.34531); // Daylight Fluorescent
        public static Illuminant F6  = new Illuminant(0.37790, 0.38835); 
        public static Illuminant F7  = new Illuminant(0.31292, 0.32933); 
        public static Illuminant F8  = new Illuminant(0.34588, 0.35875); 
        public static Illuminant F9  = new Illuminant(0.37417, 0.37281); 
        public static Illuminant F10 = new Illuminant(0.34609, 0.35986);
        public static Illuminant F11 = new Illuminant(0.38052, 0.37713);
        public static Illuminant F12 = new Illuminant(0.43695, 0.40441);

        public Illuminant(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; }

        public double Y { get; }

        public bool Equals(Illuminant other)
        {
            return X == other.Y && Y == other.Y;
        }

        // TODO: Parse
    }
}

// https://en.wikipedia.org/wiki/Standard_illuminant#CIE_illuminants