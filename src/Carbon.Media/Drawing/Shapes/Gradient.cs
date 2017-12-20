using System;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class Gradient : Shape
    {
        public Gradient(
            string content,
            UnboundBox box,
            BlendMode blendMode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, blendMode, ResizeFlags.None)
        {
            Content = content;
        }
        
        public string Content { get; }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("gradient(");

            foreach (var (key, value) in Args())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public static new Gradient Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            var args = ArgumentList.Parse(text.Substring(argStart, text.Length - argStart - 1));

            (_, var name) = args[0];

            var mode  = BlendMode.Normal;
            var align = Alignment.Left;

            var box = new UnboundBox();

            for (var i = 1; i < args.Length; i++)
            {
                var (k, v) = args[i];
                
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

            return new Gradient(name, box, mode, align);
        }
    }
}

/*
overlay(red,mode:burn)
*/
