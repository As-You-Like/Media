namespace Carbon.Media.Processors
{
    public class Page : ITransform
    {
        public Page(int number)
        {
            Number = number;
        }

        public int Number { get; }

        public static Page Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new Page(int.Parse(segment));
        }

        public string Canonicalize() => $"page({Number})";

        public override string ToString() => Canonicalize();
    }
}