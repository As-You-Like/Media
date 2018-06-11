using System;

namespace Carbon.Media
{
    using static SampleFormat;

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