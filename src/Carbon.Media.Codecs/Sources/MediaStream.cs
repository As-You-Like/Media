using System;

using Carbon.Media.Codecs;

namespace Carbon.Media
{
    public abstract class MediaStream
    {
        public MediaStream(int index, Codec codec)
        {
            Index = index;
            Codec = codec;
        }

        public int Index { get; }

        // e.g. H264, AAC ...
        public Codec Codec { get; }

        public BitRate BitRate { get; set; }

        /// <summary>
        /// The unit of time (in seconds) in which frame timestamps are represented
        /// A timebase of 1/75 represents 1/75th of a second
        /// Presentation Time = {pts} x 1/75 = 0.04
        /// </summary>
        public Rational TimeBase { get; set; }

        /// <summary>
        /// The presentation of the first frame in the stream
        /// </summary>
        public TimeSpan StartTime { get; set; }

        /// <summary>
        /// The duration of the stream
        /// </summary>
        public TimeSpan Duration { get; set; }

        /// <summary>
        /// Number of frames delay there will be from the encoder input to the decoder output.
        /// </summary>
        public long FrameDelay { get; set; }
        
        /// <summary>
        /// The number of frames in the stream, if known
        /// </summary>
        public long? FrameCount { get; set; }

        public abstract MediaStreamType Type { get; }
    }
}
