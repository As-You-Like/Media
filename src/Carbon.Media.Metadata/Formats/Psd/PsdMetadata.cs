using System.Runtime.Serialization;

namespace Carbon.Media.Metadata.Psd
{
    public class PsdMetadata : ImageInfo
    {
        [DataMember(Name = "colorMode")]
        public PsdColorMode ColorMode { get; set; }
    }
}