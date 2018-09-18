using System;

namespace Carbon.Media
{
    public static class MediaTypeHelper
    {
        public static MediaType Parse(ReadOnlySpan<char> text)
        {
            switch (text[0])
            {
                case 'a':
                    switch (text[1])
                    {
                        case 'p': return MediaType.Application;
                        case 'u': return MediaType.Audio;
                    }
                    break;
                case 'e': return MediaType.Example;
                case 'f': return MediaType.Font;
                case 'i': return MediaType.Image;
                case 'm':
                    switch (text[1])
                    {
                        case 'e': return MediaType.Message;
                        case 'o': return MediaType.Model;
                        case 'u': return MediaType.Multipart;
                    }
                    break;
                case 't': return MediaType.Text;
                case 'v': return MediaType.Video;
            }

            throw new InvalidValueException(nameof(MediaType), text.ToString());
        }
    }
}