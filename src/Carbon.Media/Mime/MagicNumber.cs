// https://en.wikipedia.org/wiki/Magic_number_%28programming%29

namespace Carbon.Media
{
    public class MagicNumber
    {
        public MagicNumber(byte?[] data, uint offset = 0)
        {
            Offset = offset;
            Data = data;
        }

        public uint Offset { get; }

        public byte?[] Data { get; }

        public bool Matches(byte[] data)
        {
            for (var i = 0; i <= data.Length; i++)
            {
                // Null matches can match anything
                if (Data[i] == null) continue;

                if (data[i] != this.Data[i].Value)
                {
                    return false;
                }
            }

            return true;
        }

        public static MagicNumber FromHex(int offset, string text) => new MagicNumber(new byte?[0]);

        public static MagicNumber FromASCII(string text, int offset = 0) => new MagicNumber(new byte?[0]);

        public readonly static MagicNumber Flv = new MagicNumber(new byte?[] { 0x46, 0x4C, 0x56, 0x01 });

        // public static readonly MagicNumber Ico = FromHex(0, "00 00 01 00", ;
        // public static readonly MagicNumber Tar = FromHex(0, "1F 9D");

        public static readonly MagicNumber Gif87a = FromASCII("GIF87a");
        public static readonly MagicNumber Gif89a = FromASCII("GIF89a");

        public static readonly MagicNumber Tiff1 = FromASCII("II*."); // Little Endian
        public static readonly MagicNumber Tiff2 = FromASCII("MM.*."); // Big Endian

        // public static readonly MimeSignature Bgp = Ansi("BPGû"); 

        public static readonly MagicNumber Jpeg1 = FromASCII("ÿØÿÛ");
        public static readonly MagicNumber Jpeg2 = FromASCII("ÿØÿà");
        public static readonly MagicNumber Jpeg3 = FromASCII("F IF");
        public static readonly MagicNumber Jpeg4 = FromASCII("ÿØÿá");
        public static readonly MagicNumber Jpeg5 = FromASCII("x if");

        public static readonly MagicNumber Exe = FromASCII("MZ");

        public static readonly MagicNumber Png = FromASCII(".PNG");

        public static readonly MagicNumber Pdf = FromASCII("%PDF");  // new byte[] { 0x25, 0x50, 0x44, 0x46 }
        public static readonly MagicNumber Ogg = FromASCII("OggS"); // TODO: specific type

        public readonly static MagicNumber Psd = new MagicNumber(new byte?[] { 0x38, 0x42, 0x50, 0x53 });

        public static readonly MagicNumber Wav1 = FromASCII("RIFF");
        public static readonly MagicNumber Wav2 = FromASCII("WAVE");
        public readonly static MagicNumber Mp3 = new MagicNumber(new byte?[] { 0x49, 0x44, 0x33 });

        public static readonly MagicNumber Avi = FromASCII("AVI.");
        public static readonly MagicNumber Flac = FromASCII("fLaC");

        // public static readonly MimeSignature Tlif = Ansi("FLIF", Mime.Flif);
    }
}
