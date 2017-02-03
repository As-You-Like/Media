namespace Carbon.Media
{
    public sealed class DrawGradient : DrawBase
    {
        public DrawGradient(
            string o,
            Box box,
            BlendMode blendMode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, blendMode, ScaleMode.None)
        {
            Gradient = o;
        }
        
        public string Gradient { get; }
        
        public static DrawGradient Parse(string key)
        {
            #region Normalization

            var argStart = key.IndexOf('(') + 1;

            if (argStart > 0)
            {
                key = key.Substring(argStart, key.Length - argStart - 1);
            }

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
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true); break;
                    case "align"  : align       = v.ToEnum<Alignment>(true); break;
                    case "x"      : box.X       = Unit.Parse(v);             break;
                    case "y"      : box.Y       = Unit.Parse(v);             break;
                    case "width"  : box.Width   = Unit.Parse(v);             break;
                    case "height" : box.Height  = Unit.Parse(v);             break;
                    case "padding": box.Padding = Padding.Parse(v);          break;
                }
            }

            return new DrawGradient(name, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
