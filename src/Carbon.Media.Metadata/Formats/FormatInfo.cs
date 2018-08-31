using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class FormatInfo
    {
        // video/mp4
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        // e.g. mp4
        [DataMember(Name = "name", Order = 4)]
        public string Name { get; set; }

        [DataMember(Name = "size", Order = 5)]
        public long Size { get; set; }

        /// <summary>
        /// The duration of the longest stream in the container
        /// </summary>
        [DataMember(Name = "duration", Order = 12)]
        public TimeSpan Duration { get; set; }
        
        // Streams (Audio, Video, Subtitles)
    }
}