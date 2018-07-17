using System;

namespace Carbon.Media
{
    public static class FormatDetector
    {
        private static readonly Mime[] mimes = new[] {
            Mime.Aiff,
            Mime.Avi,
            Mime.Doc,
            Mime.Flac,
            Mime.Gif,
            Mime.Ico,
            Mime.Flv,
            Mime.Jpeg,
            Mime.Jp2,
            Mime.Png,
            Mime.Tiff,
            Mime.Ogv,
            Mime.Pdf,
            Mime.Psd,
            Mime.Wav
        };

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