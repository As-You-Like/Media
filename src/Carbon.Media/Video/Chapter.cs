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

        [DataMember(Name = "start", Order = 1)]
        public TimeSpan Start { get; }

        [DataMember(Name = "end", Order = 2)]
        public TimeSpan End { get; }

        // TimeBase?

        [DataMember(Name = "metadata", EmitDefaultValue = false, Order = 3)]
        public Dictionary<string, string> Metadata { get; }
    }
}