using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Core;
using The_Sound.Graphics;

namespace The_Sound.Entities
{
    class Stalker : Enemy
    {
        public Stalker()
        {
            Sprite = Sprites.Stalker;
            Damage = 1;
            Speed = 1;
        }

        public override Direction UpdateDirection(GameState state)
        {
            return (Direction)Random.Shared.Next(4);
        }
    }
}
