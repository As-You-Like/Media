using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public struct ShutterInfo
    {
        /// <summary>
        /// The time the shutter was open (in seconds)
        /// </summary>
        [DataMember(Name = "speed")]
        public int Speed { get; set; }
    }
}