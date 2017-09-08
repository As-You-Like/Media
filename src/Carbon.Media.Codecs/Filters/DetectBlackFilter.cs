using System;

namespace Carbon.Media.Processors
{
    public class DetectBlackFilter : IFilter
    {
        public TimeSpan MinimumDuration { get; set; }
        
        // public float BlackRatio { get; set; }

        public string Canonicalize() => throw new NotImplementedException();
    }
}
