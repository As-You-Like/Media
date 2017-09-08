using System;
using System.Collections.Generic;

namespace Carbon.Media
{
    public class Chapter
    {
        public Chapter(TimeSpan start, TimeSpan end, Dictionary<string, string> metadata)
        {
            Start    = start;
            End      = end;
            Metadata = metadata;
        }

        public TimeSpan Start { get; }

        public TimeSpan End { get; }

        public Dictionary<string, string> Metadata { get; }
    }
}