using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    using static AVSampleFormat;

    public static class SampleFormatExtensions
    {
        public static SampleFormat ToFormat(this AVSampleFormat format)
        {
            switch (format)
            {
                case AV_SAMPLE_FMT_NONE : return SampleFormat.Unknown;

                case AV_SAMPLE_FMT_U8   : return SampleFormat.U8;
                case AV_SAMPLE_FMT_S16  : return SampleFormat.I16;
                case AV_SAMPLE_FMT_S32  : return SampleFormat.I32;
                case AV_SAMPLE_FMT_FLT  : return SampleFormat.F32;
                case AV_SAMPLE_FMT_DBL  : return SampleFormat.F64;

                // Planar Formats
                case AV_SAMPLE_FMT_U8P  : return SampleFormat.U8p;
                case AV_SAMPLE_FMT_S16P : return SampleFormat.I16p;
                case AV_SAMPLE_FMT_S32P : return SampleFormat.I32p;
                case AV_SAMPLE_FMT_FLTP : return SampleFormat.F32p;
                case AV_SAMPLE_FMT_DBLP : return SampleFormat.F64p;
                case AV_SAMPLE_FMT_S64  : return SampleFormat.I64;
                case AV_SAMPLE_FMT_S64P : return SampleFormat.I64p;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            }

            throw new Exception("Invalid AVSampleFormat:" + format);
        }

        public static AVSampleFormat ToAVFormat(this SampleFormat format)
        {
            switch (format)
            {
                case SampleFormat.U8   : return AV_SAMPLE_FMT_U8;
                case SampleFormat.I16   : return AV_SAMPLE_FMT_S16; 
                case SampleFormat.I32   : return AV_SAMPLE_FMT_S32;
                case SampleFormat.F32     : return AV_SAMPLE_FMT_FLT;
                case SampleFormat.F64     : return AV_SAMPLE_FMT_DBL;
                case SampleFormat.U8p  : return AV_SAMPLE_FMT_U8P; 
                case SampleFormat.I16p  : return AV_SAMPLE_FMT_S16P;
                case SampleFormat.I32p  : return AV_SAMPLE_FMT_S32P;
                case SampleFormat.F32p    : return AV_SAMPLE_FMT_FLTP;
                case SampleFormat.F64p    : return AV_SAMPLE_FMT_DBLP;
                case SampleFormat.I64   : return AV_SAMPLE_FMT_S64;
                case SampleFormat.I64p  : return AV_SAMPLE_FMT_S64P;
            }

            throw new Exception("Invalid SampleFormat:" + format.ToString());
        }
    }
}