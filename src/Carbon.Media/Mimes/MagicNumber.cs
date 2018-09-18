using System;
using System.Text;

namespace Carbon.Media
{
    public sealed class MagicNumber
    {
        private readonly Segment[] segments;

        public MagicNumber(int offset, byte[] data)
         : this(new Segment(offset, data)) { }

        public MagicNumber(params byte[] data)
          : this(new Segment(0, data)) { }

        public MagicNumber(params Segment[] segments)
        {
            this.segments = segments;

            int length = 0;

            for (int i = 0; i < segments.Length; i++)
            {
                ref Segment segment = ref segments[i];

                if (segment.Offset + segment.Data.Length > length)
                {
                    length = segment.Offset + segment.Data.Length;
                }
            }

            Length = length;
        }

        public int Length { get; }

        public Segment[] Segments => segments;

        public bool Matches(ReadOnlySpan<byte> preamble)
        {
            if (preamble.Length < Length) return false;
            
            for (int i = 0; i < segments.Length; i++)
            {
                ref readonly Segment segment = ref segments[i];

                if (!segment.Matches(preamble))
                {
                    return false;
                }
                
            }

            return true;
        }

        public readonly struct Segment
        {
            public Segment(int offset, byte[] data)
            {
                Offset = offset;
                Data = data;
            }

            public byte[] Data { get; }

            public int Offset { get; }

            public bool Matches(ReadOnlySpan<byte> preamble)
            {
                return preamble.Slice(Offset, Data.Length).SequenceEqual(Data);
            }
        }

        public static MagicNumber FromASCII(string text, int offset = 0)
        {
            var data = Encoding.ASCII.GetBytes(text);
            
            return new MagicNumber(new Segment(offset, data));
        }

        public static readonly MagicNumber Aac_1 = new MagicNumber(0xFF, 0xF1);

        public static readonly MagicNumber Aac_2 = new MagicNumber(0xFF, 0xF9);


        //                                                                               f     t     y     p     3     g
        public static readonly MagicNumber _3GP = new MagicNumber(0x0, 0x0, 0x0, 0x1C, 0x66, 0x74, 0x79, 0x70, 0x33, 0x67 );

        public static readonly MagicNumber Aiff = new MagicNumber(0x46, 0x4F, 0x52, 0x4D, 0x00);

        public static readonly MagicNumber Amr = new MagicNumber(0x23, 0x21, 0x41, 0x4D, 0x52);

        // shared with WMA & WMV
        public static readonly MagicNumber Asf = new MagicNumber(0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C);

        //                                                                                    R     I     F     F                                    A     V     I
        public static readonly MagicNumber Avi = new MagicNumber(new Segment(0, new byte[] { 0x52, 0x49, 0x46, 0x46 }), new Segment(8, new byte[] { 0x41, 0x56, 0x49 }));
        
        //                                                         B     P     G     û
        public static readonly MagicNumber Bgp = new MagicNumber(0x42, 0x50, 0x47, 0xFB);

        public static readonly MagicNumber Wmv = new MagicNumber(0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9);

        public static readonly MagicNumber Wma = new MagicNumber(0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF);


        //                                                         B     M
        public static readonly MagicNumber Bmp = new MagicNumber(0x42, 0x4D);

        //                                                          I     I     *     .    .    .    .     .     C     R
        public static readonly MagicNumber Cr2  = new MagicNumber(0x49, 0x49, 0x2a, 0x00, 0x10, 0x0, 0x0, 0x0, 0x43, 0x52);

        public static readonly MagicNumber Doc  = new MagicNumber(0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1);

        public static readonly MagicNumber Ico = new MagicNumber(0x00, 0x00, 0x01, 0x00);

        //                                                          F     L     I     F
        public static readonly MagicNumber Flif = new MagicNumber(0x46, 0x4C, 0x49, 0x46);


        //                                                         f      L     a     C
        public static readonly MagicNumber Flac = new MagicNumber(0x66, 0x4C, 0x61, 0x43, 0x00, 0x00, 0x00, 0x22);

        //                                                         F     L     V    .
        public static readonly MagicNumber Flv = new MagicNumber(0x46, 0x4C, 0x56, 0x01);


