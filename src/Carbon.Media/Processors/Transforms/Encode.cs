using System;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media.Processors
{
    public sealed class Encode : IProcessor, ICanonicalizable
    {
        public Encode(
            FormatId format,
            int? quality = null, 
            EncodingFlags flags = default)
        {
            Format  = format;
            Quality = quality;
            Flags   = flags;
        }

        // JPEG, WEBP, PNG, MP4, WEBP, MP4 ...

        public FormatId Format { get; }

        // TODO: IEncodeOptions
        public int? Quality { get; }

        // jpeg only
        public EncodingFlags Flags { get; }

        #region ICanonicalizable

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append(Format.Canonicalize());
            sb.Append("::encode");

            if (Quality != null && Quality != 0)
            {
                sb.Append('(');
                sb.Append("quality:");
                sb.Append(Quality.Value);
                sb.Append(')');
            }
        }

        public override string ToString() => Canonicalize();

        #endregion

        // JPEG::encode(quality:100)
        // JPEG::encode(quality:88,progressive:true)
        // PNG::encode
        // WebP::encode

        #region Helpers

        [IgnoreDataMember]
        public Mime Mime => Format.ToMime();

        #endregion

        // With (quality)
        public static Encode Parse(string segment)
        {
            int quality = 0;
            
            var indexOfSemiSemi = segment.IndexOf("::");

            string formatName = segment.Substring(0, indexOfSemiSemi);

            (FormatId format, EncodingFlags flags) = EncodingHelper.ParseFormat(formatName);

            int argStart = segment.IndexOf('(') + 1;

            if (argStart > 0)
            {
                var args = ArgumentList.Parse(segment.Substring(argStart, segment.Length - argStart - 1));

                foreach (var arg in args)
                {                    
                    switch (arg.Name)
                    {
                        case "quality"     : quality = int.Parse(arg.Value);                     break;
                        case "progressive" : flags |= EncodingFlags.Progressive;                 break;
                        case "lossless"    : flags |= EncodingFlags.Lossless;                    break;

                        default            : throw new Exception("unexpected encode argument:" + arg.Name);
                    }
                }
            }

            return new Encode(format, quality, flags);
        }
    }

    public enum EncodingFlags
    {
        None = 0,
        Progressive = 1 << 1,
        Lossless    = 1 << 2,
        _8bit       = 1 << 3,
        _32bit      = 1 << 4
    }
}