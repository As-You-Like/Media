using System;
using System.Text;

namespace Carbon.Media
{
    public sealed class MagicNumber
    {
        public MagicNumber(params byte?[] data)
            : this(data, 0) { }

        public MagicNumber(byte?[] data, int offset = 0)
        {
            Data   = data ?? throw new ArgumentNullException(nameof(data));
            Offset = offset;
        }

        public byte?[] Data { get; }

        public int Offset { get; }

        // TODO: ReadOnlySpan<byte>
        public bool Matches(byte[] data)
        {
            if (data.Length < Data.Length) return false;

            for (int i = 0; i <= data.Length; i++)
            {
                if (i > Data.Length - 1) break;

                if (Data[i] == null) continue;

                if (Data[i].Value != data[i + Offset])
                {
                    return false;
                }
            }

            return true;
        }

        public static MagicNumber FromASCII(string text, int offset = 0)
        {
            var bytes = Encoding.ASCII.GetBytes(text);

            var nullableBytes = new byte?[bytes.Length];

            for (int i = 0; i < bytes.Length; i++)
            {
                nullableBytes[i] = bytes[i];
            }

            return new MagicNumber(nullableBytes, offset);
        }

        //                                                                               f     t     y     p     3     g
        public static readonly MagicNumber _3GP = new MagicNumber(0x0, 0x0, 0x0, 0x1C, 0x66, 0x74, 0x79, 0x70, 0x33, 0x67 );

        public static readonly MagicNumber Aiff = new MagicNumber(0x46, 0x4F, 0x52, 0x4D, 0x00);

        public static readonly MagicNumber Avi = FromASCII("AVI.");

        //                                                          R     I     F     F
        public static readonly MagicNumber Avi2 = new MagicNumber(0x52, 0x49, 0x46, 0x46);

        //                                                         B     P     G     û
        public static readonly MagicNumber Bgp = new MagicNumber(0x42, 0x50, 0x47, 0xfb);

        public static readonly MagicNumber Bmp = new MagicNumber(new byte?[] { 0x42, 0x4D });

        //                                                          I     I     *     .    .    .    .     .     C     R
        public static readonly MagicNumber Cr2  = new MagicNumber(0x49, 0x49, 0x2a, 0x00, 0x10, 0x0, 0x0, 0x0, 0x43, 0x52);

        public static readonly MagicNumber Doc  = new MagicNumber(0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1);

        public static readonly MagicNumber Ico = new MagicNumber(0x00, 0x00, 0x01, 0x00);

        //                                                          F     L     I     F
        public static readonly MagicNumber Flif = new MagicNumber(0x46, 0x4C, 0x49, 0x46);

        //                                                         f      L     a     C
        public static readonly MagicNumber Flac = new MagicNumber(0x66, 0x4C, 0x61, 0x43);

        //                                                         F     L     V    .
        public static readonly MagicNumber Flv = new MagicNumber(0x46, 0x4C, 0x56, 0x01);

        public static readonly MagicNumber Gif87a = FromASCII("GIF87a");

        public static readonly MagicNumber Gif89a = FromASCII("GIF89a");
        

        //                                                       .     .     .     .     j     P     .     . 
        public static readonly MagicNumber Jp2 = new MagicNumber(0x0, 0x0, 0x0, 0x0C, 0x6A, 0x50, 0x20, 0x20, 0x0D, 0x0A);
        
        // TODO: variants jpx, jpm, mj2
        
        //                                                         ÿ     Ø     ÿ     Û
        public static readonly MagicNumber Jpeg1 = new MagicNumber(0xff, 0xd8, 0xff, 0xdb);

        //                                                         ÿ     Ø     ÿ     à     ?     ?     J     F     I     F     .     .
        public static readonly MagicNumber Jpeg2 = new MagicNumber(0xff, 0xd8, 0xff, 0xe0, null, null, 0x4A, 0x46, 0x49, 0x46, 0x00, 0x01);

        //                                                         ÿ     Ø     ÿ     á     ?     ?     E     x     i     f     .     .
        public static readonly MagicNumber Jpeg3 = new MagicNumber(0xff, 0xd8, 0xFF, 0xe1, null, null, 0x45, 0x78, 0x69, 0x66, 0x00, 0x00);


        public static readonly MagicNumber Jxr = new MagicNumber(0x49, 0x49, 0xBC);

        public static readonly MagicNumber Exe = FromASCII("MZ");
        

        public static readonly MagicNumber Ogg = FromASCII("OggS"); // TODO: specific type (Theora, Flac, Speex, Vorbis)

        public static readonly MagicNumber Opus = new MagicNumber(0x4F, 0x70, 0x75, 0x73, 0x48, 0x65, 0x61, 0x64);

        //                                                         8     B     P     S
        public static readonly MagicNumber Psd = new MagicNumber(0x38, 0x42, 0x50, 0x53);

        //                                                         %     P     D     F
        public static readonly MagicNumber Pdf = new MagicNumber(0x25, 0x50, 0x44, 0x46);  

        //                                                             P   N   G
        public static readonly MagicNumber Png = new MagicNumber(null, 80, 78, 71);

        public static readonly MagicNumber Ps = new MagicNumber(0x25, 0x21);

        public static readonly MagicNumber Tar = new MagicNumber(0x1F, 0x9D);

        public static readonly MagicNumber Tiff1 = new MagicNumber(73, 73, 42, 0);  // II*. | Little Endian
        public static readonly MagicNumber Tiff2 = new MagicNumber(77, 77, 0, 42);  // MM.* | Big Endian

        public static readonly MagicNumber Ttf = new MagicNumber(0x00, 0x01, 0x00, 0x00, 0x00);

        public static readonly MagicNumber Wav1 = FromASCII("RIFF");
        public static readonly MagicNumber Wav2 = FromASCII("WAVE");

        //                                                       I     D     3
        public static readonly MagicNumber Mp3 = new MagicNumber(0x49, 0x44, 0x33);

        //                                                       .     .     .     .     f     t     y     p     m     p     4     2
        public static readonly MagicNumber Mp4 = new MagicNumber(0x0, 0x0, 0x0, 0x18, 0x66, 0x74, 0x79, 0x70, 0x6D, 0x70, 0x34, 0x32);

        //                                                       m     o     o     v
        public static readonly MagicNumber Mov = new MagicNumber(0x6D, 0x6F, 0x6F, 0x76);


        public static readonly MagicNumber Otf = new MagicNumber(0x4F, 0x54, 0x54, 0x4F, 0x00);

        public static readonly MagicNumber Wmv = new MagicNumber(0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9);
        public static readonly MagicNumber Wma = new MagicNumber(0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF);

        public static readonly MagicNumber WebP = new MagicNumber(new byte?[] { 0x57, 0x45, 0x42, 0x50 }, offset: 8);


        public static readonly MagicNumber Mpeg1 = new MagicNumber(0x0, 0x0, 0x1, 0xBA);

        public static readonly MagicNumber Mpeg2 = new MagicNumber(0x0, 0x0, 0x1, 0xB3);

        //                                                          F     W     S
        public static readonly MagicNumber Swf  = new MagicNumber(0x46, 0x57, 0x53);

        //                                                          M     T     h     d
        public static readonly MagicNumber Midi = new MagicNumber(0x4D, 0x54, 0x68, 0x64);

        //                                                         P     K
        public static readonly MagicNumber Zip = new MagicNumber(0x50, 0x4B);
    }
}