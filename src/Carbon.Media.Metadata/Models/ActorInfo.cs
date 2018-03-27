using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class ActorInfo
    {
        public ActorInfo() { }

        public ActorInfo(string name, string email)
        {
            Name = name;
            Email = email;
        }
    
        [DataMember(Name = "id", Order = 1, EmitDefaultValue = false)]
        public long Id { get; set; }

        [DataMember(Name = "name", Order = 2, EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "email", Order = 3, EmitDefaultValue = false)]
        public string Email { get; set; }
    }
}