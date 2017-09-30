using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ActorInfo
    {
        // Id = 1

        [DataMember(Name = "name", Order = 2, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "email", Order = 3, EmitDefaultValue = false)]
        public string Email { get; set; }
    }
}