using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Core;

namespace The_Sound.Systems
{
    class GameRulesSystem
    {
        public void Check(GameState state, MessageBus messageBus)
        {
            if (state.Player.NextPosition == state.Map.Exit)
            {
                Console.SetCursorPosition(0, 0);
                messageBus.Add("YOU WIN!!!");
                state.IsRunning = false;

            }

            if (state.Player.Lives <= 0)
            {
                Console.SetCursorPosition(0, 0);
                messageBus.Add("YOU DIED");
                state.IsRunning = false;
            }
        }
    }
}
