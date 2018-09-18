using System;
using System.Drawing;

namespace Carbon.Media
{
    public static class SizeHelper
    {
        public static Size Parse(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));

            int indexOfX = text.IndexOf('x');

            if (indexOfX == -1)
            {
                throw new ArgumentException($"Invalid size. Was '{text}'.");
            }

            return new Size(
                width: int.Parse(text.Substring(0, indexOfX)),
                height: int.Parse(text.Substring(indexOfX + 1))
            );
        }

        public static bool TryParse(string text, out Size size)
        {
            int indexOfX = text is null ? -1 : text.IndexOf('x');
            
            if (indexOfX > 0 &&
                int.TryParse(text.Substring(0, indexOfX), out int width) &&
                int.TryParse(text.Substring(indexOfX + 1), out int height))
            {
                size = new Size(width, height);
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