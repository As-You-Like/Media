using System;
using System.Runtime.Serialization;

namespace Carbon.Media.Segmentation
{
    public class MediaSegmentInfo
    {
        public MediaSegmentInfo() { }

        public MediaSegmentInfo(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string Name { get; set; }

        [DataMember(Name = "sequenceNumber")]
        public int SequenceNumber { get; set; }

        [DataMember(Name = "pts", EmitDefaultValue = false)]
        public long Pts { get; set; }

        [DataMember(Name = "duration", EmitDefaultValue = false)]
        public long Duration { get; set; }

        // Casing is correct
        [DataMember(Name = "timescale", EmitDefaultValue = false)]
        public int Timescale { get; set; }

        [DataMember(Name = "size", EmitDefaultValue = false)]
        public long Size { get; set; } // in bytes
        
        [DataMember(Name = "flags", EmitDefaultValue = false)]
        public MediaSegmentFlags Flags { get; set; }
    }
}



// 2 - 3 second (optimal) for persistent connections
// 5-8 for non persistent connections

// APPLE Recomends 6 seconds

// FrameCount
// BitRate (Average, Min, Max)

// Live
// VOD

// References:
// Optiomal Segment Duration: https://streaminglearningcenter.com/blogs/choosing-the-optimal-segment-duration.html
// 2 - 3 seconds for persistent connections
// 5 - 8 seconds for non-persistant connections

// GOP
// --min-keyint = fps * 2 
// --keyint     = fps * 2


// 2 second segments

// Apple recomends 6 second segments

// Segment durations SHOULD be nominally 6 seconds (e.g., NTSC 29.97 may be 6.006 seconds).

// https://streaminglearningcenter.com/wp-content/uploads/2016/11/Cloud_encoder_with_FFmpeg-1.pdf