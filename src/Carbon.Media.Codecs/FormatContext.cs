using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public class FormatContext
    { 
        public MediaStream[] Streams { get; set; }

        public Chapter[] Chapters { get; set; }

        public BitRate? BitRate { get; set; }
        
        public TimeSpan? MaxAnalyzeDuration { get; set; }
        
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

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
