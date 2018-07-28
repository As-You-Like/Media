using System;
using System.IO;
using Carbon.Media.Formats;
using Carbon.Media.IO;
using Carbon.Media.Processors;

namespace Carbon.Media.Processing
{
    public class Processor
    {
        private readonly MediaPipeline pipeline;

        public Processor(MediaPipeline pipeline)
        {
            this.pipeline = pipeline ?? throw new ArgumentNullException(nameof(pipeline));
        }

        public void Process(Stream inputStream, Stream outputStream)
        {
            // - build a filter graph from the pipeline (deinterlace, scale, etc)
            
            using (var packet = Packet.Allocate())
            using (var input = new IOContext(inputStream))
            using (var demuxer = Demuxer.Open(input)) // detects the format & create an AV context
            using (var muxer = new Muxer(FormatId.Mp4))
            {
                muxer.WriteHeader();

                // if the header is incomplete, fill in the missing details from the next few frames
                
                while (demuxer.TryReadPacket(packet))
                {
                    var stream = demuxer.Context.Streams[packet.StreamIndex];

                    // Audio | Video

                    // TODO: Decode the packet
                    // TODO: Apply filters

                    muxer.WritePacket(packet);

                    packet.Unref();
                }

                muxer.WriteTrailer();

                // We may need to rewrite the header here...

            }
        }
    }
}

/*
 _______              ______________
|       |            |              |
| input |  demuxer   | encoded data |   decoder
| file  | ---------> | packets      | -----+
|_______|            |______________|      |
                                           v
                                       _________
                                      |         |
                                      | decoded |
                                      | frames  |
                                      |_________|
 ________             ______________       |
|        |           |              |      |
| output | <-------- | encoded data | <----+
| file   |   muxer   | packets      |   encoder
|________|           |______________|
*/
