using System.Collections.Generic;

namespace Carbon.Media.Metadata
{
    public struct Make
    {
        private static readonly Dictionary<string, Make> map = new Dictionary<string, Make>{
            { "PENTAX CORPORATION", Pentax },
            { "NIKON CORPORATION", Nikon },
        };

        public static Make Get(string name)
        {
            Make value;

            if (map.TryGetValue(name.ToUpper(), out value))
            {
                return value;
            }

            return new Make(name);
        }

        public Make(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public static readonly Make Pentax = new Make("Pentax");
        public static readonly Make Nikon = new Make("Nikon");
    }
}