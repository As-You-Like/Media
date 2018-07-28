﻿using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    /// <summary>
    /// A packet contains zero or more encoded frames belonging to a single elementary stream (Audio or Video).
    /// Packets are provided as input to decoders and recieved as output from encoders
    /// </summary>
    public unsafe class Packet : IDisposable
    {
        private bool isDisposed = false;

        private Packet(AVPacket* pointer)
        {
            if (pointer == null) throw new ArgumentNullException(nameof(pointer));

            Pointer = pointer;
        }

        public readonly AVPacket* Pointer;

        public Buffer GetMemory()
        {
            if (isDisposed) throw new ObjectDisposedException(nameof(Packet));

            if (Pointer->buf == null) return null;

            return new Buffer((IntPtr)Pointer->data, Pointer->size);
        }

        public int StreamIndex
        {
            get => Pointer->stream_index;
            set => Pointer->stream_index = value;
        }

        public long Dts
        {
            get => Pointer->dts;
            set => Pointer->dts = value;
        }

        public long Pts
        {
            get => Pointer->pts;
            set => Pointer->pts = value;
        }

        public long Duration
        {
            get => Pointer->duration;
            set => Pointer->duration = value;
        }

        public long ConvergenceDuration
        {
            get => Pointer->convergence_duration;
        }

        /// <summary>
        /// Byte position in source stream
        /// -1 if unknown
        /// </summary>
        public long Position
        {
            get => Pointer->pos;
            set => Pointer->pos = value;
        }

        public void UpdateTimebase(Rational sourceTimeBase, Rational targetTimeBase)
        {
            Pts      = new Timestamp(Pts, sourceTimeBase).Transform(targetTimeBase).Value;
            Dts      = new Timestamp(Dts, sourceTimeBase).Transform(targetTimeBase).Value;
            Duration = new Timestamp(Duration, sourceTimeBase).Transform(targetTimeBase).Value;
        }

        // frees the packet for reuse
        public void Unref()
        {   
            ffmpeg.av_packet_unref(Pointer);   
        }

        public PacketFlags Flags
        {
            get => (PacketFlags)Pointer->flags;
            set => Pointer->flags = (int)value;
        }
      
        #region Helpers

        public bool IsKeyframe => (Flags & PacketFlags.Keyframe) != 0; 

        public bool IsCorrupt => (Flags & PacketFlags.Corrupt) != 0;

        public bool IsTrusted => (Flags & PacketFlags.Trusted) != 0;

        #endregion

        public static Packet Allocate()
        {
            AVPacket* pointer = ffmpeg.av_packet_alloc();

            ffmpeg.av_init_packet(pointer);

            pointer->data = null;
            pointer->size = 0;

            return new Packet(pointer);
        }
    
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (isDisposed) return;
            
            Console.WriteLine("Disposing Packet");
                
            fixed (AVPacket** p = &Pointer)
            {
                // unreferences & frees the packet
                ffmpeg.av_packet_free(p);
            }

            isDisposed = true;
        }

        ~Packet()
        {
            Dispose(false);
        }
    }
}