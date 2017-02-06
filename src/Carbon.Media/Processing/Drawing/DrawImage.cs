using System;

namespace Carbon.Media
{
    public sealed class DrawImage : DrawBase
    {
        public DrawImage(       
            string src,
            Box box,
            BlendMode blendMode = BlendMode.Normal,
            Alignment align = Alignment.Left)
            : base(box, align, blendMode, ResizeFlags.None)
        {
            #region Preconditions

            if (src == null)
                throw new ArgumentNullException(nameof(src));
 
            #endregion

            Src = src;
        }

        public string Src { get; set; }

        // image(src.jpeg,width:100,x:0,y:0,align:center)
        
        public static DrawImage Parse(string key)
        {
            #region Normalization

            int argStart = key.IndexOf('(') + 1;

            key = key.Substring(argStart, key.Length - argStart - 1);

            #endregion

            var parts = key.Split(Seperators.Comma);

            var name = parts[0];

            var mode  = BlendMode.Normal;
            var align = Alignment.Left;

            var box = new Box();

            for (var i = 1; i < parts.Length; i++)
            {
                var arg = parts[i].Split(Seperators.Colon);

                var k = arg[0];
                var v = arg[1];

                switch (k)
                {
                    case "mode"   : mode = v.ToEnum<BlendMode>(true);   break;
                    case "align"  : align = v.ToEnum<Alignment>(true);  break;
                    case "x"      : box.X = Unit.Parse(v);              break;
                    case "y"      : box.Y = Unit.Parse(v);              break;
                    case "width"  : box.Width = Unit.Parse(v);          break;
                    case "height" : box.Height = Unit.Parse(v);         break;
                    case "padding": box.Padding = Padding.Parse(v);     break;
                }
            }

            return new DrawImage(name, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
