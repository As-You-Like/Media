namespace Carbon.Media.Processors
{
    public sealed class DrawGradient : DrawBase
    {
        public DrawGradient(
            string o,
            UnboundBox box,
            BlendMode blendMode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, blendMode, ResizeFlags.None)
        {
            Gradient = o;
        }
        
        public string Gradient { get; }

        public override string Canonicalize() =>  null;

        public static DrawGradient Parse(string key)
        {
            #region Normalization

            int argStart = key.IndexOf('(') + 1;

            key = key.Substring(argStart, key.Length - argStart - 1);

            #endregion

            var parts = key.Split(Seperators.Comma);

            var name = parts[0];

            var mode  = BlendMode.Normal;
            var align = Alignment.Left;

            var box = new UnboundBox();

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
                    case "padding": box.Padding = UnboundPadding.Parse(v);   break;
                }
            }

            return new DrawGradient(name, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
