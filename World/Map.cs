using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;

namespace The_Sound.World
{
    class Map
    {
        public Map()
        {
            string[] layout =
            {
                "#############################",
                "#P     #          #         #",
                "#      #                    #",
                "#   ###  ###  #  ###  ###   #",
                "#   ###  #   ###   #  ###   #",
                "#        ###  #  ###        #",
                "#        #  #####   #       #",
                "#   ###  #   ###   #  ###   #",
                "#                           #",
                "#   ###  ###  #  ###  ###   #",
                "#                           #",
                "#   ###  #  ###   #  ###    #",
                "#     ###           ###     E",
                "#############################"
                };

            int height = layout.Length;
            int width = layout[0].Length;

            Field = new Tile[height, width];



            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char symbol = layout[y][x];

                    if (symbol == 'P')
                    {
                        PlayerStartPosition = new Position(x, y);
                        Field[y, x] = Tiles.Floor;
                    }

                    else if (symbol == 'E')
                    {
                        Exit = new Position(x, y);
                        Field[y, x] = Tiles.Exit;
                    }

                    else if (symbol == '#')
                    {
                        Field[y, x] = Tiles.Wall;
                    }

                    else
                    {
                        Field[y, x] = Tiles.Floor;
                    }
                }
            }
        }

        public Tile[,] Field { get; set; }
        public Position PlayerStartPosition { get; set; }
        public Position Exit { get; set; }
        public int Height => Field.GetLength(0);
        public int Width => Field.GetLength(1);

        public Tile GetTile(Position pos)
        {
            return Field[pos.Y, pos.X];
        }

        public bool IsInside(Position pos)
        {
            return (pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height);
        }
    }
}
