using System;

namespace Carbon.Media
{
    public static class ResizeFlagsHelper
    {
        public static ResizeFlags Parse(string text)
        {
            if (text is null)
                throw new ArgumentNullException(nameof(text));

            if (text.Contains("|"))
            {
                var flags = ResizeFlags.None;

                foreach (string part in text.Split(Seperators.Bar))
                {
                    if (Enum.TryParse(part, true, out ResizeFlags flag))
                    {
                        flags |= flag;
                    }
                    else
                    {
                        throw new Exception("Invalid resize flag:" + part);
                    }

                    flags |= part.ToEnum<ResizeFlags>(true);
                }

                return flags;
            }
            else
            {
                return text.ToEnum<ResizeFlags>(true);
            }
        }
    }
}

// CSS Background Size Notes:
// Cover: Scale the background image to be as large as possible so that the background area is completely covered by the background image. Some parts of the background image may not be in view within the background positioning area
// Contain: Scale the image to the largest size such that both its width and its height can fit inside the content area
