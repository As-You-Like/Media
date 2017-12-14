namespace Carbon.Media.Processors
{
    public class LosslessFilter : ITransform
    {
        public static readonly LosslessFilter Default = new LosslessFilter();  

        public static LosslessFilter Parse(string segment)
        {
            return Default;
        }

        #region ICanonicalizable

        public string Canonicalize() => "lossless";

        public override string ToString() => Canonicalize();

        #endregion
    }
}