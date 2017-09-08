using System;

namespace Carbon.Media.Processors
{
    public class BlendFilter : IFilter
    {
        // Blend / Overlay another source...
        
        public BlendMode Mode { get; set; }

        public string Canonicalize() => "blend()";
        
        // blend(clip(source,1,10),mode:burn)
        // Opacity

        // Expression?

        // blend=all_expr='A*(if(gte(T,10),1,T/10))+B*(1-(if(gte(T,10),1,T/10)))'
    }
}
