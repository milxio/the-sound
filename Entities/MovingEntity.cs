using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;

namespace The_Sound.Entities
{
   public abstract class MovingEntity : Entity
    {
        public Position PreviousPosition { get; set; }
        public Direction Direction { get; set; }
        public int Speed { get; set; } = 1;
    }
}
