namespace Carbon.Media
{
    public sealed class Overlay : ITransform
    {
        public Overlay(string o,
            Unit? x = null,
            Unit? y = null,
            Unit? width = null,
            Unit? height = null,
            Unit? padding = null,
            BlendMode mode = BlendMode.Normal,
            Alignment align = Alignment.Left)
        {
            Key = o;
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Padding = padding;
            BlendMode = mode;
            Align = align;
        }

        // color:
        // gradient:
        // image:
        // text:

        // Color, Gradient, Text, Image

        public string Key { get; set; }

        public BlendMode BlendMode { get; }

        public Alignment Align { get; } // Alignment within the box

        public ScaleMode ScaleMode { get; set; } // Scale within the box

        public Unit? X { get; set; }

        public Unit? Y { get; set; }

        public Unit? Width { get; set; }

        public Unit? Height { get; set; }

        public Unit? Padding { get; set; } // padding:5

        // overlay(hello,width:100,x:0,y:0,align:center)
        
        public static Overlay Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("overlay("))
            {
                key = key.Remove(0, 8); // text(

                key = key.Substring(0, key.Length - 1); // )
            }

            #endregion

            var parts = key.Split(Seperators.Comma);

            var name = parts[0];

            var mode = BlendMode.Normal;
            var align = Alignment.Left;

            Unit? x = null;
            Unit? y = null;
            Unit? width = null;
            Unit? height = null;
            Unit? padding = null;

            for (var i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                var k = part.Split(Seperators.Colon)[0];
                var v = part.Split(Seperators.Colon)[1];

                switch (k)
                {
                    case "mode"   : mode = v.ToEnum<BlendMode>(true);   break;
                    case "align"  : align = v.ToEnum<Alignment>(true);  break;
                    case "x"      : x = Unit.Parse(v); break;
                    case "y"      : y = Unit.Parse(v); break;
                    case "width"  : width = Unit.Parse(v); break;
                    case "height" : height = Unit.Parse(v); break;
                    case "padding": padding = Unit.Parse(v); break;
                }
            }

            return new Overlay(name, x, y, width, height, padding, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
