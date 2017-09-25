namespace Carbon.Media.Processors
{
    public class DeinterlaceFilter : IFilter
    {
        public string Canonicalize() => "deinterlace";
    }

    // algorithm: boxweaver
}