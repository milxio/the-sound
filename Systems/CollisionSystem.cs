using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Core;
using The_Sound.Entities;

namespace The_Sound.Systems
{
    class CollisionSystem
    {
        public void HandleCollisions(GameState state, MessageBus messageBus)
        {
            foreach (var enemy in state.Enemies)
            {
                bool sameCell = state.Player.NextPosition == enemy.NextPosition;

                bool swapped =
                    state.Player.PreviousPosition == enemy.NextPosition &&
                    enemy.PreviousPosition == state.Player.NextPosition;

                if (sameCell || swapped)
                {
                    state.Player.TakeDamage(enemy.Damage);
                    messageBus.Add("Stalker hits you");
                }

            }
        }
    }
}
