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

        public int Offset { get; set; }

        public byte[] Data { get; set; }


        public Mime Mime { get; set; }

        public static MimeSignature Hex(int offset, string text, Mime mime)
        {
            return new MimeSignature(0, new byte[0], mime);
        }

        public static MimeSignature Ansi(int offset, string text, Mime mime)
        {
            return new MimeSignature(0, new byte[0], mime);
        }

        public static MimeSignature Ansi(string text, Mime mime)
        {
            return new MimeSignature(0, new byte[0], mime);
        }

        public static readonly MimeSignature Ico = Hex(0, "00 00 01 00", Mime.Ico);
        public static readonly MimeSignature Tar = Hex(0, "1F 9D", Mime.Tar);

        public static readonly MimeSignature Gif87a = Ansi("GIF87a", Mime.Gif);
        public static readonly MimeSignature Gif89a = Ansi("GIF89a", Mime.Gif);

        public static readonly MimeSignature Tiff1 = Ansi("II*.", Mime.Gif); // Little Endian
        public static readonly MimeSignature Tiff2 = Ansi("MM.*.", Mime.Gif); // Big Endian

        // public static readonly MimeSignature Bgp = Ansi("BPGû"); 

        public static readonly MimeSignature Jpeg1 = Ansi("ÿØÿÛ", Mime.Jpeg);
        public static readonly MimeSignature Jpeg2 = Ansi("ÿØÿà", Mime.Jpeg);
        public static readonly MimeSignature Jpeg3 = Ansi("F IF", Mime.Jpeg);
        public static readonly MimeSignature Jpeg4 = Ansi("ÿØÿá", Mime.Jpeg);
        public static readonly MimeSignature Jpeg5 = Ansi("x if", Mime.Jpeg);


        // public static readonly MimeSignature Exe = Ansi("MZ", Mime.Jpeg);

        public static readonly MimeSignature Png = Ansi(".PNG", Mime.Png);
        public static readonly MimeSignature Pdf = Ansi("%PDF", Mime.Pdf);
        public static readonly MimeSignature Ogg = Ansi("OggS", Mime.Oga); // TODO: specific type

        public static readonly MimeSignature Wav1 = Ansi("RIFF", Mime.Wav);
        public static readonly MimeSignature Wav2 = Ansi("WAVE", Mime.Wav);

        public static readonly MimeSignature Avi = Ansi("AVI.", Mime.Avi);
        public static readonly MimeSignature Flac = Ansi("fLaC", Mime.Flac);

        // public static readonly MimeSignature Tlif = Ansi("FLIF", Mime.Flif);

    }

}
