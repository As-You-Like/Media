using System;
using System.Runtime.Serialization;

using Carbon.Json;

namespace Carbon.Media.Analysis.Internal
{
    public class ProbedFormat
    {
        [DataMember(Name = "filename")]
        public string FileName { get; set; }
        
        [DataMember(Name = "nb_streams")]
        public int StreamCount { get; set; }

        [DataMember(Name = "nb_programs")]
        public int ProgramCount { get; set; }
        
        [DataMember(Name = "format_name")]
        public string FormatName { get; set; }

        [DataMember(Name = "format_long_name")]
        public string FormatLongName { get; set; }

        [DataMember(Name = "start_time")]
        public string StartTime { get; set; }

        [DataMember(Name = "duration")]
        public TimeSpan? Duration { get; set; }

        [DataMember(Name = "size")]
        public long Size { get; set; }

        [DataMember(Name = "bit_rate")]
        public long BitRate { get; set; }

        [DataMember(Name = "probe_score")]
        public float ProbeScore { get; set; }

        [DataMember(Name = "tags")]
        public JsonObject Tags { get; set; }

        
    }
}
