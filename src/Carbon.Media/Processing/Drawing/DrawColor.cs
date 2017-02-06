using System;

namespace Carbon.Media
{
    public sealed class DrawColor : DrawBase
    {
        public DrawColor(
            string color,
            Box box,
            BlendMode mode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, mode, ResizeFlags.None)
        {
            #region Preconditions

            if (color == null)
            {
                throw new ArgumentNullException(nameof(color));
            }

            #endregion

            Color = color;
        }

        public string Color { get; set; }

        public static DrawColor Parse(string key)
        {
            #region Normalization

            int argStart = key.IndexOf('(') + 1;

            key = key.Substring(argStart, key.Length - argStart - 1);

            #endregion

            var parts = key.Split(Seperators.Comma);

            var color = parts[0];

            var mode  = BlendMode.Normal;
            Alignment? align = null;

            var box = new Box();

            for (var i = 1; i < parts.Length; i++)
            {
                var arg = parts[i].Split(Seperators.Colon);

                var k = arg[0];
                var v = arg[1];

                switch (k)
                {
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true);  break;
                    case "align"  : align       = v.ToEnum<Alignment>(true);  break;
                    case "x"      : box.X       = Unit.Parse(v);              break;
                    case "y"      : box.Y       = Unit.Parse(v);              break;
                    case "width"  : box.Width   = Unit.Parse(v);              break;
                    case "height" : box.Height  = Unit.Parse(v);              break;
                    case "padding": box.Padding = Padding.Parse(v);           break;
                }
            }

            return new DrawColor(color, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
