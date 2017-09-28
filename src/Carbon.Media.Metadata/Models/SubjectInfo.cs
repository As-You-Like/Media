using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SubjectInfo
    {
        public string Type { get; set; }

        // in meters
        public double Distance { get; set; }
    }
}