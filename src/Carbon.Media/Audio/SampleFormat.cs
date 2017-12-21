using System;

namespace Carbon.Media
{
    using static SampleFormat;

    public enum SampleFormat : byte
    {
        Unknown      = 0,
        Int8         = 1,  // S8
        Int16        = 2,  // S16
        Int32        = 3,  // S32
        Int64        = 4,  // S64
        UInt8        = 5,  // U8
        Float        = 6,  // F32
        Double       = 7,  // F64
        UInt8Planar  = 8,  // U8P
        Int16Planar  = 9,  // S16P
        Int32Planar  = 10, // S32P
        FloatPlanar  = 11, // F32P
        DoublePlanar = 12, // F64P
        Int64Planar  = 13  // S64P
    }

    public static class SampleFormatExtensions
    {
        public static int GetSize(this SampleFormat format)
        {
            switch (format)
            {
                case Int8         : return 1;
                case Int16        : return 2;
                case Int32        : return 4;
                case Int64        : return 8;
                case UInt8        : return 1;
                case Float        : return 4;
                case Double       : return 8;
                case UInt8Planar  : return 1;
                case Int16Planar  : return 2;
                case Int32Planar  : return 4;
                case FloatPlanar  : return 4;
                case DoublePlanar : return 8;
                case Int64Planar  : return 8;            }

            throw new Exception("Invalid SampleFormat:" + format);
        }
    }
}