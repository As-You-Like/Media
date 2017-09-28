using System;

namespace Carbon.Media
{
    using static SampleFormatFlags;

    public struct SampleFormatInfo
    {
        public SampleFormatInfo(
            SampleFormat id, 
            int bitCount, 
            Type type,
            SampleFormatFlags flags = default)
        {
            Id       = id;
            BitCount = bitCount;
            Type     = type;
            Flags    = flags;
        }

        public SampleFormat Id { get; }

        // BitsPerSample
        public int BitCount { get; }

        public Type Type { get; }

        public SampleFormatFlags Flags { get; }

        public bool IsPlanar => Flags.HasFlag(Planar);

        public static readonly SampleFormatInfo Int8         = new SampleFormatInfo(SampleFormat.Int8,         8,  typeof(sbyte));
        public static readonly SampleFormatInfo Int16        = new SampleFormatInfo(SampleFormat.Int16,        16, typeof(short));       
        public static readonly SampleFormatInfo Int32        = new SampleFormatInfo(SampleFormat.Int32,        32, typeof(int));       
        public static readonly SampleFormatInfo Int64        = new SampleFormatInfo(SampleFormat.Int64,        64, typeof(long));       
        public static readonly SampleFormatInfo UInt8        = new SampleFormatInfo(SampleFormat.UInt8,        8,  typeof(byte));       
        public static readonly SampleFormatInfo Float        = new SampleFormatInfo(SampleFormat.Float,        32, typeof(float));       
        public static readonly SampleFormatInfo Double       = new SampleFormatInfo(SampleFormat.Double,       64, typeof(double));      
        public static readonly SampleFormatInfo UInt8Planar  = new SampleFormatInfo(SampleFormat.UInt8Planar,  8,  typeof(byte),   Planar);
        public static readonly SampleFormatInfo Int16Planar  = new SampleFormatInfo(SampleFormat.Int16Planar,  16, typeof(short),  Planar);
        public static readonly SampleFormatInfo Int32Planar  = new SampleFormatInfo(SampleFormat.Int32Planar,  32, typeof(int),    Planar);
        public static readonly SampleFormatInfo FloatPlanar  = new SampleFormatInfo(SampleFormat.FloatPlanar,  32, typeof(float),  Planar);
        public static readonly SampleFormatInfo DoublePlanar = new SampleFormatInfo(SampleFormat.DoublePlanar, 64, typeof(double), Planar);
        public static readonly SampleFormatInfo Int64Planar  = new SampleFormatInfo(SampleFormat.Int64Planar,  64, typeof(long),   Planar);

        public static SampleFormatInfo Get(SampleFormat id)
        {
            switch (id)
            {
                case SampleFormat.Int8         : return Int8;      
                case SampleFormat.Int16        : return Int16;      
                case SampleFormat.Int32        : return Int32;      
                case SampleFormat.Int64        : return Int64;      
                case SampleFormat.UInt8        : return UInt8;      
                case SampleFormat.Float        : return Float;     
                case SampleFormat.Double       : return Double; 
                case SampleFormat.UInt8Planar  : return UInt8Planar;
                case SampleFormat.Int16Planar  : return Int16Planar;
                case SampleFormat.Int32Planar  : return Int32Planar;
                case SampleFormat.FloatPlanar  : return FloatPlanar;
                case SampleFormat.DoublePlanar : return DoublePlanar;
                case SampleFormat.Int64Planar  : return Int64Planar;
                default: throw new ArgumentException("unexpected sample format:" + id);
            }
        }
    }

    public enum SampleFormatFlags : byte
    {
        None  = 0,
        Planar = 1
    }
}
