using System.Runtime.Serialization;

namespace Carbon.Media
{
    public sealed class DataStreamInfo : MediaStreamInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public override MediaStreamType Type => MediaStreamType.Data;
    }
}
