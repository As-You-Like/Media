using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    /// <summary>
    /// A packet contains zero or more encoded frames belonging to a single elementary stream (Audio or Video).
    /// Packets are provided as input to decoders and recieved as output from encoders
    /// </summary>
    public unsafe class Packet : IDisposable
    {
        private AVPacket* pointer;
        private Rational timebase = Timebases.Ffmpeg;

        private Packet(AVPacket* pointer)
        {
            if (pointer == null)
                throw new ArgumentNullException(nameof(pointer));

            this.pointer = pointer;
        }

        public AVPacket* Pointer => pointer;

        public Buffer Memory => pointer->buf != null
            ? new Buffer((IntPtr)pointer->data, pointer->size)
            : null;

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

        /// <summary>
        /// Decompression timestamp
        /// </summary>
        public Timestamp DecodeTimestamp => new Timestamp(Dts, timebase);

        /// <summary>
        /// Presentation timestamp
        /// </summary>
        public Timestamp PresentTimestamp => new Timestamp(Pts, timebase);

        public Timestamp Duration
        {
            get => new Timestamp(pointer->duration, timebase);
            set => pointer->duration = value.Value;
        }

        public Timestamp ConvergenceDuration
        {
            get => new Timestamp(pointer->convergence_duration, timebase);
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

        public Rational TimeBase
        {
            get => timebase;
            set => timebase = value;
        }

        public void UpdateTimebase(Rational sourceTimeBase, Rational targetTimeBase)
        {
            timebase = targetTimeBase;

            Pts               = new Timestamp(Pts, sourceTimeBase).Transform(targetTimeBase).Value;
            Dts               = new Timestamp(Dts, sourceTimeBase).Transform(targetTimeBase).Value;
            pointer->duration = new Timestamp(pointer->duration, sourceTimeBase).Transform(targetTimeBase).Value;
        }

        // frees the packet for reuse
        public void Clear()
        {
            if (pointer->buf != null)
            {
                ffmpeg.av_packet_unref(pointer);
            }
        }

        public PacketFlags Flags
        {
            get => (PacketFlags) pointer->flags;
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
    
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        ~Packet()
        {
            Dispose(false);
        }

        private void Dispose(bool disposing)
        {
            if (pointer != null)
            {
                Console.WriteLine("disposing packet");

                Clear();

                fixed (AVPacket** p = &pointer)
                {
                    ffmpeg.av_packet_free(p);
                }

                pointer = null;
            }
        }
    }
}