        //                                                                        f     t     y     p     f     4     v
        public static readonly MagicNumber F4v = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x66, 0x34, 0x76 });

        public static readonly MagicNumber Gif87a = FromASCII("GIF87a");

        public static readonly MagicNumber Gif89a = FromASCII("GIF89a");
        

        //                                                       .     .     .     .     j     P     .     . 
        public static readonly MagicNumber Jp2 = new MagicNumber(0x0, 0x0, 0x0, 0x0C, 0x6A, 0x50, 0x20, 0x20, 0x0D, 0x0A);
        
        // TODO: variants jpx, jpm, mj2
        
        //                                                           ÿ     Ø     ÿ     Û
        public static readonly MagicNumber Jpeg_1 = new MagicNumber(0xff, 0xd8, 0xff, 0xdb);

        //                                                                                      ÿ     Ø     ÿ     à     ? ?                             J     F     I     F
        public static readonly MagicNumber Jpeg_2 = new MagicNumber(new Segment(0, new byte[] { 0xff, 0xd8, 0xff, 0xe0 }), new Segment(6, new byte[] { 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01 }));

        //                                                                                       ÿ     Ø     ÿ     á     ?     ?                        E     x     i     f
        public static readonly MagicNumber Jpeg_3 = new MagicNumber(new Segment(0, new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 }), new Segment(6, new byte[] { 0x45, 0x78, 0x69, 0x66, 0x00, 0x00 }));

        // jpeg: fd8ffe000104a46494600010100000???


        public static readonly MagicNumber Jxr = new MagicNumber(0x49, 0x49, 0xBC);

        public static readonly MagicNumber Exe = FromASCII("MZ");

        //                                                        I     I     
        public static readonly MagicNumber Rw2 = new MagicNumber(0x49, 0x49, 0x55, 0x00);
        
        //                                                         M     T     h     d
        public static readonly MagicNumber Midi = new MagicNumber(0x4D, 0x54, 0x68, 0x64);

        public static readonly MagicNumber Mpeg_1 = new MagicNumber(0x00, 0x00, 0x01, 0xBA);

        public static readonly MagicNumber Mpeg_2 = new MagicNumber(0x0, 0x0, 0x1, 0xB3);


        //                                                                        f     t     y     p     M     4     A     
        public static readonly MagicNumber M4a = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x41 });

        //                                                                        f     t     y     p     M     4     V
        public static readonly MagicNumber M4v = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x4D, 0x34, 0x56 });

        //                                                        .     E     ß     £
        public static readonly MagicNumber Mkv = new MagicNumber(0x1A, 0x45, 0xDF, 0xA3, 0x93, 0x42, 0x82, 0x88, 0x6D, 0x61, 0x74, 0x72, 0x6F, 0x73, 0x6B, 0x61);


        //                                                          I     D     3
        public static readonly MagicNumber Mp3_1 = new MagicNumber(0x49, 0x44, 0x33);

        //                                                          ÿ     û
        public static readonly MagicNumber Mp3_2 = new MagicNumber(0xFF, 0xFB); // no id3 tag


        //                                                                        f     t     y     p     m     p     4           +  ( 1 | 2 )
        public static readonly MagicNumber Mp4_1 = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x6D, 0x70, 0x34 });


        //                                                                          f     t     y     p     i     s     o     m      
        public static readonly MagicNumber Mp4_2 = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x69, 0x73, 0x6F, 0x6D });

        //                                                                          f     t     y     p     3     g     p             + ( 4 | 5)
        public static readonly MagicNumber Mp4_3 = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x33, 0x67, 0x70 });

        public static readonly MagicNumber Mp4_4 = FromASCII("ftypMSNV", 4);
        public static readonly MagicNumber Mp4_5 = FromASCII("ftypFACE", 4);
        public static readonly MagicNumber Mp4_6 = FromASCII("ftypavc1", 4);
        public static readonly MagicNumber Mp4_7 = FromASCII("ftypdash", 4);

        //                                                                        m     o     o     v
        public static readonly MagicNumber Mov_1 = new MagicNumber(4, new byte[] { 0x6D, 0x6F, 0x6F, 0x76 });
        
        //                                                                          f     t     y     p     q     t
        public static readonly MagicNumber Mov_2 = new MagicNumber(4, new byte[] { 0x66, 0x74, 0x79, 0x70, 0x71, 0x74 });

        // public static readonly MagicNumber Mov_2 = FromASCII("ftyp", 4);

        //                                                        O     g     g     S
        public static readonly MagicNumber Ogg = new MagicNumber(0x4F, 0x67, 0x67, 0x53);  // TODO: specific type (Theora, Flac, Speex, Vorbis)

        public static readonly MagicNumber Opus = new MagicNumber(0x4F, 0x70, 0x75, 0x73, 0x48, 0x65, 0x61, 0x64);

        //                                                          M      M    O     R
        public static readonly MagicNumber Orf_1 = new MagicNumber(0x4d, 0x4d, 0x4f, 0x52, 0x00, 0x00);

        //                                                          I      I    R     O
        public static readonly MagicNumber Orf_2 = new MagicNumber(0x49, 0x49, 0x52, 0x4f, 0x08, 0x00);

        //                                                          I      I    R     S
        public static readonly MagicNumber Orf_3 = new MagicNumber(0x49, 0x49, 0x52, 0x53, 0x08, 0x00);

        public static readonly MagicNumber Otf = new MagicNumber(0x4F, 0x54, 0x54, 0x4F, 0x00);

        //                                                         %     P     D     F
        public static readonly MagicNumber Pdf = new MagicNumber(0x25, 0x50, 0x44, 0x46);

        //                                                              P     N     G
        public static readonly MagicNumber Png = new MagicNumber(0x89, 0x50, 0x4E, 0x47);

        public static readonly MagicNumber Ps = new MagicNumber(0x25, 0x21);

        //                                                        8     B     P     S
        public static readonly MagicNumber Psd = new MagicNumber(0x38, 0x42, 0x50, 0x53);

        public static readonly MagicNumber Raf = FromASCII("FUJIFILMCCD-RAW");

        //                                                         F     W     S
        public static readonly MagicNumber Swf1  = new MagicNumber(0x46, 0x57, 0x53);

        //                                                         C     W     S
        public static readonly MagicNumber Swf2 = new MagicNumber(0x43, 0x57, 0x53);

        public static readonly MagicNumber Ttf = new MagicNumber(0x00, 0x01, 0x00, 0x00, 0x00);


        public static readonly MagicNumber Tar = new MagicNumber(0x1F, 0x9D);

        public static readonly MagicNumber Tiff_1 = new MagicNumber(0x49, 0x49, 0x2A, 0x0);  // II*. | Little Endian
        public static readonly MagicNumber Tiff_2 = new MagicNumber(0x4D, 0x4D, 0x0, 0x2A);  // MM.* | Big Endian


        //                                                                                    R     I     F     F                                    W     A     V     E
        public static readonly MagicNumber Wav = new MagicNumber(new Segment(0, new byte[] { 0x52, 0x49, 0x46, 0x46 }), new Segment(8, new byte[] { 0x57, 0x41, 0x56, 0x45 }));

        //                                                                                     R     I     F     F                                    W     E     B    P
        public static readonly MagicNumber WebP = new MagicNumber(new Segment(0, new byte[] { 0x52, 0x49, 0x46, 0x46 }), new Segment(8, new byte[] { 0x57, 0x45, 0x42, 0x50 }));

        //                                                        .     E     ß     £       // EMBL + ...
        public static readonly MagicNumber WebM = new MagicNumber(0x1A, 0x45, 0xDF, 0xA3); 

        //                                                         w     O     F     F
        public static readonly MagicNumber Woff = new MagicNumber(0x77, 0x4F, 0x46, 0x46);

        //                                                          w     O     F     2
        public static readonly MagicNumber Woff2 = new MagicNumber(0x77, 0x4F, 0x46, 0x46);


        //                                                        x     a     r     !
        public static readonly MagicNumber Xar = new MagicNumber(0x78, 0x61, 0x72, 0x21);

        //                                                        P     K
        public static readonly MagicNumber Zip = new MagicNumber(0x50, 0x4B);
    }
}

// Reference: https://en.wikipedia.org/wiki/List_of_file_signatures

// The National Archives of the UK has mapped most file formats
// http://www.nationalarchives.gov.uk/PRONOM/Format/proFormatSearch.aspx?status=listReport