using System.Runtime.Serialization;

namespace Carbon.Media
{
    public sealed class AudioStreamInfo : MediaStreamInfo
    {
        [DataMember(Name = "type", Order = 1)]
        public override MediaStreamType Type => MediaStreamType.Audio;

        // e.g. F32p
        [DataMember(Name = "sampleFormat", Order = 10)]
        public SampleFormat SampleFormat { get; set; }

        [DataMember(Name = "sampleRate", Order = 11)]
        public int SampleRate { get; set; }

        [DataMember(Name = "channelCount", Order = 12, EmitDefaultValue = false)]
        public int? ChannelCount { get; set; }

        [DataMember(Name = "channelLayout", Order = 13)]
        public string ChannelLayout { get; set; }
    }
}