using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    public sealed class DataStreamInfo : MediaStreamInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public override MediaStreamType Type => MediaStreamType.Data;
    }
}
