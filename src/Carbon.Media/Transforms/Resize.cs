using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public sealed class Resize : ITransform
    {
        public Resize(Size size)
            : this(size.Width, size.Height)
        { }

        public Resize(Size size, CropAnchor? anchor)
            : this(size.Width, size.Height, ScaleMode.None, anchor)
        { }

        public Resize(int width, int height, ScaleMode mode = ScaleMode.None, CropAnchor? anchor = null)
        {
            #region Preconditions

            if (width < 0 || width > 6000)
                throw new ArgumentOutOfRangeException(nameof(width), width, message: "Must be between 0 and 6,000");

            if (height < 0 || height > 15000)
                throw new ArgumentOutOfRangeException(nameof(height), height, message: "Must be between 0 and 15,000");

            #endregion

            Width  = width;
            Height = height;
            Mode   = mode;
            Anchor = anchor;
        }

        public int Height { get; }

        public int Width { get; }

        public ScaleMode Mode { get; }

        public CropAnchor? Anchor { get; }

        [IgnoreDataMember]
        public Size Size => new Size(Width, Height);

        public override string ToString()
        {
            if (Anchor == null)
            {
                return Width + "x" + Height;
            }

            return $"{Width}x{Height}-{Anchor?.ToCode()}";
        }

        // 100x100,anchor:center,mode:stretch

        public static Resize Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("resize("))
            {
                key = key.Remove(0, 7);

                key = key.Substring(0, key.Length - 1); // Trim )
            }

            #endregion

            if (key.Contains(","))
            {
                // anchor
                // mode
            }

            if (key.Contains("-"))
            {
                // {width}x{height}-{anchor}

                var parts = key.Split(Seperators.Dash);

                return new Resize(
                    size   : Size.Parse(parts[0]),
                    anchor : AnchorHelper.Parse(parts[1])
                );
            }

            // 100x100
            return new Resize(Size.Parse(key));
        }

        public static Resize operator * (Resize left, double scale)
        {
            var newSize = left.Size * scale;

            return new Resize(newSize, left.Anchor);
        }
    }
}

/* 


100x100;fit=contain;anchor=center/

500x0
0x500

500x500;fit:crop;anchor:center
500x500(fit:crop;anchor:center)
500x500+x:100+y:200 

500x500(fit:crop anchor:center)
 
Image Magic : 
-resize 64x64
-crop 40x30+10+10  (width,height,top,left)

-crop <width>x<height>{+-}<x>{+-}<y>{%}

*/
