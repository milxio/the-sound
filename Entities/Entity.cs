using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Graphics;

namespace The_Sound.Entities
{
    abstract class Entity
    {
        public Position Position { get; set; }
        public Position NextPosition { get; set; }
        public Sprite Sprite { get; set; }
    }
}
