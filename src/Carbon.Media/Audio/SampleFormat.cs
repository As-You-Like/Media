namespace Carbon.Media
{
    public enum SampleFormat : byte
    {
        Unknown = 0,  //      | None
        I8      = 1,  // S8   |
        I16     = 2,  // S16  |
        I16p    = 3,  // S16P |      | planar
        I32     = 4,  // S32  |
        I32p    = 5,  // S32P |      | planar
        I64     = 6,  // S64  |
        I64p    = 7,  // S64P |      | planar
        U8      = 8,  // U8   |
        U8p     = 9,  // U8P  |      | planar
        F32     = 10, // F32  |
        F32p    = 11, // F32P | fltp | planar
        F64     = 12, // F64  |
        F64p    = 13, // F64P | dblp | planar
    }
}