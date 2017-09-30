using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class Chapter
    {
        public Chapter(TimeSpan start, TimeSpan end, Dictionary<string, string> metadata)
        {
            Start    = start;
            End      = end;
            Metadata = metadata;
        }

        [DataMember(Name = "start")]
        public TimeSpan Start { get; }

        [DataMember(Name = "end")]
        public TimeSpan End { get; }

        [DataMember(Name = "metadata", EmitDefaultValue = false)]
        public Dictionary<string, string> Metadata { get; }
    }
}