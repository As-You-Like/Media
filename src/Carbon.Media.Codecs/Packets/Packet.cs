using System;
using System.Runtime.InteropServices;
using FFmpeg.AutoGen;

namespace Carbon.Media
{
    /// <summary>
    /// A packet contains zero or more encoded frames belonging to a single elementary stream (Audio or Video).
    /// Packets are provided as input to decoders and recieved as output from encoders
    /// </summary>
    public unsafe class Packet : IDisposable
    {
        private AVPacket native;
        private AVPacket* pointer;
        private readonly GCHandle handle;

        public Packet()
        {
            this.native = new AVPacket();

            var native = new AVPacket();
            var handle = GCHandle.Alloc(native, GCHandleType.Pinned);

            this.pointer = (AVPacket*)handle.AddrOfPinnedObject().ToPointer();

            ffmpeg.av_init_packet(pointer);

            this.native.data = null;
            this.native.size = 0;
        }

        public AVPacket* Pointer => pointer;

        public Buffer Data { get; set; }

        public long Size => Data.Length;

        public int StreamIndex => native.stream_index;

        public MediaType Type { get; set; }

        /// <summary>
        /// Decompression timestamp
        /// </summary>
        public long Dts
        {
            get => native.dts;
            set => native.dts = value;
        }

        /// <summary>
        /// Presentation timestamp
        /// </summary>
        public long Pts
        {
            get => native.pts;
            set => native.pts = value;
        }

        public long Duration
        {
            get => native.duration;
            set => native.duration = value;
        }

        /// <summary>
        /// Byte position in source stream
        /// -1 if unknown
        /// </summary>
        public long Position
        {
            get => native.pos;
            set => native.pos = value;
        }

        // Convergance
        public long ConvergenceDuration
        {
            get => native.convergence_duration;
            set => native.convergence_duration = value;
        }



        /*
        public PacketFlags Flags
        {
        }
        */

        // Additional data?

        #region Helpers

        // public bool IsKeyframe => Flags.HasFlag(PacketFlags.Keyframe);

        // public bool IsCorrupt => Flags.HasFlag(PacketFlags.Corrupt);

        #endregion

     
        ~Packet()
        {
            Dispose(false);
        }
        
        protected void Dispose(bool disposing)
        {
            Data?.Dispose();

            handle.Free();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}