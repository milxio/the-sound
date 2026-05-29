using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Core.Events;
using The_Sound.Entities;
using The_Sound.World;

namespace The_Sound.Core
{
    public class GameState
    {
        public GameState()
        {
            Map = new Map();
        }
        public Map Map { get; set; }

        public Player Player { get; set; }
        public bool IsRunning { get; set; }

        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public List<SoundEvent> Sounds { get; set; } = new List<SoundEvent>();

        public IEnumerable<MovingEntity> GetMovingEntities()
        {
            yield return Player;

            foreach (var enemy in Enemies)
            {
                yield return enemy;
            }
        }


    }
}
