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
                case I8   : return 1;
                case I16  : return 2;
                case I32  : return 4;
                case I64  : return 8;
                case U8   : return 1;
                case F32  : return 4;
                case F64  : return 8;
                case U8p  : return 1;
                case I16p : return 2;
                case I32p : return 4;
                case F32p : return 4;
                case F64p : return 8;
                case I64p : return 8;
                default:
                    throw new Exception("Invalid SampleFormat:" + format);
            }
        }
    }
}