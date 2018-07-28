using System;

namespace Carbon.Media.Processors
{
    using static FormatId;
    
    public static class EncodingHelper
    {
        public static (FormatId id, EncodingFlags flags) ParseFormat(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            switch (text.ToLower())
            {
                case "png"    : return (Png,  default);
                case "jpeg"   : return (Jpeg, default);
                case "gif"    : return (Gif,  default);
                case "webp"   : return (WebP, default);
                case "ico"    : return (Ico,  default);

                // audio
                case "aac"    : return (Aac, default);
                case "flac"   : return (Flac, default);
                case "m4a"    : return (M4a, default);
                case "mp3"    : return (Mp3, default);
                case "opus"   : return (Opus, default);

                // videos
                case "webm"   : return (WebM, default);
                case "mp4"    : return (Mp4, default);

                case "pjpg"   : return (Jpeg, EncodingFlags.Progressive);
                case "png8"   : return (Png,  EncodingFlags._8bit);
                case "png32"  : return (Png,  EncodingFlags._32bit);
                case "webpll" : return (WebP, EncodingFlags.Lossless);
                case "webply" : return (WebP, default);

                default       : return ((FormatId)ImageFormatHelper.Parse(text), default);
            }       
        }
    }
}