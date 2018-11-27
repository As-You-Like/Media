using System.Text;

namespace Carbon.Media.Processing
{
    public sealed class LosslessFlag : IProcessor, ICanonicalizable
    {
        public static readonly LosslessFlag Default = new LosslessFlag();

        public static LosslessFlag Parse(string segment) => Default;

        #region ICanonicalizable

        public string Canonicalize() => "lossless";

        public override string ToString() => Canonicalize();

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("lossless");
        }

        #endregion
    }
}