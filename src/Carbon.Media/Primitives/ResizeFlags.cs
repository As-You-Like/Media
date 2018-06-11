using System;

namespace Carbon.Media
{
    [Flags]
    public enum ResizeFlags 
    {
        None     = 0,
        Exact    = 1 << 0,  // Resize to the exact dimensions without regard to the aspect ratio
        Crop     = 1 << 1,  // Fill the box, clipping as needed to maintain the aspect ratio
        Pad      = 1 << 2,  // Center within the box, padding as needed
        Fit      = 1 << 3,  // Fit the image in the box while maintaining the aspect ratio
        
        Modes    = Exact | Crop | Pad | Fit,

        Carve   = 1 << 10,  // Fill the box, carving as needed
        Upscale = 1 << 11,

        Contain = Pad | Upscale, // Fill the box, padding as needed to maintain the aspect ratio.
        Cover   = Crop           // Fill the box, clipping as needed to maintain the aspect ratio
    }

    // Portrait  = 1 << 5, // Resize to the height maintaing aspect
    // Landscape = 1 << 6, // Resize to the width maintaing aspect
    
    public static class ResizeFlagsExtensions
    {
        public static string ToLower(this ResizeFlags flags)
        {
            return flags.ToString().Replace(", ", "|").ToLower();
        }
    }

    public static class ResizeFlagsHelper
    {
        public static ResizeFlags Parse(string text)
        {
            if (text == null)
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
