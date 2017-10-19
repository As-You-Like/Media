using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class ImageEncode : ITransform
    {
        public ImageEncode(
            ImageFormat format,
            int? quality = null, 
            EncodeFlags flags = default)
        {
            Format  = format;
            Quality = quality;
            Flags   = flags;
        }

        // JPEG, WEBP, PNG, ...

        public ImageFormat Format { get; }

        public int? Quality { get; }

        // jpeg only
        public EncodeFlags Flags { get; }

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
        // JPEG::encode(quality:88,progressive:true)
        // PNG::encode
        // WebP::encode

        #region Helpers

        [IgnoreDataMember]
        public Mime Mime => Format.ToMime();

        #endregion

        // With (quality)
        public static ImageEncode Parse(string segment)
        {
            int quality = 0;
            var flags = EncodeFlags.None;

            var indexOfSemiSemi = segment.IndexOf("::");

            string formatName = segment.Substring(0, indexOfSemiSemi);

            ImageFormat format;

            switch (formatName)
            {
                case "pjpg":
                    format = ImageFormat.Jpeg;
                    flags |= EncodeFlags.Progressive;
                    break;

                case "png8":
                    format = ImageFormat.Png;
                    flags |= EncodeFlags._8bit;
                    break;

                case "png32":
                    format = ImageFormat.Png;
                    flags |= EncodeFlags._32bit;
                    break;

                case "webpll":
                    format = ImageFormat.WebP;
                    flags |= EncodeFlags.Lossless;
                    break;

                default:
                    format = ImageFormatHelper.Parse(formatName);
                    break;

            }

            

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
                        case "quality"     : quality = int.Parse(v); break;
                        case "progressive" : flags |= EncodeFlags.Progressive; break;
                    }
                }
            }

            return new ImageEncode(format, quality, flags);
        }
    }

    public enum EncodeFlags
    {
        None = 0,
        Progressive = 1 << 1,
        Lossless = 1 << 2,
        _8bit = 1 << 3,
        _32bit = 1 << 4
    }
}