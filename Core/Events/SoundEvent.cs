using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;

namespace The_Sound.Core.Events
{
    public class SoundEvent
    {
        public Position Position { get; set; }
        public int Loudness { get; set; }
    }
}
