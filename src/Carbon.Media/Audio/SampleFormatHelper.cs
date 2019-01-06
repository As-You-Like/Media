using System;

namespace Carbon.Media
{
    using static SampleFormat;

    public static class SampleFormatHelper
    {
        public static bool IsPlanar(SampleFormat sampleFormat)
        {
            switch (sampleFormat)
            {
                case U8p:
                case I16p:
                case I32p:
                case I64p:
                case F32p:
                case F64p: return true;
            }

            return false;
        }

        public static SampleFormat Parse(string text)
        {
            if (text is null) throw new ArgumentNullException(nameof(text));

           switch (text)
            {
                case "i8"   : return I8;
                case "i16"  : return I16;
                case "i32"  : return I32;
                case "i64"  : return I64;
                case "u8"   : return U8;
                case "f32"  : return F32;
                case "f64"  : return F64;
                case "u8p"  : return U8p;
                case "i16p" : return I16p;
                case "i32p" : return I32p;
                case "f32p" : return F32p;
                case "f64p" : return F64p;
                case "i64p" : return I64p;

                // Aliases
                case "s16" : return I16;
                case "s32" : return I32;
                case "s64" : return I64;
                case "s16p": return I16p;
                case "s32p": return I32p;
                case "s64p": return I64p;
                case "flt" : return F32;
                case "dbl" : return F64;
                case "fltp": return F32p;
                case "dblp": return F64p;
                    
                default: throw new Exception($"Invalid SampleFormat '{text}'.");
            }
        }
    }
}