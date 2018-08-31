using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class DocumentInfo
    {
        [DataMember(Name = "type", Order = 1, EmitDefaultValue = false)]
        public string Type { get; set; }

        [DataMember(Name = "format", Order = 2)]
        public string Format { get; set; }

        // Codec = 3

        [DataMember(Name = "size", Order = 4, EmitDefaultValue = false)]
        public long Size { get; set; }

        [DataMember(Name = "pages", Order = 10)]
        public PageInfo[] Pages { get; set; }
        
        [DataMember(Name = "authors")]
        public ActorInfo[] Authors { get; set; }

        [DataMember(Name = "creator")]
        public ActorInfo Creator { get; set; }
        
        [DataMember(Name = "created")]
        public DateTime? Created { get; set; }

        [DataMember(Name = "modified")]
        public DateTime? Modified { get; set; }
    }
}

/*
 format : "pdf",										
 pages  : [ 
    width       : 800,
    height      : 600,
    orientation : "Rotate90
 ] 
*/
