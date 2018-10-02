using System;
using System.Buffers.Binary;

namespace Carbon.Media.Metadata.Psd
{
    public ref struct PsdHeader
    {
        const int Size = 26;

        private readonly Span<byte> data;

        public PsdHeader(Span<byte> data)
        {
            this.data = data;
        }

        // 0-3 (4)   | Must be 8BPS (0x38425053)
        public uint Signature => BinaryPrimitives.ReadUInt32BigEndian(data.Slice(0, 4));

        // 4-5 (2)
        public ushort Version => BinaryPrimitives.ReadUInt16BigEndian(data.Slice(4, 2));

        // 6-11 (6)
        // public Span<byte> Reserved => data.Slice(6, 6);

        // 12-15 (2) | 1-56
        public ushort ChannelCount => BinaryPrimitives.ReadUInt16BigEndian(data.Slice(12, 2));

        // 14-17 (4) | 1-300,000
        public int ImageHeight => BinaryPrimitives.ReadInt32BigEndian(data.Slice(14, 4));

        // 18-21 (4) | 1-300,000
        public int ImageWidth => BinaryPrimitives.ReadInt32BigEndian(data.Slice(18, 4));

        // 22-23 (2) | 1 ,8, 16, 32
        public ushort Depth => BinaryPrimitives.ReadUInt16BigEndian(data.Slice(22, 2));

        // 24-25 (2) | Bitmap, Grayscale, Indexed, RGB, CMYK, Multichannel, Duotone, Lab 
        public PsdColorMode ColorMode => (PsdColorMode)BinaryPrimitives.ReadUInt16BigEndian(data.Slice(24, 2));
    }
}

// ref: https://www.adobe.com/devnet-apps/photoshop/fileformatashtml/

// All data is stored in big endian byte order.