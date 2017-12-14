using System;

namespace Carbon.Media.Metadata
{
    public sealed class NumberToEnum<T> : MetadataItemConverter
    {
        public override object Normalize(object value)
        {
            return Enum.ToObject(typeof(T), int.Parse(value.ToString()));
        }
    }
}