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
            }

            throw new Exception("Invalid SampleFormat:" + format);
        }
        
        public static string Canonicalize(this SampleFormat format)
        {
            switch (format)
            {
                case I8   : return "i8";
                case I16  : return "i16";
                case I32  : return "i32";
                case I64  : return "i64";
                case U8   : return "u8";
                case F32  : return "f32";
                case F64  : return "f64";
                case U8p  : return "u8p";
                case I16p : return "i16p";
                case I32p : return "i32p";
                case I64p : return "i64p";
                case F32p : return "f32p";
                case F64p : return "f64p";
            }

            throw new Exception("Invalid SampleFormat:" + format);
        }
    }
}