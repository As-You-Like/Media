using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    public class Resize : ITransform
    {
        public Resize(Size size)
            : this(size.Width, size.Height)
        { }

        public Resize(int width, int height)
        {
            #region Preconditions

            if (width < 0 || width > 5000)
                throw new ArgumentOutOfRangeException(nameof(width), width, message: "Must be between 0 and 5,000");

            if (height < 0 || height > 15000)
                throw new ArgumentOutOfRangeException(nameof(height), height, message: "Must be between 0 and 15,000");

            #endregion

            Width = width;
            Height = height;
        }

        public int Height { get; }

        public int Width { get; }

        [IgnoreDataMember]
        public Size Size => new Size(Width, Height);

        public override string ToString() => Width + "x" + Height;

        public static Resize Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("resize:"))
            {
                key = key.Remove(0, 7);
            }

            #endregion

            return new Resize(Size.Parse(key));
        }
    }
}

/* 

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
