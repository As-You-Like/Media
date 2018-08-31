using System;

namespace Carbon.Media
{
    public static class ColorSpaceHelper
    {
        public static ColorSpace Parse(string text)
        {
            switch (text.ToLower())
            {
                case "hsl"  : return ColorSpace.HSL;
                case "srgb" : return ColorSpace.sRGB;
                  
            }

            Enum.TryParse(text, true, out ColorSpace result);

            return result;
        }


        public static string Canonicalize(this ColorSpace colorSpace)
        {
            switch (colorSpace)
            {
                case ColorSpace.sRGB     : return "sRGB";
                case ColorSpace.AdobeRGB : return "AdobeRGB";
                case ColorSpace.CMYK     : return "CMYK";
                case ColorSpace.HSL      : return "HSL";
            }
            return colorSpace.ToString();
        }
    }
}

// https://en.wikipedia.org/wiki/List_of_color_spaces_and_their_uses