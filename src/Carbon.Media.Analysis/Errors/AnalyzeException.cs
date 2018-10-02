using System;

namespace Carbon.Media.Analysis
{
    public sealed class AnalyzeException : Exception
    {
        public AnalyzeException(AnalyzeError error)
            : base(error.String)
        {
            Code = error.Code;
        }

        public long Code { get; }       
    }
}