using System;

namespace Carbon.Media
{
    /// <summary>
    /// A packet contains zero or more encoded frames belonging to a single elementary stream (Audio or Video).
    /// Packets are provided as input to decoders and recieved as output from encoders
    /// </summary>
    public class Packet : IDisposable
    {
        public IBuffer Data { get; set; }

        public int StreamIndex { get; set; }

        public MediaType Type { get; set; }

        /// <summary>
        /// Decompression timestamp
        /// </summary>
        public virtual long Dts { get; set; }

        /// <summary>
        /// Presentation timestamp
        /// </summary>
        public virtual long Pts { get; set; }

        public virtual long Duration { get; set;  }

        /// <summary>
        /// Byte position in source stream
        /// -1 if unknown
        /// </summary>
        public virtual long Position { get; set; }

        #region Flags

        public virtual PacketFlags Flags { get; set; }
        
        public bool IsKeyframe => Flags.HasFlag(PacketFlags.Keyframe);

        #endregion

        public virtual void Dispose()
        {
            Data?.Dispose();
        }
    }
}