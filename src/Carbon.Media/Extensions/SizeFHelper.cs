using System;
using System.Drawing;

namespace Carbon.Media
{
    public static class SizeFHelper
    {
        public static SizeF Parse(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));

            int indexOfX = text.IndexOf('x');

            if (indexOfX == -1)
            {
                throw new ArgumentException($"Invalid size. Was '{text}'.");
            }

            return new SizeF(
                width: float.Parse(text.Substring(0, indexOfX)),
                height: float.Parse(text.Substring(indexOfX + 1))
            );
        }

        public static bool TryParse(string text, out SizeF size)
        {
            int indexOfX = text is null ? -1 : text.IndexOf('x');

            if (indexOfX > 0 &&
                float.TryParse(text.Substring(0, indexOfX), out float width) &&
                float.TryParse(text.Substring(indexOfX + 1), out float height))
            {
                size = new SizeF(width, height);
                return true;
            }
            else
            {
                size = default;

                return false;
            }
        }
    }
}