using System;

namespace Carbon.Media
{
    /// <summary>
    /// A packet contains zero or more encoded frames which belongs to a single elementary stream (Audio or Video).
    /// Packets are provided as input to decoders and recieved as output from encoders
    /// </summary>
    public class Packet : IDisposable
    {
        public Packet(IBuffer data, int streamIndex, long? position = null)
        {
            Data        = data ?? throw new ArgumentNullException(nameof(data));
            StreamIndex = streamIndex;
            Position    = position;
        }

        public IBuffer Data { get; }

        public int StreamIndex { get; }

        public MediaStreamType Type { get; set; }

        // pts
        public TimeSpan PresentationTime { get; }

        public TimeSpan Duration { get; set;  }

        // dts
        public TimeSpan DecompressionTimestamp { get; set; }

        /// <summary>
        /// Byte position in stream
        /// - 1 if unknown
        /// </summary>
        public long? Position { get; }


        // Flags

        public void Dispose()
        {
            Data.Dispose();
        }
    }
    
}