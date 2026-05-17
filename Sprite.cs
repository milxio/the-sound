using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound
{
    public struct Sprite
    {
        public char Symbol;
        public ConsoleColor Color;

        public Sprite(char symbol, ConsoleColor color)
        {
            Symbol = symbol;
            Color = color;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Sprite other)
            {
                return Symbol == other.Symbol && Color == other.Color;
            }
            return false;
        }

        public static bool operator ==(Sprite lhs, Sprite rhs) 
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Sprite lhs, Sprite rhs) 
        {
            return !lhs.Equals(rhs);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Symbol, Color);
        }

    }
}
