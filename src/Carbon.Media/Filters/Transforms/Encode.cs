using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class ImageEncode : ITransform
    {
        public ImageEncode(ImageFormat format, int? quality = null)
        {
            Format = format;
            Quality = quality;
        }

        // JPEG, WEBP, PNG, ...

        public ImageFormat Format { get; }

        public int? Quality { get; }
       
        public string Canonicalize()
        {
            var sb = new StringBuilder();

            sb.Append(Format.Canonicalize());
            sb.Append("::encode");

            if (Quality != null && Quality != 0)
            {
                sb.Append("(");
                sb.Append("quality:");
                sb.Append(Quality.Value);
                sb.Append(")");
            }
            
            return sb.ToString();
        }

        public override string ToString() => Canonicalize();

        // JPEG::encode(quality:100)
        // PNG::encode
        // WebP::encode

        #region Helpers

        [IgnoreDataMember]
        public Mime Mime => Format.ToMime();

        #endregion

        public static ImageEncode Parse(string segment)
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
                    var split = arg.Split(Seperators.Colon);

                    var k = split[0];
                    var v = split[1];

                    switch (k)
                    {
                        case "quality": quality = int.Parse(v); break;
                    }
                }
            }

            return new ImageEncode(format, quality);
        }
    }
}