using System;

using FFmpeg.AutoGen;

namespace Carbon.Media
{
    public unsafe /*readonly*/ struct Filter
    {
        static Filter()
        {
            // ensure the filters are registred
            ffmpeg.avfilter_register_all();
        }

        private readonly AVFilter* pointer;

        public Filter(AVFilter* pointer)
        {
            this.pointer = pointer;
        }

        public AVFilter* Pointer => pointer;

        public static Filter FromName(string name)
        {
            var pointer = ffmpeg.avfilter_get_by_name(name);

            if (pointer == null)
            {
                throw new Exception("no filter returned for:" + name);
            }

            return new Filter(pointer);
        }
    }
}
