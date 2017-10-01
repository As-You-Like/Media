using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public class FormatContext
    { 
        public virtual MediaStream[] Streams { get; set; }

        public virtual Chapter[] Chapters { get; set; }

        public virtual BitRate? BitRate { get; set; }
        
        public virtual TimeSpan? MaxAnalyzeDuration { get; set; }
        
        public virtual TimeSpan? Duration { get; set; }

        public virtual Dictionary<string, string> Metadata { get; set; }

        public MediaStream GetStream(MediaType type)
        {
            foreach (var stream in Streams)
            {
                if (stream.Type == type)
                {
                    return stream;
                }
            }

            return null;
        }
    }
}