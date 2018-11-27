using System;
using System.Collections.Generic;

namespace Carbon.Media.Metadata
{
    public readonly struct Make
    {
        private static readonly Dictionary<string, Make> map = new Dictionary<string, Make> {
            { "PENTAX CORPORATION", Pentax },
            { "NIKON CORPORATION", Nikon },
            { "OLYMPUS IMAGING CORP.", Olympus },
            { "SONY", Sony },
            { "SANYO ELECTRIC CO., LTD.", Sanyo },
            { "CANON", Canon },
        };
        
        // Canonicalize's the value

        public static Make Parse(string name)
        {
            name = name.Trim().ToUpper();

            return map.TryGetValue(name.ToUpper(), out Make value) ? value : new Make(name);
        }

        public Make(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        
        public string Name { get; }

        public static readonly Make Apple   = new Make("Apple");
        public static readonly Make Canon   = new Make("Canon");
        public static readonly Make Nikon   = new Make("Nikon");
        public static readonly Make Pentax  = new Make("Pentax");
        public static readonly Make Sony    = new Make("Sony");
        public static readonly Make Sanyo   = new Make("Sanyo");
        public static readonly Make Olympus = new Make("Olympus");

        public static implicit operator string (Make make) => make.Name;
    }
}