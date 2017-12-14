using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class DocumentInfo
    {
        // doc
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }
        
        // Codec = 2
        
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
