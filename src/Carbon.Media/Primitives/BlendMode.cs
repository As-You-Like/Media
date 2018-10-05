namespace Carbon.Media
{
    public enum BlendMode : byte
    {
                         // | CSS         | Ffmpeg     |  Skia        | Photoshop
        Normal     = 0,  // | normal      |            |  SrcOver     | Normal
        Color      = 1,  // | color       |            |  Color       | Color
        ColorBurn  = 2,  // | color-burn  | burn       |  ColorBurn   | Color Burn
        ColorDodge = 3,  // | color-dodge | dodge      |  ColorDodge  | Color Dodge
        Darken     = 4,  // | darken      | darken     |  Darken      | Darken
        Difference = 5,  // | difference  | difference |  Difference  | Difference
        Exclusion  = 6,  // | exclusion   | exclusion  |  Exclusion   | Exclusion
        HardLight  = 7,  // | hard-light  | hardlight  |  HardLight   | Hard Light
        HardMix    = 8,  // |             | hardmix    |              | Hard Mix
        Hue        = 9,  // | hue         |            |  Hue         | Hue
        Lighten    = 10, // | lighten     | lighten    |  Lighten     | Lighten
        Luminosity = 11, // |             |            |  Luminosity  | Luminosity
        Multiply   = 12, // | luminosity  | multiply   |  Multiply    | Multiply
        Overlay    = 13, // | overlay     |            |  Overlay     | Overlay
        Saturation = 14, // | saturation  |            |  Saturation  | Saturation
        Screen     = 15, // | screen      | screen     |  Screen      | Screen
        SoftLight  = 16, // | soft-light  | softlight  |  SoftLight   | Soft Light
        VividLight = 17, // |             | vividlight |              | Vivid Light

        // Porter-Duff Modes ---------------------------------------------------------------
        Clear   = 100,  //                |            |              | Clear
        Dst     = 101,  //                |            |
        DstATop = 102,  //
        DstIn   = 103,  //                |            |
        DstOut  = 104,  //                |            |
        DstOver = 105,  //                |            |
        Src     = 106,  //                |            |
        SrcATop = 107,  //                |            |
        SrcIn   = 108,  //                |            |
        SrcOut  = 109,  //                |            |
        SrcOver = 110,  //                |            |
        Xor     = 111,  //                | xor        |
        Plus    = 112,  //                |            |
                                      
        Modulate = 120                                 


    }

    // Additional Photoshop Blend Modes: Dissolve, Behind, Linear Burn, Linear Dodge (Add), Linear Light, Pin Light, Subtract, Divide, 

}

// http://ssp.impulsetrain.com/porterduff.html

// Src = Copy
// Plus = lighter

// Linear Burn, Vivid Light, and Linear Dodge are not implemented in CSS
// https://lists.w3.org/Archives/Public/www-style/2012Aug/0699.html

// Add = addition

// And
// GrainMerge (ffmpeg) | GrainExtract
// Freeze
// ChromeKey (treshhold, smoothing)
// Disolve (mix)
// Pinlight (ffmpeg)