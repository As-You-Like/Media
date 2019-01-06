using System;
using System.Runtime.Serialization;

namespace Carbon.Media
{
    using static SampleFormatFlags;

    [DataContract]
    public sealed class SampleFormatInfo : IEquatable<SampleFormatInfo>
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

        [DataMember(Name = "id", Order = 1)]
        public SampleFormat Id { get; }

        /// <summary>
        /// Bits per sample
        /// </summary>
        [DataMember(Name = "bitCount", Order = 3)]
        public int BitCount { get; }

        [DataMember(Name = "flags", Order = 4)]
        public SampleFormatFlags Flags { get; }

        [IgnoreDataMember]
        public Type Type { get; }

        [IgnoreDataMember]
        public bool IsPlanar => (Flags & Planar) != 0;

        #region Equality

        public bool Equals(SampleFormatInfo other) =>
            Id       == other.Id &&
            BitCount == other.BitCount &&
            Type     == other.Type &&
            Flags    == other.Flags;

        #endregion

        public static readonly SampleFormatInfo UInt8  = new SampleFormatInfo(SampleFormat.U8,   8,  typeof(byte));
        public static readonly SampleFormatInfo Int8   = new SampleFormatInfo(SampleFormat.I8,   8,  typeof(sbyte));
        public static readonly SampleFormatInfo Int16  = new SampleFormatInfo(SampleFormat.I16,  16, typeof(short));
        public static readonly SampleFormatInfo Int32  = new SampleFormatInfo(SampleFormat.I32,  32, typeof(int));
        public static readonly SampleFormatInfo Int64  = new SampleFormatInfo(SampleFormat.I64,  64, typeof(long));
        public static readonly SampleFormatInfo F32    = new SampleFormatInfo(SampleFormat.F32,  32, typeof(float));
        public static readonly SampleFormatInfo F64    = new SampleFormatInfo(SampleFormat.F64,  64, typeof(double));
        public static readonly SampleFormatInfo UInt8p = new SampleFormatInfo(SampleFormat.U8p,  8,  typeof(byte),   Planar);
        public static readonly SampleFormatInfo Int16p = new SampleFormatInfo(SampleFormat.I16p, 16, typeof(short),  Planar);
        public static readonly SampleFormatInfo Int32p = new SampleFormatInfo(SampleFormat.I32p, 32, typeof(int),    Planar);
        public static readonly SampleFormatInfo Int64p = new SampleFormatInfo(SampleFormat.I64p, 64, typeof(long),   Planar);
        public static readonly SampleFormatInfo F32p   = new SampleFormatInfo(SampleFormat.F32p, 32, typeof(float),  Planar);
        public static readonly SampleFormatInfo F64p   = new SampleFormatInfo(SampleFormat.F64p, 64, typeof(double), Planar);

        public static SampleFormatInfo Get(SampleFormat id)
        {
            switch (id)
            {
                case SampleFormat.I8   : return Int8;
                case SampleFormat.I16  : return Int16;
                case SampleFormat.I32  : return Int32;
                case SampleFormat.I64  : return Int64;
                case SampleFormat.U8   : return UInt8;
                case SampleFormat.F32  : return F32;
                case SampleFormat.F64  : return F64;
                case SampleFormat.U8p  : return UInt8p;
                case SampleFormat.I16p : return Int16p;
                case SampleFormat.I32p : return Int32p;
                case SampleFormat.I64p : return Int64p;
                case SampleFormat.F32p : return F32p;
                case SampleFormat.F64p : return F64p;
            }

            throw new ArgumentException("Invalid SampleFormat:" + id);
        }
    }
}