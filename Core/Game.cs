using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using The_Sound.Common;
using The_Sound.Entities;
using The_Sound.Systems;

namespace The_Sound.Core
{
    class Game
    {
        public Game()
        {
            State = new GameState();
            MovementSystem = new MovementSystem();
            MessageBus = new MessageBus();
            CollisionSystem = new CollisionSystem();
            RenderSystem = new RenderSystem();
            State.Player = new Player();
            GameRules = new GameRulesSystem();

            State.Player.Position = new Position
                (
                    State.Map.PlayerStartPosition.X,
                    State.Map.PlayerStartPosition.Y
                );

            State.Enemies.Add(new Stalker { Position = new Position(5, 5) });

            State.IsRunning = true;
        }

        public GameState State { get; set; }
        public MovementSystem MovementSystem { get; set; }
        public MessageBus MessageBus { get; set; }
        public string Message { get; set; }
        public CollisionSystem CollisionSystem { get; set; }
        public RenderSystem RenderSystem { get; set; }
        public GameRulesSystem GameRules { get; set; }

        public void Run()
        {
            RenderSystem.RenderMap(State.Map);
            while (State.IsRunning)
            {
                HandleInput();
                Update();
                RenderSystem.Render(State, MessageBus);
                Thread.Sleep(250);
            }
        }

        public void HandleInput()
        {
            if (!Console.KeyAvailable)
            {
                return;
            }

            var key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    State.Player.Direction = Direction.Up;
                    break;

                case ConsoleKey.S:
                    State.Player.Direction = Direction.Down;
                    break;

                case ConsoleKey.A:
                    State.Player.Direction = Direction.Left;
                    break;

                case ConsoleKey.D:
                    State.Player.Direction = Direction.Right;
                    break;
            }
        }
        public void Update()
        {
            var lastPlayerPosition = State.Player.Position;
            var lastEnemiesPositions = new List<Position>();

            foreach (var enemy in State.Enemies)
            {
                lastEnemiesPositions.Add(enemy.Position);
            }

            MovementSystem.Update(State);
            CollisionSystem.HandleCollisions(State, MessageBus, lastPlayerPosition, lastEnemiesPositions);
            GameRules.Check(State, MessageBus);

            RenderSystem.EraseEntity(lastPlayerPosition, State.Map);
            State.Player.Position = State.Player.NextPosition;

            foreach (var position in lastEnemiesPositions)
            {
                RenderSystem.EraseEntity(position, State.Map);
            }

            foreach (var enemy in State.Enemies)
            {
                enemy.Position = enemy.NextPosition;
            }
        }
    }
}
