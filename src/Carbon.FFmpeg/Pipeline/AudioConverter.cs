using Carbon.Media;

namespace FFmpeg
{
    public abstract class AudioConverter 
    {
        public abstract void Convert(AvFrame inFrame, AvFrame outFrame);
    }
}