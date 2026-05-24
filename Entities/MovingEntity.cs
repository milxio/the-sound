using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;

namespace The_Sound.Entities
{
    abstract class MovingEntity : Entity
    {
        public Direction Direction { get; set; }
    }
}
