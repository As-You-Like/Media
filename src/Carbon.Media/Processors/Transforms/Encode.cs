using System;
using System.Text;

namespace Carbon.Media
{
    public sealed class Encode : IProcessor
    {
        public Encode(ImageFormat encoder, int quality)
        {
            Encoder = encoder;
            Quality = quality;
        }

        // JPEG, WEBP, PNG, ...

        public ImageFormat Encoder { get; set; }

        public int Quality { get; set; }
       
        // pad(0,0,0,0)
        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append("encode(");

            sb.Append(Encoder);
            
            if (Quality != 0)
            {
                sb.Append(",quality:" + Quality);
            }

            sb.Append(")");

            return sb.ToString();
        }

        public override string ToString() =>
            Canonicalize();

        public static Encode Parse(string segment)
        {
            #region Normalization

            int argStart = segment.IndexOf('(') + 1;
            
            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            #endregion
  
            ImageFormat encoder = ImageFormat.Jpeg;
            int quality = 0;

            var parts = segment.Split(Seperators.Comma);
                
            for (var i = 0; i < parts.Length; i++)
            {
                var part = parts[i];
                
                if (part.Contains(":"))
                {
                    part = part.Split(':')[1];
                }

                switch (i)
                {
                    case 0: encoder = part.ToEnum<ImageFormat>(true); break;
                    case 1: quality = int.Parse(part); break;
                }
            }

            return new Encode(encoder, quality);
        }
    }
}