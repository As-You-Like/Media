﻿using System;

namespace Carbon.Media
{
    [Flags]
    public enum ResizeFlags 
    {
        None      = 0,
        Exact     = 1 << 1, // Resize to the exact dimensions without regard to the aspect ratio
        Fit       = 1 << 2, // Fill the box while retaining the aspect ratio. Won't upscale unless upscale is also set, AKA CSS:contain
        Crop      = 1 << 3, // Fill the box, clipping as needed. background-sizing: cover. AKA Fill || CSS:cover
        Pad       = 1 << 4, // Center within the box, padding as needed

        // Portrait  = 1 << 5, // Resize to the height maintaing aspect
        // Landscape = 1 << 6, // Resize to the width maintaing aspect

        Modes    = Exact | Fit | Crop | Pad,

        Carve    = 1 << 10,  // Fill the box, carving as needed
        Upscale  = 1 << 11
    }
    
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
            #region Preconditions

            if (text == null)
                throw new ArgumentNullException(nameof(text));

            #endregion

            if (text.Contains("|"))
            {
                var flags = ResizeFlags.None;

                foreach (var part in text.Split(Seperators.Bar))
                {
                    if (Enum.TryParse(part, true, out ResizeFlags flag))
                    {
                        flags |= flag;
                    }
                    else
                    {
                        throw new Exception("invalid resize flag:" + part);
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


    // CSS Background Size Notes:
    // Cover: Scale the background image to be as large as possible so that the background area is completely covered by the background image. Some parts of the background image may not be in view within the background positioning area
    // Contain: Scale the image to the largest size such that both its width and its height can fit inside the content area

}
