using System;

namespace Carbon.Media
{
    public static class PixelFormatHelper
    {
        public static PixelFormat Parse(string text)
        {
            // Aliases
            switch (text)
            {
                case "bgra": return PixelFormat.Bgra32;
                case "rgba": return PixelFormat.Rgba32;
                case "gray": return PixelFormat.Gray8;
            }

            Enum.TryParse(text, ignoreCase: true, out PixelFormat format);

            return format;
        }
    }
}