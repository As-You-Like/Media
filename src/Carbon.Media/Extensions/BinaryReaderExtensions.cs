using System;
using System.IO;

namespace Carbon.Media.Extensions
{
    internal static class BinaryReaderExtensions
    {
        public static string ReadString(this BinaryReader reader, int length)
            => System.Text.Encoding.ASCII.GetString(reader.ReadBytes(length));

        public static UInt16 ReadUInt16BE(this BinaryReader reader)
            => BitConverter.ToUInt16(ReadBytes(reader, sizeof(UInt16)).ReverseInplace(), 0);

        public static Int16 ReadInt16BE(this BinaryReader reader)
            => BitConverter.ToInt16(ReadBytes(reader, sizeof(Int16)).ReverseInplace(), 0);

        public static UInt32 ReadUInt32BE(this BinaryReader reader)
            => BitConverter.ToUInt32(ReadBytes(reader, sizeof(UInt32)).ReverseInplace(), 0);

        public static Int32 ReadInt32BE(this BinaryReader reader)
            => BitConverter.ToInt32(ReadBytes(reader, sizeof(Int32)).ReverseInplace(), 0);

        private static byte[] ReadBytes(this BinaryReader reader, int byteCount)
        {
            var result = reader.ReadBytes(byteCount);

            if (result.Length != byteCount)
            {
                throw new EndOfStreamException($"{byteCount} bytes required from stream, but only {result.Length} returned.");
            }

            return result;
        }

        private static byte[] ReverseInplace(this byte[] b)
        {
            Array.Reverse(b);

            return b;
        }
    }
}
