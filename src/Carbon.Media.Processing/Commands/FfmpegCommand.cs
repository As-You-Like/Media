using System;
using System.Drawing;
using System.Text;

namespace Carbon.Media.Processing
{
    public class FfmpegCommand
    {
        public string Input { get; set; }

        public string Output { get; set; }

        #region Clipping

        // -ss 00:03:05
        public TimeSpan? StartTime { get; set; }

        // -t 00:00:45.0
        public TimeSpan? Duration { get; set; }

        // Crop area with size 100x100 at position (12,34).
        // crop=100:100:12:34
        public Rectangle? Crop { get; set; }

        // -vn
        public bool IgnoreVideo { get; set; }

        // -an
        public bool IgnoreAudio { get; set; }

        #endregion

        // -acodec aac
        public string AudioCodec { get; set; }

        // -b:a 327680
        public BitRate? AudioBitRate { get; set; }

        // -ar 96000
        public long? AudioSampleRate { get; set; }

        // -vcodec h264
        public string VideoCodec { get; set; }

        // -b:v 10485760        (in bits)
        public BitRate? VideoBitRate { get; set; }

        // -r 
        public int? VideoFrameRate { get; set; }

        // -s 1920x1080
        public Size? Size { get; set; }

        // -movflags +faststart
        public bool? FastStart { get; set; }

        public bool IsGif { get; set; }

        // -preset veryslow
        public string Preset { get; set; }
        
        public bool HideBanner { get; set; }

        public bool OutputProgress { get; set; }


        public override string ToString()
        {
            return ToCommand();
        }

        public string ToCommand()
        {
            var sb = new StringBuilder();

            sb.Append("-i ");
            sb.Append('"');
            sb.Append(Input);
            sb.Append('"');
            sb.Append(' ');

            sb.Append("-y ");
            
            // -loglevel fatal -show_error

            if (HideBanner)
            {
                sb.Append("-hide_banner ");
            }

            if (OutputProgress)
            {
                sb.Append("-progress ");
            }

            #region Audio

            if (IgnoreAudio)
            {
                sb.Append("-an");
                sb.Append(' ');
            }

            if (AudioCodec != null)
            {
                sb.Append("-acodec ");
                sb.Append(AudioCodec);
                sb.Append(' ');
            }

            if (AudioBitRate != null)
            {
                sb.Append("-b:a ");
                sb.Append(AudioBitRate.Value);
                sb.Append(' ');
            }

            if (AudioSampleRate != null)
            {
                sb.Append("-ar ");
                sb.Append(AudioSampleRate);
                sb.Append(' ');
            }

            #endregion


            #region Video

            if (IgnoreVideo)
            {
                sb.Append("-vn");
                sb.Append(' ');
            }

            if (VideoCodec != null)
            {
                sb.Append("-vcodec ");
                sb.Append(VideoCodec);
                sb.Append(' ');
            }

            if (VideoBitRate != null)
            {
                sb.Append("-b:v ");
                sb.Append(VideoBitRate.Value);
                sb.Append(' ');
            }
            

            if (Crop is Rectangle crop)
            {
                // crop=100:100:12:34
                // Crop area with size 100x100 at position (12,34).

                // -vf "crop=80:60:200:100"

                // video filter

                sb.Append("-vf ");

                sb.Append('"');
                sb.Append("crop=");
                sb.Append(crop.Width);
                sb.Append(':');
                sb.Append(crop.Height);
                sb.Append(':');
                sb.Append(crop.X);
                sb.Append(':');
                sb.Append(crop.Y);

                if (Size is Size size)
                {
                    sb.Append(", ");
                    sb.Append("scale=");
                    sb.Append(size.Width);
                    sb.Append(':');
                    sb.Append(size.Height);
                }

                sb.Append('"');

                sb.Append(' ');

                // throw new Exception(sb.ToString());
            }
            else if (Size is Size size)
            {
                sb.Append("-s ");
                sb.Append(size.Width);
                sb.Append('x');
                sb.Append(size.Height);
                sb.Append(' ');
            }
           
            #endregion

            if (Preset != null)
            {
                sb.Append("-preset ");
                sb.Append(Preset);
                sb.Append(' ');
            }
            

            if (FastStart == true)
            {
                sb.Append("-movflags ");
                sb.Append("+faststart");
                sb.Append(' ');
            }


            if (IsGif)
            {
                sb.Append("-pix_fmt yuv420p ");

                
                // -crf values can go from 4 to 63. Lower values mean better quality.
                sb.Append("-crf 12 ");
            }

            sb.Append('"');
            sb.Append(Output);
            sb.Append('"');

            return sb.ToString();
        }
    }

    public static class VCodec
    {
        public const string Copy = "copy"; // Copy the original video without transcoding
        public const string H264 = "h264";
    }

    public static class ACodec
    {
        public const string Aac = "aac";
    }
}


// ffmpeg -r 60 -i foo.jpg -c:v libx264 -crf 20 -y -pix_fmt yuv420p foo_avc1.mp4
// ffmpeg -r 60 -i foo.jpg -c:v libx265 -tag:v hvc1 -crf 20 -y -pix_fmt yuv420p foo_hvc1.mp4