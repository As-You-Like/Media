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
                case AV_SAMPLE_FMT_U8   : return SampleFormat.UInt8;
                case AV_SAMPLE_FMT_S16  : return SampleFormat.Int16;
                case AV_SAMPLE_FMT_S32  : return SampleFormat.Int32;
                case AV_SAMPLE_FMT_FLT  : return SampleFormat.Float;
                case AV_SAMPLE_FMT_DBL  : return SampleFormat.Double;
                case AV_SAMPLE_FMT_U8P  : return SampleFormat.UInt8Planar;
                case AV_SAMPLE_FMT_S16P : return SampleFormat.Int16Planar;
                case AV_SAMPLE_FMT_S32P : return SampleFormat.Int32Planar;
                case AV_SAMPLE_FMT_FLTP : return SampleFormat.FloatPlanar;
                case AV_SAMPLE_FMT_DBLP : return SampleFormat.DoublePlanar;
                case AV_SAMPLE_FMT_S64  : return SampleFormat.Int64;
                case AV_SAMPLE_FMT_S64P : return SampleFormat.Int64Planar;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          
            }

            throw new Exception("Invalid AVSampleFormat:" + format);
        }

        public static AVSampleFormat ToAVFormat(this SampleFormat format)
        {
            switch (format)
            {
                case SampleFormat.UInt8        : return AV_SAMPLE_FMT_U8;
                case SampleFormat.Int16        : return AV_SAMPLE_FMT_S16; 
                case SampleFormat.Int32        : return AV_SAMPLE_FMT_S32;
                case SampleFormat.Float        : return AV_SAMPLE_FMT_FLT;
                case SampleFormat.Double       : return AV_SAMPLE_FMT_DBL;
                case SampleFormat.UInt8Planar  : return AV_SAMPLE_FMT_U8P; 
                case SampleFormat.Int16Planar  : return AV_SAMPLE_FMT_S16P;
                case SampleFormat.Int32Planar  : return AV_SAMPLE_FMT_S32P;
                case SampleFormat.FloatPlanar  : return AV_SAMPLE_FMT_FLTP;
                case SampleFormat.DoublePlanar : return AV_SAMPLE_FMT_DBLP;
                case SampleFormat.Int64        : return AV_SAMPLE_FMT_S64;
                case SampleFormat.Int64Planar  : return AV_SAMPLE_FMT_S64P;
            }

            throw new Exception("Invalid SampleFormat:" + format.ToString());
        }
    }
}