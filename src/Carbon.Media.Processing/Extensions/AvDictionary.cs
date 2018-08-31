
using System;
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    public unsafe class AvDictionary
    {
        public AvDictionary() { }

        private AvDictionary(AVDictionary* pointer)
        {
            Pointer = pointer;
        }

        public AVDictionary* Pointer;

        public void Set(string key, long value)
        {
            fixed (AVDictionary** p = &Pointer)
            {
                ffmpeg.av_dict_set_int(p, key, value, 0);
            }
        }

        public void Set(string key, string value)
        {
            fixed (AVDictionary** p = &Pointer)
            {
                ffmpeg.av_dict_set(p, key, value, 0);
            }
        }
        
        public void SetFlag(string key, string value, int flags = 0)
        {
            fixed (AVDictionary** p = &Pointer)
            {
                ffmpeg.av_dict_set(p, key, value, flags);
            }

            // e.g.
            // av_dict_set( &dict, "movflags", "faststart", 0 );
        }

        public static AvDictionary Parse(string text)
        {
            AVDictionary* pointer;

            // -c:a aac -q:a 2

            ffmpeg.av_dict_parse_string(&pointer, text, "=", ",", 0).EnsureSuccess();

            return new AvDictionary(pointer);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);

            Dispose(true);
        }

        public unsafe void Dispose(bool dispose)
        {
            if (Pointer == null) return;

            // Console.WriteLine("Disposing AVDictionary");

            fixed (AVDictionary** p = &Pointer)
            {
                ffmpeg.av_dict_free(p);

                Pointer = null;
            }
        }

        ~AvDictionary()
        {
            Dispose(false);
        }
    }
}
