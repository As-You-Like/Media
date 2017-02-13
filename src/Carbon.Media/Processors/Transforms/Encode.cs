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

        public ImageFormat Format { get; }

        public int Quality { get; }
       
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

        // JPEG::encode(quality:100)
        // PNG::encode
        // WebP::encode

        public static Encode Parse(string segment)
        {
            var indexOfSemiSemi = segment.IndexOf("::");

            var format = segment.Substring(0, indexOfSemiSemi).ToEnum<ImageFormat>(true);

            int quality = 0;

            int argStart = segment.IndexOf('(') + 1;

            if (argStart > 0)
            {
                var args = segment
                    .Substring(argStart, segment.Length - argStart - 1)
                    .Split(Seperators.Comma);

                foreach (var arg in args)
                {
                    var split = arg.Split(':');

                    var k = split[0];
                    var v = split[1];

                    switch (k)
                    {
                        case "quality": quality = int.Parse(v); break;
                    }
                }
            }

            return new Encode(format, quality);
        }
    }
}