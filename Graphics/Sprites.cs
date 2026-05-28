using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound.Graphics
{
    static class Sprites
    {
        public static Sprite Player = new Sprite (new[] {"OO", "IL"}, ConsoleColor.Blue);

        public static Sprite Stalker = new Sprite(new[] {"SS", "SS"}, ConsoleColor.Red);

        public static Sprite Wall = new Sprite(new[] {"##", "##"}, ConsoleColor.DarkGray);

        public static Sprite Floor = new Sprite (new[] {"  ", "  "}, ConsoleColor.Black);

        public static Sprite Exit = new Sprite(new[] {"EX", "IT"}, ConsoleColor.Green);

    }
}
