using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.World;

namespace The_Sound.Entities
{
    public class EnemyFactory
    {
        public Enemy CreateEnemy(EnemySpawnData data)
        {
            switch (data.Symbol)
            {
                case 'S':
                    return new Stalker
                    {
                        Position = data.Position
                    };
                default:
                    throw new Exception("Unknown enemy type");
            }
        }
    }
}
