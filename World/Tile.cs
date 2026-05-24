using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Sound
{
    public class Tile
    {
        public Sprite Sprite { get; }
        public bool IsWalkable { get; }

        public Tile(Sprite sprite, bool isWalkable)
        {
            Sprite = sprite;
            IsWalkable = isWalkable;
        }
    }
}
