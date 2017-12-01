using System;

namespace Carbon.Media.Metadata
{
    [Flags]
    public enum CodingMethods
    {
        Unspecified     = 0,
        ModifiedHuffman = 1 << 0, // MH
        ModifiedRead    = 1 << 1, // MR
        ModifiedMR      = 1 << 2, // MMR
        JBIG            = 1 << 3, // JIB
        BaselineJPEG    = 1 << 4, // BaselineJPEG
        JBIGColor       = 1 << 5
    }

}
