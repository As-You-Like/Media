namespace Carbon.Media.Analysis
{
    internal class FfmpegHelper
    {
        public static SampleFormat ParseSampleFormat(string text)
        {
            switch (text)
            {
                case "u8"   : return SampleFormat.U8;

                case "s8"   : return SampleFormat.I8;
                case "s16"  : return SampleFormat.I16;          
                case "s32"  : return SampleFormat.I32;   
                case "s64"  : return SampleFormat.I64;

                case "s16p": return SampleFormat.I16p;
                case "s32p": return SampleFormat.I32p;
                case "s64p": return SampleFormat.I64p;

                case "flt": return SampleFormat.F32;
                case "dbl": return SampleFormat.F64;

                case "fltp" : return SampleFormat.F32p;
                case "dblp" : return SampleFormat.F64p;
            }

            return SampleFormat.Unknown;
        }

        // https://ffmpeg.org/doxygen/2.4/group__lavu__sampfmts.html
    }
}
