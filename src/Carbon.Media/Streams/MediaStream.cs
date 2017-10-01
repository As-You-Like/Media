using System;

namespace Carbon.Media
{
    public abstract class MediaStream
    {
        public MediaStream(int index, ICodec codec)
        {
            if (index < 0)
                throw new ArgumentException("Must be >= 0", nameof(index));

            Index = index;
            Codec = codec ?? throw new ArgumentNullException(nameof(codec));
        }

        public int Index { get; }

        public abstract MediaType Type { get; }

        // e.g. H264, AAC ...
        public ICodec Codec { get; }
        
        /// <summary>
        /// The average number of bits per second
        /// </summary>
        public BitRate? BitRate { get; set; }

        /// <summary>
        /// The unit of time (in seconds) in which frame timestamps are represented
        /// </summary>
        public Rational TimeBase { get; set; }

        /// <summary>
        /// The presentation of the first frame in the stream
        /// </summary>
        public TimeSpan? StartTime { get; set; }

        /// <summary>
        /// The duration of the stream
        /// </summary>
        public TimeSpan? Duration { get; set; }

        /// <summary>
        /// Number of frames delay there will be from the encoder input to the decoder output
        /// </summary>
        public long? FrameDelay { get; set; }
        
        /// <summary>
        /// The total number of frames
        /// </summary>
        public long? FrameCount { get; set; }

        /// <summary>
        /// The size, in bytes, of each frame
        /// </summary>
        // public int FrameSize { get; set; }
    }
}
