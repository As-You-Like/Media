using System;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media
{
    public sealed class Resize : IProcessor
    {
        public Resize(Size size)
            : this(new Unit(size.Width), new Unit(size.Height), null, null, ResizeFlags.None)
        { }

        public Resize(Size size, CropAnchor? anchor)
            : this(new Unit(size.Width), new Unit(size.Height), anchor, null, ResizeFlags.None)
        { }

        public Resize(Unit width, Unit height, ResizeFlags flags = ResizeFlags.None)
            : this(width, height, null, null, flags) { }

        public Resize(Unit width, Unit height, CropAnchor? anchor, string background, ResizeFlags flags)
        {
            // 16384 * 16384 * 4 = 1GB bitmap

            #region Preconditions

            if (width < 0 || width > 6000)
                throw new ArgumentOutOfRangeException(nameof(width), width, message: "Must be between 0 and 6,000");

            if (height < 0 || height > 15000)
                throw new ArgumentOutOfRangeException(nameof(height), height, message: "Must be between 0 and 15,000");

            #endregion

            Width  = width;
            Height = height;
            Anchor = anchor;
            Background = background;
            Flags = flags;
        }

        public Unit Height { get; }

        public Unit Width { get; }

        public ResizeFlags Flags { get; }

        public CropAnchor? Anchor { get; }

        public string Background { get; }

        [IgnoreDataMember]
        public Size Size => new Size((int)Width.Value, (int)Height.Value);

        #region Flags

        public ResizeFlags Mode => Flags & ResizeFlags.Modes;

        public bool Carve => Flags.HasFlag(ResizeFlags.Carve);

        public bool Upscale => Flags.HasFlag(ResizeFlags.Upscale);

        #endregion

        public override string ToString()
        {
            if (Flags != ResizeFlags.None)
            {
                var sb = new StringBuilder(Width + "x" + Height);

                sb.Append("," + Flags.ToLower());

                if (Anchor != null)
                {
                    sb.Append(",anchor:");
                    sb.Append(Anchor.Value.ToCode());
                }
                if (Background != null)
                {
                    sb.Append(",background:");
                    sb.Append(Background);
                }

                return sb.ToString();
            }

            if (Anchor == null)
            {
                return Width + "x" + Height;
            }

            return $"{Width}x{Height}-{Anchor?.ToCode()}";
        }

        // 100x100,stretch,anchor:center,background:red

        public static Resize Parse(string segment)
        {
            #region Normalization

            int argStart = segment.IndexOf('(') + 1;

            if (argStart > 0)
            {
                segment = segment.Substring(argStart, segment.Length - argStart - 1);
            }

            #endregion

            if (segment.Contains(",") || segment.Contains("×") || segment.Contains("％"))
            {
                var parts = segment.Split(Seperators.Comma);

                var size = parts[0].Split('x', '×');

                var width  = Unit.Parse(size[0]);
                var height = Unit.Parse(size[1]);

                var flags = ResizeFlags.None;
                string background = null;
                CropAnchor? anchor = null;

                for (var i = 1; i < parts.Length; i++)
                {
                    var part = parts[i];

                    if (part.Contains(":"))
                    {
                        var arg = part.Split(Seperators.Colon);

                        var k = arg[0];
                        var v = arg[1];

                        switch (k)
                        {
                            case "anchor"     : anchor = AnchorHelper.Parse(v); break;
                            case "background" : background = v;                 break;
                            default           : throw new Exception("Unknown arg:" + k);
                        }
                    }
                    else
                    {
                        flags = ResizeFlagsHelper.Parse(part);
                    }
                }

                return new Resize(width, height, anchor, background, flags);
            }

            else if (segment.Contains("-"))
            {
                // {width}x{height}-{anchor}

                var parts = segment.Split(Seperators.Dash);

                return new Resize(
                    size   : Size.Parse(parts[0]),
                    anchor : AnchorHelper.Parse(parts[1])
                );
            }

            // 100x100
            return new Resize(Size.Parse(segment));
        }

        public static Resize operator * (Resize left, double scale)
        {
            var newSize = left.Size * scale;

            return new Resize(newSize.Width, newSize.Height, left.Anchor, left.Background, left.Flags);
        }
    }
}

/* 


100×100,contain;anchor:center

500×0
0×500

500x500;fit:crop;anchor:center
500x500(fit:crop;anchor:center)
500x500+x:100+y:200 

500x500(fit:crop anchor:center)
 
Image Magic : 
-resize 64x64
-crop 40x30+10+10  (width,height,top,left)

-crop <width>x<height>{+-}<x>{+-}<y>{%}

*/
