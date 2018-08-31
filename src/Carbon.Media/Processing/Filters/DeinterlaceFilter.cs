namespace Carbon.Media.Processing
{
    public class DeinterlaceFilter : IFilter
    {
        public string Canonicalize() => "deinterlace";
    }

    // algorithm: boxweaver
}