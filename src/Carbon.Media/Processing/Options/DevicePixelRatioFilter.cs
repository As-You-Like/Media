using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class DevicePixelRatioFilter : IProcessor, ICanonicalizable
    {
        public DevicePixelRatioFilter(float ratio)
        {
            Ratio = ratio;
        }

        public float Ratio { get; set; }

        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);

            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("dpr(");

            sb.Append(Ratio);

            sb.Append(')');
        }

        public override string ToString() => Canonicalize();
    }
}