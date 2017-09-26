using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ExposureInfo
    {
        [DataMember(Name = "index", EmitDefaultValue = false)]
        public int? Index { get; set; }

        [DataMember(Name = "program", EmitDefaultValue = false)]
        public ExposureProgram? Program { get; set; }

        [DataMember(Name = "mode", EmitDefaultValue = false)]
        public ExposureMode Mode { get; set; }

        [DataMember(Name = "time", EmitDefaultValue = false)]
        public TimeSpan? Time { get; set; }
    }
}