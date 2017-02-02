using System;

namespace Carbon.Media
{
    public sealed class DrawText : ITransform
    {
        public DrawText(
            string text,
            Font? font = null,
            Alignment align = Alignment.Left,
            int? x = null,
            int? y= null, 
            int? width = null, 
            string color = null)
        {
            Text = text;
            Font = font ?? new Media.Font("Arial");
            Align = align;
            X = x;
            Y = y;
            Width = width;
            Color = color;
        }

        public string Text { get; }

        public int? X { get; }

        public int? Y { get; }

        public int? Width { get; }

        public string Color { get; }

        public Alignment Align { get; }

        public Font Font { get; }
        
        // text(hello+world,font:12px Tacoma,align:center)

        public static DrawText Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("text("))
            {
                key = key.Remove(0, 5); // text(
                
                key = key.Substring(0, key.Length - 1); // )
            }

            #endregion

            var parts = key.Split(Seperators.Comma);

            var text = parts[0];

            int? x = null;
            int? y = null;
            int? width = null;
            string color = null;
            Alignment align = Alignment.Left;
            Font? font = null;

            for (var i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                var k = part.Split(Seperators.Colon)[0];
                var v = part.Split(Seperators.Colon)[1];

                switch (k)
                {
                    case "align"    : align = (Alignment)Enum.Parse(typeof(Alignment), v, true); break;
                    case "x"        : x = int.Parse(v);                                          break;
                    case "y"        : y = int.Parse(v);                                          break;
                    case "font"     : font = Media.Font.Parse(v);                                break;
                    case "width"    : width = int.Parse(v);                                      break;
                    case "color"    : color = v;                                                 break;
                }

            }

            return new DrawText(text, font, align, x, y, width, color);
        }
    }


    public struct Font
    {
        // bold 
        public Font(string name, string weight = "normal", int size = 12)
        {
            Size = size;
            Weight = weight;
            Name = name;
        }

        public string Name { get; }

        public string Weight { get; }

        // TODO: Support other units than pixels...
        public int Size { get; }

        public static Font Parse(string text)
        {
            var parts = text.Split(Seperators.Space);

            if (parts.Length == 1) return new Font(text);
            
            // 12px Name

            return new Font(parts[1]);
        }
    }
}

/* 
text(hello+world,font:Tacoma,size:12px)
*/