using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Core;

namespace The_Sound.Entities
{
    public abstract class Enemy : MovingEntity
    {
        public int Damage { get; set; }
        abstract public Direction UpdateDirection (GameState state);
    }
}
