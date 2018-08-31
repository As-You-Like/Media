namespace Carbon.Media.Processing
{
    public class FadeFilter : IFilter
    {
        // in || out
        public string Direction { get; set; }

        // Color?

        // frame | time
        public string Start { get; set; }

        // frame | time
        public string End { get; set; }

        // Curve?

        public string Canonicalize() => $"fade({Direction},{Start}-{End})";
    }

    // fade(in,0s,30s)

    // fade=in:0:30
}