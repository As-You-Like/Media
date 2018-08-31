namespace Carbon.Media.Processing
{
    public class LosslessFilter : IProcessor
    {
        public static readonly LosslessFilter Default = new LosslessFilter();

        public static LosslessFilter Parse(string segment) => Default;

        #region ICanonicalizable

        public string Canonicalize() => "lossless";

        public override string ToString() => Canonicalize();

        #endregion
    }
}