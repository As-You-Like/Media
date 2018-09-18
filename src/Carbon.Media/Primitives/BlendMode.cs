namespace Carbon.Media
{
    public enum BlendMode : byte
    {
                         // | CSS         | Ffmpeg     |  Skia        |
        Normal     = 0,  // | normal      |            |  SrcOver     |
        Color      = 1,  // | color       |            |  Color       |
        ColorBurn  = 2,  // | color-burn  | burn       |  ColorBurn   | 
        ColorDodge = 3,  // | color-dodge | dodge      |  ColorDodge  |
        Darken     = 4,  // | darken      | darken     |  Darken      |
        Difference = 5,  // | difference  | difference |  Difference  |
        Exclusion  = 6,  // | exclusion   | exclusion  |  Exclusion   |
        HardLight  = 7,  // | hard-light  | hardlight  |  HardLight   |
        HardMix    = 8,  // |             | hardmix    |              |
        Hue        = 9,  // | hue         |            |  Hue         |
        Lighten    = 10, // | lighten     | lighten    |  Lighten     |
        LinearBurn = 11, // |             |            |              |
        Luminosity = 12, // |             |            |  Luminosity  |
        Multiply   = 13, // | luminosity  | multiply   |  Multiply    |
        Overlay    = 14, // | overlay     |            |  Overlay     |
        Saturation = 15, // | saturation  |            |  Saturation  |
        Screen     = 16, // | screen      | screen     |  Screen      |
        SoftLight  = 17, // | soft-light  | softlight  |  SoftLight   |
        VividLight = 18, // |             | vividlight |              |
                                                       
        // Porter-Duff                    |            |
        Clear   = 100,  //                |            |
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