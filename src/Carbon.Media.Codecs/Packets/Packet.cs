﻿using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    /// <summary>
    /// A packet contains zero or more encoded frames belonging to a single elementary stream (Audio or Video).
    /// Packets are provided as input to decoders and recieved as output from encoders
    /// </summary>
    public unsafe class Packet : IDisposable // TODO: Make ref struct
    {
        private bool isDisposed = false;
        private readonly AVPacket* pointer;

        private Packet(AVPacket* pointer)
        {
            if (pointer == null) throw new ArgumentNullException(nameof(pointer));

            this.pointer = pointer;
        }

        public AVPacket* Pointer => pointer;

        /*
        public Span<byte> GetSpan()
        {
            if (isDisposed) throw new ObjectDisposedException(nameof(Packet));

            if (Pointer->buf == null) return null;

            return new Span<byte>(Pointer->buf, Pointer->size);
        }
        */

        public int StreamIndex
        {
            get => pointer->stream_index;
            set => pointer->stream_index = value;
        }

        public long Dts
        {
            get => pointer->dts;
            set => pointer->dts = value;
        }

        public long Pts
        {
            get => pointer->pts;
            set => pointer->pts = value;
        }

        public long Duration
        {
            get => pointer->duration;
            set => pointer->duration = value;
        }

        public long ConvergenceDuration
        {
            get => pointer->convergence_duration;
        }

        /// <summary>
        /// Byte position in source stream
        /// -1 if unknown
        /// </summary>
        public long Position
        {
            get => pointer->pos;
            set => pointer->pos = value;
        }

        public void UpdateTimebase(Rational sourceTimeBase, Rational targetTimeBase)
        {
            Pts      = new Timestamp(Pts, sourceTimeBase).Transform(targetTimeBase).Value;
            Dts      = new Timestamp(Dts, sourceTimeBase).Transform(targetTimeBase).Value;
            Duration = new Timestamp(Duration, sourceTimeBase).Transform(targetTimeBase).Value;
        }

        public PacketFlags Flags
        {
            get => (PacketFlags)pointer->flags;
            set => pointer->flags = (int)value;
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

        public unsafe void Unref()
        {
            if (isDisposed) throw new ObjectDisposedException(nameof(Packet));

            // frees the packet for reuse

            ffmpeg.av_packet_unref(pointer);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (isDisposed) return;
            
            // Console.WriteLine("Disposing Packet");

            fixed (AVPacket** p = &pointer)
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