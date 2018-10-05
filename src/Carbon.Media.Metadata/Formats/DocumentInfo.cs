using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class DocumentInfo
    {
        public DocumentInfo() { }

        public DocumentInfo(string format, PageInfo[] pages)
        {
            Format = format ?? throw new ArgumentNullException(nameof(format));
            Pages = pages;
        }

        [DataMember(Name = "format", Order = 1)]
        public string Format { get; set; }
        
        // Codec = 2

        [DataMember(Name = "blob", Order = 3, EmitDefaultValue = false)]
        public BlobInfo Blob { get; set; }

        [DataMember(Name = "pages", Order = 10)]
        public PageInfo[] Pages { get; set; }
        
        [DataMember(Name = "authors", EmitDefaultValue = false)]
        public ActorInfo[] Authors { get; set; }

        [DataMember(Name = "creator", EmitDefaultValue = false)]
        public ActorInfo Creator { get; set; }
        
        [DataMember(Name = "created", EmitDefaultValue = false)]
        public DateTime? Created { get; set; }

        [DataMember(Name = "modified", EmitDefaultValue = false)]
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
