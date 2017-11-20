using System;
using System.Collections.Generic;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class FormatContext
    {
        private AVFormatContext* pointer;


        public FormatContext()
        {
            this.pointer = ffmpeg.avformat_alloc_context();
        }


        public virtual MediaStream[] Streams { get; }

        public virtual Chapter[] Chapters { get; }

        public virtual BitRate? BitRate { get; }
        
        public virtual TimeSpan? MaxAnalyzeDuration { get; }
        
        public virtual TimeSpan? Duration { get; }

        public virtual Dictionary<string, string> Metadata { get; }

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