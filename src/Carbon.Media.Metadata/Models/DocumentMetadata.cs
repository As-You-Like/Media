using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class DocumentMetadata
    {
        [DataMember(Name = "format", Order = 1)]
        public DocumentFormat Format { get; set; }

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
