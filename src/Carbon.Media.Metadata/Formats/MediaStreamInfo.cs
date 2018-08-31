using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class MediaStreamInfo
    {
        [DataMember(Name = "index", Order = 1)]
        public int Index { get; set; }

        // Audio, Video, ...
        [DataMember(Name = "type", Order = 2)]
        public MediaStreamType Type { get; set; }

        [DataMember(Name = "codec", Order = 3)]
        public string Codec { get; set; }
        
        // PixelFormat
        // FrameWidth   (width)
        // FrameHeight  (height)
        // AspectRatio  (rational)
        // FrameRate    (rational)
        // SampleFormat
        // SampleRate
    }
}