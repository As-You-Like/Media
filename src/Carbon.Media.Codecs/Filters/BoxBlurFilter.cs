using System;

namespace Carbon.Media.Processors
{
    public class BoxBlurFilter : IFilter
    {
        public float LumaRadius { get; set; }

        public float LumaPower { get; set; }

        public float ChromaRadius { get; set; }

        public float ChromaPower { get; set; }

        public float AlphaRadius { get; set; }

        public float AlphaPower { get; set; }

        public string Canonicalize() => throw new NotImplementedException();
        // boxblur=luma_radius=2:luma_power=1
        // boxblur=luma_radius=min(h\,w)/10:luma_power=1:chroma_radius=min(cw\,ch)/10:chroma_power=1
    }


}
