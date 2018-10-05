using System;
using System.Runtime.Serialization;
using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class EncodeParameters : IProcessor, ICanonicalizable
    {
        public EncodeParameters(
            FormatId format,
            int? quality = null, 
            EncodeFlags flags = default)
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
        public EncodeFlags Flags { get; }

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

        [IgnoreDataMember]
        public Mime Mime => Format.ToMime();

        // With (quality)
        public static EncodeParameters Parse(string segment)
        {
            int quality = 0;
            
            var indexOfSemiSemi = segment.IndexOf("::");

            string formatName = segment.Substring(0, indexOfSemiSemi);

            (FormatId format, EncodeFlags flags) = EncodingHelper.ParseFormat(formatName);

            int argStart = segment.IndexOf('(') + 1;

            if (argStart > 0)
            {
                var args = ArgumentList.Parse(segment.Substring(argStart, segment.Length - argStart - 1));

                foreach (var (key, value) in args)
                {
                    switch (key)
                    {   
                        case "quality"     : quality = int.Parse(value);       break;
                        case "progressive" : flags |= EncodeFlags.Progressive; break;
                        case "lossless"    : flags |= EncodeFlags.Lossless;    break;

                        default            : throw new Exception("Invalid encode argument:" + key);
                    }
                }
            }

            return new EncodeParameters(format, quality, flags);
        }
    }
}