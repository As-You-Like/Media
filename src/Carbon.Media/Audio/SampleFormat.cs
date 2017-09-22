namespace Carbon.Media
{
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
}