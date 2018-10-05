using System;
using System.Collections.Generic;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class TextObject : Shape
    {
        public TextObject(
            string text,
            Font font = null,

            string color = null)
        {
            Content = text ?? throw new ArgumentNullException(nameof(text));
            Font = font;
            Color = color;
        }

        public string Content { get; }

        public string Color { get; }

        public Font Font { get; }

        internal IEnumerable<Argument> GetArguments()
        {
            if (Color != null) yield return new Argument("color", Color);
            if (Font != null) yield return new Argument("font", Font.ToString());
        }

        // text(hello+world,font:12px Tacoma,align:center)

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("text(");

            sb.Append(Content);

            foreach (var (key, value) in GetArguments())
            {
                sb.Append(',');

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(')');
        }

        public override string ToString()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public static TextObject Create(in CallSyntax syntax)
        {
            (_, var content) = syntax.Arguments[0]; // TODO: Base64 support


            string color = null;
            Font font = null;

            for (int i = 1; i < syntax.Arguments.Length; i++)
            {
                var (k, v) = syntax.Arguments[i];

                switch (k)
                {
                    case "font": font = Font.Parse(v); break;
                    case "color": color = v; break;
                }
            }

            return new TextObject(content, font, color);
        }
    }
}

/* 
text(hello+world,font:Tacoma,size:12px)
*/
