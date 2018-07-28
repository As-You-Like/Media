using System;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe class Frame : IDisposable
    {
        protected AVFrame* pointer;

        public Frame()
        {
            this.pointer = ffmpeg.av_frame_alloc();
            
            if (pointer == null)
            {
                throw new Exception("Did not allocate frame");
            }
        }

        public AVFrame* Pointer => pointer;

        public Buffer Memory { get; protected set; }

        // SmtpeTimecode

        /// <summary>
        /// Decoding time (from packet)
        /// </summary>
        public long Dts
        {
            get => pointer->pkt_dts;
            set => pointer->pkt_dts = value;
        }

        /// <summary>
        /// Presentation time
        /// </summary>
        public long Pts
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
            set => pointer->pkt_duration = value;
        }
        
        // public Dictionary<string, string> Metadata { get; set; }

        // Prepares the frame for reuse
        public void Unref()
        {
            ffmpeg.av_frame_unref(pointer);
        }

        internal virtual void OnDisposing()
        {
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (pointer == null) return;
            
            fixed (AVFrame** p = &pointer)
            {
                ffmpeg.av_frame_free(p);
            }

            Memory?.Dispose();

            OnDisposing();

            pointer = null;
        }

        ~Frame()
        {
            Dispose(false);
        }
    }
}