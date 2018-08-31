namespace Carbon.Media
{
    public enum BlendMode : byte
    {
        Normal     = 0,  // css
        Add        = 1,  // 
        Burn       = 2,  // 
        Color      = 3,  // css
        ColorBurn  = 4,  // css
        ColorDodge = 5,  // css 
        Darken     = 6,  // css 
        Difference = 7,  // css
        Divide     = 8,  // 
        Dodge      = 9,  // 
        Exclusion  = 10, // css 
        HardLight  = 11, // css
        HardMix    = 12, // 
        Hue        = 13, // css
        Lighten    = 14, // css
        LinearBurn = 15, // 
        Luminosity = 16, // css
        Multiply   = 17, // css  
        Overlay    = 18, // css 
        Saturation = 19, // css
        Screen     = 20, // css
        SoftLight  = 21, // css 
        Subtract   = 22, // 
        VividLight = 23  //
    }

    // Linear Burn, Vivid Light, and Linear Dodge are not implemented in CSS
    // https://lists.w3.org/Archives/Public/www-style/2012Aug/0699.html

    // Add = addition

    // And
    // GrainMerge (ffmpeg) | GrainExtract
    // Freeze
    // ChromeKey (treshhold, smoothing)
    // Disolve (mix)
    // Pinlight (ffmpeg)
}
