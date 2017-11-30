using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class FormatInfo
    {
        // e.g. mp4
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; set; }

        /// <summary>
        /// The duration of the longest stream in the container
        /// </summary>
        [DataMember(Name = "duration", Order = 2)]
        public TimeSpan Duration { get; set; }
        
        // Streams (Audio, Video, Subtitles)
    }
}