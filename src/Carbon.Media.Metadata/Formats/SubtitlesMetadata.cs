using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SubtitlesMetadata : IFormatMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }
    }
}