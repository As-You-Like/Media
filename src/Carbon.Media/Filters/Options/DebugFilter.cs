namespace Carbon.Media.Processors
{
    public class DebugFilter : ITransform
    {
        public static readonly DebugFilter Default = new DebugFilter();

        public static DebugFilter Parse(string segment) => Default;

        #region ICanonicalizable

        public string Canonicalize() => "debug";

        public override string ToString() => Canonicalize();

        #endregion
    }
}