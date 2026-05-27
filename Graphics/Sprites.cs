using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound.Graphics
{
    static class Sprites
    {
        public static Sprite Player = new Sprite (new[] {"PP", "||"}, ConsoleColor.Blue);

        public static Sprite Stalker = new Sprite(new[] {"ZZ", "ZZ"}, ConsoleColor.Red);

        public static Sprite Wall = new Sprite(new[] {"##", "##"}, ConsoleColor.DarkGray);

        public static Sprite Floor = new Sprite (new[] {"  ", "  "}, ConsoleColor.Black);

        public static Sprite Exit = new Sprite(new[] {"EE", "EE"}, ConsoleColor.Green);

    }
}
