using System;
using System.Collections.Generic;

namespace Carbon.Media.Containers
{
    public class FormatContext
    {
        // public Container Container { get; } // Muxer Or Demuxer
  
        public MediaSource Source { get; set; }

        public MediaStream[] Streams { get; set; }

        public Chapter[] Chapters { get; set; }

        public BitRate? BitRate { get; set; }
        
        // Seek
        
        public int PacketSize { get; set; }
        
        public int MaxDelay { get; set; }

        public int ProbeSize { get; set; }

        public TimeSpan? MaxAnalyzeDuration { get; set; }
        
        public TimeSpan? StartTime { get; set; }

        public TimeSpan? Duration { get; set; }

        public TimeSpan? ReadTimeout { get; set; }

        // Disable Audio | Video | Subtitle

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

    // AKA AVFormatContext
}
