namespace Carbon.Media.Processors
{
    public sealed class DrawCircle : DrawBase
    {
        public DrawCircle(
            int radius,
            UnboundBox box,
            BlendMode mode = BlendMode.Normal)
            : base(box, null, mode, ResizeFlags.None)
        {
            Radius = radius;
        }
        
        public int Radius { get; set; }

        public string Stroke { get; set; }

        public string Fill { get; set; }
            
        public override string Canonicalize() => null;

        public static DrawCircle Parse(string key)
        {
            #region Normalization

            int argStart = key.IndexOf('(') + 1;

            key = key.Substring(argStart, key.Length - argStart - 1);

            #endregion

            var parts = key.Split(Seperators.Comma);

            var radius = int.Parse(parts[0]);

            var mode  = BlendMode.Normal;

            string stroke = null;
            string fill = null;

            var box = new UnboundBox();

            for (var i = 1; i < parts.Length; i++)
            {
                var arg = parts[i].Split(Seperators.Colon);

                var k = arg[0];
                var v = arg[1];

                switch (k)
                {
                    case "fill"   : fill = v;   break;
                    case "stroke" : stroke = v; break;
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true);  break;
                    case "x"      : box.X       = Unit.Parse(v);              break;
                    case "y"      : box.Y       = Unit.Parse(v);              break;
                    case "width"  : box.Width   = Unit.Parse(v);              break;
                    case "height" : box.Height  = Unit.Parse(v);              break;
                    case "padding": box.Padding = UnboundPadding.Parse(v);    break;
                }
            }

            return new DrawCircle(radius, box, mode);
        }
    }
}

/*
path(M150 0 L75 200 L225 200 Z,stroke:red,fill:black)
*/
