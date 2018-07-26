namespace Carbon.Media.Processors
{
    public sealed class LosslessFilter : IProcessor
    {
        public static readonly LosslessFilter Default = new LosslessFilter();

        #region ICanonicalizable

        public string Canonicalize() => "lossless";

        public override string ToString() => Canonicalize();

        #endregion
    }
}