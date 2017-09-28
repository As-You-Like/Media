using System;
using System.Collections.Generic;

namespace Carbon.Media.Containers
{
    public class FormatContext
    { 
        public MediaStream[] Streams { get; set; }

        public Chapter[] Chapters { get; set; }

        public BitRate? BitRate { get; set; }
                
        public int PacketSize { get; set; }
        
        public int MaxDelay { get; set; }

        public int ProbeSize { get; set; }

        public TimeSpan? MaxAnalyzeDuration { get; set; }
        
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public TimeSpan? ReadTimeout { get; set; }

        public Dictionary<string, string> Metadata { get; set; }

        public MediaStream GetStream(MediaStreamType type)
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
