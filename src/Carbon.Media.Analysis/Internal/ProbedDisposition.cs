using System.Runtime.Serialization;

namespace Carbon.Media.Analysis.Internal
{
    public class ProbedDisposition
    {
        [DataMember(Name = "default")]
        public string Default { get; set; }

        [DataMember(Name = "dub")]
        public string Dub { get; set; }
  
        [DataMember(Name = "original")]
        public string Original { get; set; }

        [DataMember(Name = "comment")]
        public string Comment { get; set; }

        [DataMember(Name = "lyrics")]
        public string Lyrics { get; set; }

        [DataMember(Name = "karaoke")]
        public string Karaoke { get; set; }

        [DataMember(Name = "forced")]
        public string Forced { get; set; }

        [DataMember(Name = "hearing_impaired")]
        public string HearingImpaired { get; set; }

        [DataMember(Name = "visual_impaired")]
        public string VisualImpaired { get; set; }

        [DataMember(Name = "clean_effects")]
        public string CleanEffects { get; set; }

        [DataMember(Name = "attached_pic")]
        public string AttachedPic { get; set; }

        [DataMember(Name = "timed_thumbnails")]
        public string TimedThumbnails { get; set; }
    }
}
