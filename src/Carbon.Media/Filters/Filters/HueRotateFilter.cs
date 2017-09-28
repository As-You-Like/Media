namespace Carbon.Media.Processors
{
    public class HueRotateFilter : IFilter
    {
        public HueRotateFilter(int degrees)
        {
            Degrees = degrees;
        }

        public int Degrees { get; }

        // hue-rotate(90deg)
       
        public string Canonicalize() => $"hueRotate({Degrees}deg)";

        public override string ToString() => $"hue-rotate({Degrees}deg)";

        public static HueRotateFilter Parse(string segment)
        {
            int argStart = segment.IndexOf('(') + 1;

            segment = segment.Substring(argStart, segment.Length - argStart - 1);

            return new HueRotateFilter(int.Parse(segment.Replace("deg", "")));
        }
    }
}

// hue-rotate(328deg)