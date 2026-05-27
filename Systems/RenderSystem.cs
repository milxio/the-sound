
using The_Sound.Common;
using The_Sound.Core;
using The_Sound.Entities;
using The_Sound.Graphics;
using The_Sound.World;

namespace The_Sound.Systems
{
    class RenderSystem
    {
        int TileWidth = 2;
        int TileHeight = 2;

        public Position GetScreenPosition(Position worldPosition)
        {
            return new Position
            {
                X = worldPosition.X * TileWidth,
                Y = worldPosition.Y * TileHeight,
            };
        }
        public void DrawSprite(Sprite sprite, Position position)
        {
            Console.ForegroundColor = sprite.Color;
            Position screenPosition = GetScreenPosition(position);

            for (int i = 0; i < sprite.Height; i++)
            {
                Console.SetCursorPosition(screenPosition.X, screenPosition.Y + i);
                Console.Write(sprite.Lines[i]);
            }
            Console.ResetColor();
        }

        public void EraseEntity (Position oldPosition, Map map)
        {
            Tile tile = map.GetTile(oldPosition);
            DrawSprite(tile.Sprite, oldPosition);
            
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
            
            RenderPlayer(state.Player);
            RenderEnemies(state.Enemies);

            Console.SetCursorPosition(0, state.Map.Height * TileHeight + 1);
            Console.Write($"Lives: {state.Player.Lives}  ");

            int uiY = state.Map.Height * TileHeight+2;

            foreach (var msg in messageBus.GetAll())
            {
                Console.SetCursorPosition(0, uiY);
                Console.Write(msg+"         ");
                uiY++;
            }

            messageBus.Clear();
       }
    }
}
