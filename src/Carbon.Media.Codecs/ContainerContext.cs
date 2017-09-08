using System;

namespace Carbon.Media.Containers
{
    public class ContainerContext
    {

        // public Container Container { get; } // Muxer Or Demuxer
  
        public MediaStream[] Streams { get; set; }

        public Chapter[] Chapters { get; set; }

        public BitRate BitRate { get; set; }

        public int PacketSize { get; set; }
        
        public int MaxDelay { get; set; }

        public int ProbeSize { get; set; }

        public int MaxAnalyzeDuration { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan Duration { get; set; }


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
