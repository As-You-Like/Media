using System.Runtime.Serialization;

namespace Carbon.Media
{
    [DataContract]
    public class EncodingProfile
    {
        public EncodingProfile(FormatId format, AudioProfile audio, VideoProfile video)
        {
            Format = format;
            Audio  = audio;
            Video  = video;
        }

        [DataMember(Name = "format", Order = 1)]
        public FormatId Format { get; }
        
        [DataMember(Name = "audio", Order = 2)]
        public AudioProfile Audio { get; }

        [DataMember(Name = "video", Order = 3)]
        public VideoProfile Video { get; }

        // Subtitles?
    }
}