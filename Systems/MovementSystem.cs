using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Core;
using The_Sound.Entities;
using The_Sound.World;

namespace The_Sound.Systems
{
    class MovementSystem
    {
        public void Update(GameState state)
        {
            MovePlayer(state);
            MoveEnemies(state);
        }

        public void MoveEntity(MovingEntity entity, Map map)
        {
            entity.NextPosition = CalculateNewPosition(
                entity.Position,
                entity.Direction,
                map);
        }
        public void MovePlayer(GameState state)
        {
            MoveEntity(state.Player, state.Map);
        }

        public void MoveEnemies(GameState state)
        {
            foreach (var enemy in state.Enemies)
            {
                enemy.Direction = enemy.UpdateDirection(state);
                MoveEntity(enemy, state.Map);
            }
        }

        public Position CalculateNewPosition(Position current, Direction direction, Map map)
        {
            var newPos = new Position(current.X, current.Y);

            switch (direction)
            {
                case Direction.Up:
                    newPos.Y--;
                    break;

                case Direction.Down:
                    newPos.Y++;
                    break;

                case Direction.Left:
                    newPos.X--;
                    break;

                case Direction.Right:
                    newPos.X++;
                    break;
            }

            if (map.IsInside(newPos) && map.GetTile(newPos).IsWalkable)
            {
                return newPos;
            }

            return current;
        }
    }
}
