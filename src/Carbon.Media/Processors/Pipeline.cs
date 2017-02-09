using Carbon.Geometry;

namespace Carbon.Media
{
    public class Pipeline
    {
        // Orient (flip, rotate, etc)
        // Crop source
        // Determine canvas size
        // Determine target pixel format     (does the source have an alpha channel? do any of the filters apply an alpha?)
        // Determine color model
        // Determine target color space

        // 1. orient
        
        // 2. crop the source
        public Rectangle Crop { get; set; }   // The crop applied to the source

        // 3. Scale the crop w/ interpolator
        public Scale Scale { get; set; }
        
        // If the resize mode was set to pad... 
        public Margin Margin { get; }

        public string Background { get; set; }

        public int X { get; } // X-Cordinate to draw the scaled image at

        public int Y { get; } // Y-Cordinate to draw the scaled image at

        public int Width => Scale.Width + Margin.Left + Margin.Right;

        public int Height => Scale.Height + Margin.Top + Margin.Bottom;

        // 4. Determine whether we need a canvas to apply filters or draw a background
        public IFilter[] Filters { get; set; }
    
        
        public Encode Encode { get; set; }

        // Final Clip (we may overdraw for blurs)
    }

    
    public struct Margin
    {
        public int Left;
        public int Right;
        public int Bottom;
        public int Top;
       
    }

    public class Draw
    {
        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Background { get; set;  }
    }

    // how can we define a canvas?

    // Canvas(500,500, color: red)
    // Padding becomes margin in draw phase...

    // blob#100 |> crop(0,0,100,100) |> scale(50,50,lancoz) |> draw(background:0xffffff,margin:10) |> encode(JPEG)

    
    // blob#100 |> crop(0,0,100,100) |> scale(50,50,lancoz) |> draw(background:0xffffff,margin:10) |> pixelate(5px) |> blur(5px) |> sepia(0.5) |> encode(JPEG)


    // encode(rect, "format")

}
