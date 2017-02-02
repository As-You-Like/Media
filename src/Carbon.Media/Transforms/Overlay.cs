using System;

namespace Carbon.Media
{
    public sealed class Overlay : ITransform
    {
        public Overlay(string o, BlendMode mode = BlendMode.Normal, Alignment align = Alignment.Left)
        {
            Key = o;
            BlendMode = mode;
            Align = align;
        }

        // Color, Text, Image

        public string Key { get; set; }

        public BlendMode BlendMode { get; }

        public Alignment Align { get; } // Alignment within the box

        public ScaleMode ScaleMode { get; set; } // Scale within the box

        public Size BoxSize { get; set; }

        // overlay(hello, 100x100)
        
        public static Overlay Parse(string key)
        {
            #region Normalization

            if (key.StartsWith("overlay("))
            {
                key = key.Remove(0, 8); // text(

                key = key.Substring(0, key.Length - 1); // )
            }

            #endregion

            var parts = key.Split(Seperators.Comma);

            var name = parts[0];

            var mode = BlendMode.Normal;
            var align = Alignment.Left;

            for (var i = 1; i < parts.Length; i++)
            {
                var part = parts[i];

                var k = part.Split(Seperators.Colon)[0];
                var v = part.Split(Seperators.Colon)[1];

                switch (k)
                {
                    case "mode"  : mode   = (BlendMode)Enum.Parse(typeof(BlendMode), v, true); break;
                    case "align" : align = (Alignment)Enum.Parse(typeof(Alignment), v, true); break;
                }
            }

            return new Overlay(name, mode);
        }
    }


    // box:(0,0,100,100)
}

/*
overlay(red,mode:burn)
*/
