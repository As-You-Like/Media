using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public static class MimeExtensions
    {
        public static FormatId ToFormatId(this Mime mime)
        {
            switch (mime.Format)
            {
                case "aac"  : return FormatId.Aac;
                case "aiff" : return FormatId.Aiff;
                case "asf"  : return FormatId.Asf;
                case "avi"  : return FormatId.Avi;
                case "bmp"  : return FormatId.Bmp;
                case "flac" : return FormatId.Flac;
                case "f4v"  : return FormatId.Mp4;
                case "flv"  : return FormatId.Flv;
                case "gif"  : return FormatId.Gif;
                case "heif" : return FormatId.Heif;
                case "ico"  : return FormatId.Ico;
                case "jpeg" : return FormatId.Jpeg;
                case "jp2"  : return FormatId.Jp2;
                case "m4a"  : return FormatId.M4a;
                case "m4v"  : return FormatId.Mp4;
                case "mp3"  : return FormatId.Mp3;
                case "mp4"  : return FormatId.Mp4;
                case "mpeg" : return FormatId.Mp1;
                case "mov"  : return FormatId.Mov;
                case "ogg"  : return FormatId.Ogg;
                case "oga"  : return FormatId.Ogg;
                case "ogv"  : return FormatId.Ogv;
                case "opus" : return FormatId.Opus;
                case "png"  : return FormatId.Png;
                case "psd"  : return FormatId.Psd;
                case "pdf"  : return FormatId.Pdf;
                case "tiff" : return FormatId.Tiff;
                case "wav"  : return FormatId.Wav;
                case "webm" : return FormatId.WebM;
                case "webp" : return FormatId.WebP;
            }

            if (!Enum.TryParse<FormatId>(mime.Format, true, out var result))
            {
                throw new KeyNotFoundException("No format for " + mime.Format);
            }

            return result;
        }

    }
}
