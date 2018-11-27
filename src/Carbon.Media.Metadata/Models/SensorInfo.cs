using System.Runtime.Serialization;
using Carbon.Media.Metadata.Exif;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SensingInfo
    {
        [DataMember(Name = "method", Order = 1)]
        public ExifSensingMethod Method { get; set; }
    }
}