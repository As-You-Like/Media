using System;

namespace Carbon.Media
{
    public static class BlendModeHelper
    {
        public static bool TryParse(string text, out BlendMode result)
        {
            switch (text)
            {
                case "color"        : result = BlendMode.Color;      return true;
                case "color-burn"   : result = BlendMode.ColorBurn;  return true;
                case "color-dodge"  : result = BlendMode.ColorBurn;  return true;
                case "darken"       : result = BlendMode.Darken;     return true;
                case "difference"   : result = BlendMode.Difference; return true;
                case "exclusion"    : result = BlendMode.Exclusion;  return true;
                case "hard-light"   : result = BlendMode.HardLight;  return true;
                case "hue"          : result = BlendMode.Hue;        return true;
                case "lighten"      : result = BlendMode.Lighten;    return true;
                case "luminosity"   : result = BlendMode.Luminosity; return true;
                case "overlay"      : result = BlendMode.Overlay;    return true;
                case "saturation"   : result = BlendMode.Saturation; return true;
                case "screen"       : result = BlendMode.Screen;     return true;
                case "soft-light"   : result = BlendMode.SoftLight;  return true;

                // Aliases
                case "burn"  : result = BlendMode.ColorBurn; return true;
                case "dodge" : result = BlendMode.ColorDodge; return true;
            }

            return Enum.TryParse(text, true, out result);
        }

        public static BlendMode Parse(string text)
        {
            if (TryParse(text, out BlendMode mode))
            {
                return mode;
            }

            throw new InvalidValueException(nameof(BlendMode), text);
        }
    }
}
