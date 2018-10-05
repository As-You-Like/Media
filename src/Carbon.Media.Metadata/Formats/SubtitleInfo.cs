using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SubtitleInfo
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }

        // Codec?
    }
}