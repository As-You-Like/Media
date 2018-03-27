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
        public ExifExposureProgram? Program { get; set; }

        [DataMember(Name = "mode", Order = 3, EmitDefaultValue = false)]
        public ExifExposureMode? Mode { get; set; }
        
        // public Rational Aperture { get; set; }

        // aka shutter speed

        [DataMember(Name = "time", Order = 4, EmitDefaultValue = false)]
        public TimeSpan? Time { get; set; }
        
        // Method (Shutter?)

    }
}