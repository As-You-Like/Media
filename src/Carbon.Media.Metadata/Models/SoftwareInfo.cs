using System.Linq;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    [DataContract]
    public class SoftwareInfo
    {
        public SoftwareInfo() { }

        public SoftwareInfo(string name, string version, string platform)
        {
            Name = name;
            Version = version;
            Platform = platform;
        }

        // developer? (Adobe)

        // e.g. Photoshop
        [DataMember(Name = "name", Order = 2, EmitDefaultValue = false)]
        public string Name { get; set; }

        // e.g. CS4
        [DataMember(Name = "version", Order = 3, EmitDefaultValue = false)]
        public string Version { get; set; }

        // Macintosh / Windows
        [DataMember(Name = "platform", Order = 4, EmitDefaultValue = false)]
        public string Platform { get; set; }
        
        public static bool TryParse(string text, out SoftwareInfo software)
        {
            string name = text;
            string platform = null;
            string version = null;

            var parts = text.Split(' ');
            
            if (text.StartsWith("Adobe Photoshop") && parts.Length > 2)
            {
                name    = "Adobe Photoshop";
                version = parts[2];
            }

            var lastPart = parts[parts.Length - 1];

            switch (lastPart)
            {
                case "Macintosh":
                    platform = "Mac";
                    break;
                case "Windows":
                    platform = "Windows";
                    break;
            }

            if (platform != null)
            {
                name = name.Replace(" " + lastPart, "");
            }

            software = new SoftwareInfo(name, version, platform);

            return true;
        }
    }

    // Adobe Photoshop CS3 Windows
    // Adobe Photoshop CS4 Macintosh

}