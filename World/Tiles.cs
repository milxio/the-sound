using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound
{
    static class Tiles
    {
        public static Tile Wall = new Tile (Sprites.Wall, false);

        public static Tile Floor = new Tile (Sprites.Floor, true);

        public static Tile Exit = new Tile (Sprites.Exit, true);
    }
}
