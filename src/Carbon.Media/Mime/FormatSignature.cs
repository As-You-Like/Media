namespace Carbon.Media
{
    // https://en.wikipedia.org/wiki/Magic_number_%28programming%29

    public class MimeSignature
    {
        public MimeSignature(int offset, byte[] data, Mime mime)
        {
            Offset = offset;
            Data = data;
            Mime = mime;
        }

        public MimeSignature(int offset, string hex, Mime mime)
            : this(0, new byte[0], mime) { }

        public int Offset { get; }

        public byte[] Data { get; }

        public Mime Mime { get; }

        public static MimeSignature FromHex(int offset, string text, Mime mime)
            => new MimeSignature(0, new byte[0], mime);

        public static MimeSignature FromAnsi(int offset, string text, Mime mime)
            => new MimeSignature(0, new byte[0], mime);

        public static MimeSignature FromAnsi(string text, Mime mime)
            => new MimeSignature(0, new byte[0], mime);

        public static readonly MimeSignature Ico = FromHex(0, "00 00 01 00", Mime.Ico);
        public static readonly MimeSignature Tar = FromHex(0, "1F 9D", Mime.Tar);

        public static readonly MimeSignature Gif87a = FromAnsi("GIF87a", Mime.Gif);
        public static readonly MimeSignature Gif89a = FromAnsi("GIF89a", Mime.Gif);

        public static readonly MimeSignature Tiff1 = FromAnsi("II*.", Mime.Gif); // Little Endian
        public static readonly MimeSignature Tiff2 = FromAnsi("MM.*.", Mime.Gif); // Big Endian

        // public static readonly MimeSignature Bgp = Ansi("BPGû"); 

        public static readonly MimeSignature Jpeg1 = FromAnsi("ÿØÿÛ", Mime.Jpeg);
        public static readonly MimeSignature Jpeg2 = FromAnsi("ÿØÿà", Mime.Jpeg);
        public static readonly MimeSignature Jpeg3 = FromAnsi("F IF", Mime.Jpeg);
        public static readonly MimeSignature Jpeg4 = FromAnsi("ÿØÿá", Mime.Jpeg);
        public static readonly MimeSignature Jpeg5 = FromAnsi("x if", Mime.Jpeg);

        // public static readonly MimeSignature Exe = Ansi("MZ", Mime.Jpeg);

        public static readonly MimeSignature Png = FromAnsi(".PNG", Mime.Png);
        public static readonly MimeSignature Pdf = FromAnsi("%PDF", Mime.Pdf);
        public static readonly MimeSignature Ogg = FromAnsi("OggS", Mime.Oga); // TODO: specific type

        public static readonly MimeSignature Wav1 = FromAnsi("RIFF", Mime.Wav);
        public static readonly MimeSignature Wav2 = FromAnsi("WAVE", Mime.Wav);

        public static readonly MimeSignature Avi = FromAnsi("AVI.", Mime.Avi);
        public static readonly MimeSignature Flac = FromAnsi("fLaC", Mime.Flac);

        // public static readonly MimeSignature Tlif = Ansi("FLIF", Mime.Flif);
    }
}
