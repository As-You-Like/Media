﻿using System;
using System.Collections.Generic;
using System.Text;

using Carbon.Media.Drawing;

namespace Carbon.Media.Processors
{
    public class Draw : ITransform
    {
        public Draw(IReadOnlyList<Shape> commands)
        {
            Commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        public IReadOnlyList<Shape> Commands { get; set; }
        
        public string Canonicalize()
        {
            var sb = StringBuilderCache.Aquire();

            WriteTo(sb);
            
            return StringBuilderCache.ExtractAndRelease(sb);
        }

        public void WriteTo(StringBuilder sb)
        {
            sb.Append("draw(");
            
            for(var i = 0; i < Commands.Count; i++)
            {
                if (i > 0)
                {
                    sb.Append(',');
                }

                Commands[i].WriteTo(sb);
            }

            sb.Append(")");
        }
        
        public static Draw Parse(string text)
        {
            int argStart = text.IndexOf('(') + 1;

            var reader = new CommandReader(text.Substring(argStart, text.Length - argStart - 1));
            
            var commands = new List<Shape>();

            while (reader.TryRead(out var command))
            {
                commands.Add(command);
            }

            return new Draw(commands);
        }

        public override string ToString() => Canonicalize();
    }
}