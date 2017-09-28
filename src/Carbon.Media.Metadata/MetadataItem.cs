using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Metadata
{
    public class MetadataItem
    {
        private readonly string normalized;

        public MetadataItem(string path, object rawValue)
        {
            Path     = path ?? throw new ArgumentNullException(nameof(path));
            RawValue = rawValue ?? throw new ArgumentNullException(nameof(rawValue));
            RawType   = rawValue.GetType().Name;

            var info = MetadataMap.Get(path);

            if (info != null)
            {
                Name = info.Name;

                var v = info.Normalize(rawValue);

                if (v != null)
                {
                    this.normalized = v.ToString();
                }
            }
        }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; }

        [DataMember(Name = "value", EmitDefaultValue = false)]
        public string Value { get; }

        [IgnoreDataMember]
        public object RawValue { get; }

        [IgnoreDataMember]
        public string RawType { get; }

        [IgnoreDataMember]
        public string Path { get; }

        [DataMember(EmitDefaultValue = false)]
        public string RawData
        {
            get
            {
                if (normalized != null) return null;

                return Path + " : " + RawValue;
            }
        }
    }
}
