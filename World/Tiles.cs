using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Graphics;

namespace The_Sound.World
{
    static class Tiles
    {
        public static Tile Wall = new Tile(Sprites.Wall, false);

        public static Tile Floor = new Tile(Sprites.Floor, true);

        public static Tile Exit = new Tile(Sprites.Exit, true);
    }
}
