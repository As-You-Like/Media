using FFmpeg.AutoGen;

namespace Carbon.Media
{
    internal unsafe struct OutputFormat
    {
        private readonly AVOutputFormat* pointer;

        public OutputFormat(AVOutputFormat* pointer)
        {
            this.pointer = pointer;
        }

        public OutputFormatFlags Flags => (OutputFormatFlags)pointer->flags;
    }
}