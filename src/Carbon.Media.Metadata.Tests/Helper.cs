using System.IO;
using ProtoBuf;

namespace Carbon.Media.Metadata.Tests
{
    public static class Helper
    {
        public static T SerializeAndBack<T>(T metadata)
        {
            var output = Serialize(metadata);

            return Serializer.Deserialize<T>(output);
        }

        public static MemoryStream Serialize<T>(T instance)
        {
            var output = new MemoryStream();

            Serializer.Serialize(output, instance);

            output.Position = 0;

            return output;
        }
        
    }
}