using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    public sealed class SubtitleStreamInfo : MediaStreamInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public override MediaStreamType Type => MediaStreamType.Subtitle;
    }
}
