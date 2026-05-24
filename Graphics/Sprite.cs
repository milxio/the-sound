using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound.Graphics
{
    public class Sprite
    {
        public string[] Lines { get; }
        public ConsoleColor Color { get; }

        public int Height => Lines.Length;
        public int Width => Lines[0].Length;

        public Sprite(string[] lines, ConsoleColor color)
        {
            Lines = lines;
            Color = color;
        }

    }
}
