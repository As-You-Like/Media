using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ContainerMetadata : IFormatMetadata
    {
        // e.g. mp4
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        /// <summary>
        /// The duration of the longest stream in the container
        /// </summary>
        [DataMember(Name = "duration", Order = 2)]
        public TimeSpan Duration { get; set; }
        
        // Streams (Audio, Video, Subtitles)
    }
    
    [DataContract]
    public class ContainerStreamMetadata
    {
        [DataMember(Name = "index", Order = 1)]
        public int Index { get; set; }

        [DataMember(Name = "type", Order = 2)]
        public MediaType Type { get; set; }

        [DataMember(Name = "codec", Order = 3)]
        public string Codec { get; set; }
        
        // PixelFormat
        // FrameWidth   (width)
        // FrameHeight  (height)
        // AspectRatio  (rational)
        // FrameRate    (rational)
        // SampleFormat
        // SampleRate
    }
}