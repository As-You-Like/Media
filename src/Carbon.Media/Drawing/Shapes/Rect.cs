﻿using System;
using System.Text;

namespace Carbon.Media.Drawing
{
    public sealed class Rect : Shape
    {
        public Rect(
            string color,
            UnboundBox box,
            BlendMode mode = BlendMode.Normal,
            Alignment? align = null)
            : base(box, align, mode, ResizeFlags.None)
        {
            Fill = color ?? throw new ArgumentNullException(nameof(color));
        }
        
        public string Fill { get; set; }

        public override void WriteTo(StringBuilder sb)
        {
            sb.Append("retangle(");
            
            foreach (var (key, value) in Args())
            {
                sb.Append(",");

                sb.Append(key);
                sb.Append(':');
                sb.Append(value);
            }

            sb.Append(")");
        }

        public static new Rect Parse(string key)
        {
            int argStart = key.IndexOf('(') + 1;
         
            var args = ArgumentList.Parse(key.Substring(argStart, key.Length - argStart - 1));

            string fill = null;
            var mode  = BlendMode.Normal;
            Alignment? align = null;

            var box = new UnboundBox();

            var i = 0;

            foreach(var (k, v) in args)
            {
                if (k == null) // positional
                {
                    switch (i)
                    {
                        case 0: box.Width = Unit.Parse(v);  break;
                        case 1: box.Height = Unit.Parse(v); break;
                        case 2: fill = v;                  break;
                    }

                    i++;

                    continue;
                }
                

                switch (k)
                {
                    case "fill"   : fill       = v;                          break;
                    case "mode"   : mode        = v.ToEnum<BlendMode>(true);  break;
                    case "align"  : align       = v.ToEnum<Alignment>(true);  break;
                    case "x"      : box.X       = Unit.Parse(v);              break;
                    case "y"      : box.Y       = Unit.Parse(v);              break;
                    case "width"  : box.Width   = Unit.Parse(v);              break;
                    case "height" : box.Height  = Unit.Parse(v);              break;
                    case "padding": box.Padding = UnboundPadding.Parse(v);    break;
                }
                
            }

            return new Rect(fill, box, mode, align);
        }
    }
}

/*
rectangle(100,100,red,mode:burn)
*/