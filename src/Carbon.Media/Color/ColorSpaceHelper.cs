using System;

namespace Carbon.Media
{
    public static class ColorSpaceHelper
    {
        public static bool TryParse(string text, out ColorSpace colorSpace)
        {
            if (text.AsSpan().Equals("grayscale".AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                colorSpace = ColorSpace.Gray;

                return true;
            }

            else if (text.AsSpan().Equals("rgb".AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                colorSpace = ColorSpace.RGB;

                return true;
            }

            else if (text.AsSpan().Equals("srgb".AsSpan(), StringComparison.OrdinalIgnoreCase))
            {
                colorSpace = ColorSpace.sRGB;

                return true;
            }

            return Enum.TryParse(text, ignoreCase: true, out colorSpace);
        }

        public static ColorSpace Parse(string text)
        {
            return TryParse(text, out ColorSpace colorSpace) 
                ? colorSpace 
                : throw new InvalidValueException(nameof(ColorSpace), text);
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