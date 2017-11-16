namespace Carbon.Media.Processors
{
    using static FormatId;
    
    public static class EncodingHelper
    {
        public static (FormatId id, EncodingFlags flags) ParseFormat(string text)
        {
            switch (text.ToLower())
            {
                case "pjpg"   : return (Jpeg, EncodingFlags.Progressive);
                case "png8"   : return (Png,  EncodingFlags._8bit);
                case "png32"  : return (Png,  EncodingFlags._32bit);
                case "webpll" : return (WebP, EncodingFlags.Lossless);

                // audio
                case "aac"    : return (Aac, default);
                case "flac"   : return (Flac, default);
                case "mp3"    : return (Mp3, default);
                case "opus"   : return (Opus, default);

                // videos
                case "webm"   : return (WebM, default);
                case "mp4"    : return (Mp4, default);

                default       : return ((FormatId)ImageFormatHelper.Parse(text), default);
            }       
        }
    }
}