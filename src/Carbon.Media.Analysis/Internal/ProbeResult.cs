using System.Runtime.Serialization;
using Carbon.Media.Metadata;

namespace Carbon.Media.Analysis.Internal
{
    public class ProbeResult
    {
        [DataMember(Name = "format")]
        public ProbedFormat Format { get; set; }

        [DataMember(Name = "streams")]
        public ProbedStream[] Streams { get; set; }

        // packets
        // streams
        // chapters
        // error

        public FormatInfo ToFormatInfo()
        {
            var formatName = Format.FormatName;
            
            if (formatName.IndexOf(',') is int commaIndex
                && commaIndex > -1)
            {
                formatName = formatName.Substring(0, commaIndex);
            }

            var format = new FormatInfo {
                Type = Mime.TryGetFromFormat(formatName, out var mime) ? mime.Name : "application/" + formatName,
                Format = formatName,
                Size = Format.Size,
                Duration = Format.Duration,
                Streams = new MediaStreamInfo[Streams.Length]                
            };

         
            for (var i = 0; i < Streams.Length; i++)
            {
                var stream = Streams[i].ToStreamInfo();

                format.Streams[i] = stream;

                if (stream is VideoStreamInfo videoStream)
                {
                    format.Width = videoStream.Width;
                    format.Height = videoStream.Height;
                    format.Rotate = videoStream.Rotate;
                }
            }

            return format;

        }

    }
}

// SCHEMA
// https://raw.githubusercontent.com/FFmpeg/FFmpeg/master/doc/ffprobe.xsd
