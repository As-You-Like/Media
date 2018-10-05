using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ExifMetadata
    {
        // Dictionary<uint, value> items = new Dictionary<uint, value>();

        [DataMember(Name = "orientation", Order = 274, EmitDefaultValue = false)]
        public ExifOrientation Orientation { get; set; }
    }
}