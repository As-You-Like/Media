namespace Carbon.Media
{
    public enum BlendMode : byte
    {
                          // | CSS         | Ffmpeg     |  Skia        | Photoshop          | Figma
        Normal      = 0,  // | normal      |            |  SrcOver     | Normal             |
        Color       = 1,  // | color       |            |  Color       | Color              | COLOR
        ColorBurn   = 2,  // | color-burn  | burn       |  ColorBurn   | Color Burn         | COLOR_BURN
        ColorDodge  = 3,  // | color-dodge | dodge      |  ColorDodge  | Color Dodge        | COLOR_DODGE
        Darken      = 4,  // | darken      | darken     |  Darken      | Darken             | DARKEN
        Difference  = 5,  // | difference  | difference |  Difference  | Difference         | DIFFERENCE
        Exclusion   = 6,  // | exclusion   | exclusion  |  Exclusion   | Exclusion          | EXCLUSION
        HardLight   = 7,  // | hard-light  | hardlight  |  HardLight   | Hard Light         | HARD_LIGHT
        HardMix     = 8,  // |             | hardmix    |              | Hard Mix           |
        Hue         = 9,  // | hue         |            |  Hue         | Hue                | HUE
        Lighten     = 10, // | lighten     | lighten    |  Lighten     | Lighten            | LIGHTEN
        LinearBurn  = 11, // |                                         | Linear Burn        | LINEAR_BURN
        LinearDodge = 12, // |                                         | Linear Dodge       | LINEAR_DODGE
        Luminosity  = 13, // |             |            |  Luminosity  | Luminosity         | LUMINOSITY
        Multiply    = 14, // | luminosity  | multiply   |  Multiply    | Multiply           | MULTIPLY
        Overlay     = 15, // | overlay     |            |  Overlay     | Overlay            | OVERLAY
        Saturation  = 16, // | saturation  |            |  Saturation  | Saturation         | SATURATION
        Screen      = 17, // | screen      | screen     |  Screen      | Screen             | SCREEN
        SoftLight   = 18, // | soft-light  | softlight  |  SoftLight   | Soft Light         | SOFT_LIGHT
        VividLight  = 18, // |             | vividlight |              | Vivid Light        |
                                                                                           
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