using System;
using System.Collections.Generic;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class Frame : IDisposable
    {
        protected AVFrame* pointer;

        public Frame()
        {
             this.pointer = ffmpeg.av_frame_alloc();
        }

        public AVFrame* Pointer => pointer;

        // SmtpeTimecode
        
        /// <summary>
        /// Decoding time (from packet)
        /// </summary>
        public virtual long Dts
        {
            get => pointer->pkt_dts;
            set => pointer->pkt_dts = value;
        }

        /// <summary>
        /// Presentation time
        /// </summary>
        public virtual long Pts
        {
            get => pointer->pts;
            set => pointer->pts = value;
        }
        
        /// <summary>
        /// The duration the frame is presented (via the packet)
        /// </summary>
        public long Duration
        {
            get => pointer->pkt_duration;
        }
        
        public Dictionary<string, string> Metadata { get; set; }

        public void Dispose()
        {
            fixed (AVFrame** p = &pointer)
            {
                ffmpeg.av_frame_free(p);
            }
        }
    }
}
