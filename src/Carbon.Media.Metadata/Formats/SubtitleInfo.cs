using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SubtitleInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public string Type { get; set; }

        // Codec?
    }
}