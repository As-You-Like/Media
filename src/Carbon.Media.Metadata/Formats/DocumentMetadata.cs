using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class DocumentMetadata : IFormatMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }
        
        [DataMember(Name = "pages", Order = 10)]
        public PageMetadata[] Pages { get; set; }
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
