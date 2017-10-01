using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public abstract class Frame : IDisposable
    {
        /// <summary>
        /// The order the frame is encoded within the bitstream (coded picture number)
        /// </summary>
        public long CodedIndex { get; set; } 

        /// <summary>
        /// The order the frame is presented (e.g. display picture number)
        /// </summary>
        public long PresentationIndex { get; set; }

        // SmtpeTimecode
        
        /// <summary>
        /// Decoding time
        /// </summary>
        public virtual long Dts { get; set; }

        /// <summary>
        /// Presentation time
        /// </summary>
        public virtual long Pts { get; set; }
        
        /// <summary>
        /// The duration the frame is presented
        /// </summary>
        public long Duration { get; set; }
        
        public Dictionary<string, string> Metadata { get; set; }

        public abstract void Dispose();
    }
}
