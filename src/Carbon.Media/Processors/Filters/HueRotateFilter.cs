namespace Carbon.Media
{
    public class HueRotateFilter : IProcessor
    {
        public HueRotateFilter(int degrees)
        {
            Degrees = degrees;
        }

        public int Degrees { get; }

        // hue-rotate(90deg)
       
        public string Canonicalize() => $"hue-rotate({Degrees}deg)";

        public override string ToString() => Canonicalize();

        public static HueRotateFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new HueRotateFilter(int.Parse(segment.Replace("deg", "")));
        }
    }
}
