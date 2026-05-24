using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Core;

namespace The_Sound.Systems
{
    class CollisionSystem
    {
        public void HandleCollisions(GameState state, MessageBus messageBus, Position lastPlayerPosition, List<Position> lastEnemiesPositions)
        {
            for (int i = 0; i < lastEnemiesPositions.Count; i++)
            {
                var enemy = state.Enemies[i];
                var lastEnemyPos = lastEnemiesPositions[i];

                bool sameCell = state.Player.NextPosition == enemy.NextPosition;

                bool swapped =
                    lastPlayerPosition == enemy.NextPosition &&
                    lastEnemyPos == state.Player.NextPosition;

                if (sameCell || swapped)
                {
                    state.Player.TakeDamage(enemy.Damage);
                    messageBus.Add("Stalker hits you");
                }
            }
        }
    }
}
