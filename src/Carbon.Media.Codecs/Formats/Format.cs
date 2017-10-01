﻿using System;

namespace Carbon.Media.Formats
{
    public abstract class Format : IDisposable
    {
        public abstract FormatId Id { get; }

        public virtual void Dispose()
        {
            
        }
    }
}