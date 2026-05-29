using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Core;
using The_Sound.Entities;

namespace The_Sound.Systems
{
    public class ApplyMovementSystem
    {
        public void Apply(GameState state)
        {
            
            foreach (var entity in state.GetMovingEntities())
            {
                entity.PreviousPosition = entity.Position;
                entity.Position = entity.NextPosition;
            }
        }
    }
}
