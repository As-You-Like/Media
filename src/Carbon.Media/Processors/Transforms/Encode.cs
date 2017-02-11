using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class Encode : IProcessor
    {
        public Encode(ImageFormat format, int quality)
        {
            Format = format;
            Quality = quality;
        }

        // JPEG, WEBP, PNG, ...

        public ImageFormat Format { get; set; }

        public int Quality { get; set; }
       
        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append(Format.Canonicalize());
            sb.Append("::encode");

            if (Quality != 0)
            {
                sb.Append("(");
                sb.Append("quality:" + Quality);
                sb.Append(")");
            }
            
            return sb.ToString();
        }

        public override string ToString() =>
            Canonicalize();

        public static Encode Parse(string segment)
        {
            #region Normalization

            int argStart = segment.IndexOf('(') + 1;
            
            var args = segment.Substring(argStart, segment.Length - argStart - 1);

            #endregion
  
            var encoder = ImageFormat.Jpeg;
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