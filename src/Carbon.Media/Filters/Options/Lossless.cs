namespace Carbon.Media.Processors
{
    public class Lossless : ITransform
    {
        public static readonly Lossless Default = new Lossless();  

        public static Lossless Parse(string segment)
        {
            return Default;
        }

        public string Canonicalize() => $"lossless";

        public override string ToString() => Canonicalize();
    }
}