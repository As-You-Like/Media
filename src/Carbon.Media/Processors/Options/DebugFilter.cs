namespace Carbon.Media.Processors
{
    public sealed class DebugFilter : IProcessor
    {
        public static readonly DebugFilter Default = new DebugFilter();

        #region ICanonicalizable

        public string Canonicalize() => "debug";

        public override string ToString() => Canonicalize();

        #endregion
    }
}