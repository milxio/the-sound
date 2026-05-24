using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Core;
using The_Sound.Entities;
using The_Sound.Graphics;
using The_Sound.World;

namespace The_Sound.Systems
{
    class RenderSystem
    {
        public void DrawSprite(Sprite sprite, Position position)
        {
            Console.ForegroundColor = sprite.Color;

            for (int i = 0; i < sprite.Height; i++)
            {
                Console.SetCursorPosition(position.X, position.Y + i);
                Console.Write(sprite.Lines[i]);
            }
            Console.ResetColor();
        }

        public void RenderMap(Map map)
        {
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    Tile tile = map.GetTile(new Position(x, y));
                    DrawSprite(tile.Sprite, new Position(x,y));
                }
            }
        }

       public void RenderPlayer(Player player)
       {
            DrawSprite(player.Sprite, player.Position);
       }

        public void RenderEnemies(List<Enemy> enemies)
        {
            foreach (Enemy enemy in enemies)
            {
                DrawSprite(enemy.Sprite, enemy.Position);
            }
        }

        public void Render(GameState state, MessageBus messageBus)
        {
            Console.SetCursorPosition(0, 0);

            RenderMap(state.Map);
            RenderPlayer(state.Player);
            RenderEnemies(state.Enemies);

            Console.SetCursorPosition(0, state.Map.Height + 1);
            Console.WriteLine($"Lives: {state.Player.Lives}");

            foreach (var msg in messageBus.GetAll())
            {
                Console.WriteLine(msg);
            }

            messageBus.Clear();
        }
    }
}
