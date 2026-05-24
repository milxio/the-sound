using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound
{
    public class Sprite
    {
        public string[] Lines { get; }
        public ConsoleColor Color { get; }

        public Sprite(string[] lines, ConsoleColor color)
        {
            Lines = lines;
            Color = color;
        }

    }
}
