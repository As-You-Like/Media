using System;

namespace Carbon.Media
{
    public static class PixelFormatHelper
    {
        public static PixelFormat Parse(string text)
        {
            Enum.TryParse(text, out PixelFormat format);

            return format;
        }
    }
}