using System;

namespace Carbon.Media
{
    // Stretch by default to match web behavior?

    [Flags]
    public enum ScaleMode // ResizeFlags ?
    {
        None     = 0,
        Fit      = 1 << 1,  // Fill the box while retaining the aspect ratio. Won't upscale unless provided with upscale flag.
        Crop     = 1 << 2,  // Fill the box, clipping as needed. background-sizing: cover. AKA fill
        Pad      = 1 << 3,  // Center within the box, padding as needed
        Stretch  = 1 << 4,  // Fill the box
        Carve    = 1 << 5,  // Fill the box, carving as needed

        Upscale  = 1 << 6
    }

    // 100x100,x:0,y:100/
    // 100x100,anchor:center/
    // 100x100,carve

    // | Upscale
   

    // CSS Background Size Notes:
    // Cover: Scale the background image to be as large as possible so that the background area is completely covered by the background image. Some parts of the background image may not be in view within the background positioning area
    // Contain: Scale the image to the largest size such that both its width and its height can fit inside the content area

}
