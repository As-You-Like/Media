using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    public readonly struct Model
    {
        private static readonly Dictionary<string, Model> map = new Dictionary<string, Model> {
            { "DSC-W310", new Model("DSC-W310") }, // Sony
        };

        // Canonicalize ? 
        public static Model Parse(string name)
        {
            name = name.Trim();

            // Canon PowerShot A460
            // Canon EOS DIGITAL REBEL XT
            if (name.StartsWith("Canon "))
            {
                return new Model(name.Replace("Canon ", string.Empty));
            }
            
            return map.TryGetValue(name.ToUpper(), out Model value) ? value : new Model(name);
        }

        public Model(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
        
        [DataMember(Name = "name", Order = 1)]
        public string Name { get; }

        public static implicit operator string(Model model) => model.Name;
    }
}