using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ExposureInfo
    {
        [DataMember(Name = "index", Order = 1, EmitDefaultValue = false)]
        public int? Index { get; set; }

        [DataMember(Name = "program", Order = 2, EmitDefaultValue = false)]
        public ExposureProgram? Program { get; set; }

        [DataMember(Name = "mode", Order = 3, EmitDefaultValue = false)]
        public ExposureMode? Mode { get; set; }

        [DataMember(Name = "time", Order = 4, EmitDefaultValue = false)]
        public TimeSpan? Time { get; set; }

        //         // Method (Shutter?)

    }
}