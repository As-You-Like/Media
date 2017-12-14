using System;
using System.Collections.Generic;

namespace Carbon.Media.Metadata
{
    public readonly struct CameraMake
    {
        private static readonly Dictionary<string, CameraMake> map = new Dictionary<string, CameraMake> {
            { "PENTAX CORPORATION", Pentax },
            { "NIKON CORPORATION", Nikon },
        };

        public static CameraMake Get(string name)
        {
            return map.TryGetValue(name.ToUpper(), out CameraMake value) ? value : new CameraMake(name);
        }

        public CameraMake(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        
        public readonly string Name;

        public static readonly CameraMake Nikon  = new CameraMake("Nikon");
        public static readonly CameraMake Pentax = new CameraMake("Pentax");
        public static readonly CameraMake Sony   = new CameraMake("Sony");
    }
}