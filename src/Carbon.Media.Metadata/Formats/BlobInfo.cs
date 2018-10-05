using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public struct BlobInfo
    {
        [DataMember(Name = "size", Order = 1)]
        public long Size { get; set; }

        [DataMember(Name  = "hash", Order = 2, EmitDefaultValue = false)]
        public byte[] Hash { get; set; }
    }
}