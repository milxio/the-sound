using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Entities;
using The_Sound.World;

namespace The_Sound.Core
{
    class GameState
    {
        public GameState()
        {
            Map = new Map();
        }

        public Player Player { get; set; }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public Map Map { get; set; }
        public bool IsRunning { get; set; }
    }
}
