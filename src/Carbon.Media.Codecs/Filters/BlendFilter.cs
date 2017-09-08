using System;

namespace Carbon.Media.Processors
{
    /// <summary>
    /// The blend filter takes two input streams and outputs one stream, the first input is the "top" layer and second input is "bottom" layer. By default, the output terminates when the longest input terminates.
    /// </summary>
    public class BlendFilter : IFilter
    {

        public BlendMode Mode { get; set; }

        public string Canonicalize() => throw new NotImplementedException();

        // Opacity

        // Expression?

        // blend=all_expr='A*(if(gte(T,10),1,T/10))+B*(1-(if(gte(T,10),1,T/10)))'

    }


}
