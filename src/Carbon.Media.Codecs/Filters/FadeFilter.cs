namespace Carbon.Media.Processors
{
    public class FadeFilter : IFilter
    {
        // in || out
        public string Type { get; set; }

        // frame | time
        public string Start { get; set; }

        // frame | time
        public string End { get; set; }

        // Curve?

        public string Canonicalize() => $"fade({Type},{Start}-{End})";
    }

    // fade=in:0:30
}