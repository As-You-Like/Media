using System;

namespace Carbon.Media
{
    public static class FormatDetector
    {
        private static readonly Mime[] mimes = new[] {
            Mime.Aac,
            Mime.Aiff,
            Mime.Asf,
            Mime.Avi,
            Mime.Bmp,
            Mime.Cr2,
            Mime.Doc,
            Mime.Flac,
            Mime.Gif,
            Mime.Ico,
            Mime.Flv,
            Mime.Jpeg,
            Mime.Jp2,
            Mime.Png,
            Mime.Tiff,
            Mime.Mov,
            Mime.Mpeg,
            Mime.Mp3,
            Mime.M4a,
            Mime.M4v,
            Mime.Mp4,
            Mime.Ogv,
            Mime.Otf,
            Mime.Pdf,
            Mime.Psd,
            Mime.Raf,
            Mime.Tiff,
            Mime.Wav,
            Mime.WebM,
            Mime.WebP
        };

        // TODO: Build a trie

        public static Mime Detect(ReadOnlySpan<byte> buffer)
        {
            foreach (var mime in mimes)
            {
                foreach (var signature in mime.Signatures)
                {
                    if (signature.Matches(buffer))
                    {
                        return mime;
                    }
                }
            }

            return null;
        }
    }
}