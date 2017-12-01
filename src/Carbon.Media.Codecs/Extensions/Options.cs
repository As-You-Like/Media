
using FFmpeg.AutoGen;

namespace Carbon.Media.Codecs
{
    internal unsafe class Options
    {
        public Options() { }

        private Options(AVDictionary* pointer)
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

        public static Options Parse(string text)
        {
            AVDictionary* pointer;

            // -c:a aac -q:a 2
            
            ffmpeg.av_dict_parse_string(&pointer, text, "=", ",", 0).EnsureSuccess();

            return new Options(pointer);   
        }
    }
}
