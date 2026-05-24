using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound
{
    static class Sprites
    {
        public static Sprite Player = new Sprite (new[] {"P"}, ConsoleColor.Blue);

        public static Sprite Stalker = new Sprite(new[] {"Z"}, ConsoleColor.Red);

        public static Sprite Wall = new Sprite(new[] {"#"}, ConsoleColor.DarkGray);

        public static Sprite Floor = new Sprite (new[] {" "}, ConsoleColor.Black);

        public static Sprite Exit = new Sprite(new[] { "E" }, ConsoleColor.Green);

    }
}
