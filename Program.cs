using System.Timers;

namespace The_Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();
        }
    }
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
            State.Player.Position = new Position
                (
                    State.Map.PlayerStartPosition.X,
                    State.Map.PlayerStartPosition.Y
                );
            State.Enemies.Add(new Stalker { Position = new Position(5, 5) });

            State.IsRunning = true;
        }

        public GameState State { get; set; }
        public string Message { get; set; }
        public MessageBus MessageBus { get; set; }
        public MovementSystem MovementSystem { get; set; }
        public CollisionSystem CollisionSystem { get; set; }
        public RenderSystem RenderSystem { get; set; }


        public void Run()
        {
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

            if (State.Player.NextPosition == State.Map.Exit)
            {
                Console.Clear();
                MessageBus.Add("YOU WIN!!!");
                State.IsRunning = false;

            }

            State.Player.Position = State.Player.NextPosition;
            foreach (var enemy in State.Enemies)
            {
                enemy.Position = enemy.NextPosition;
            }
        }
    }

    class Player : Entity
    {
        public Player()
        {
            Sprite = new Sprite('P', ConsoleColor.Blue);
        }
        public int Lives { get; set; } = 3;
        public Direction Direction { get; set; }
        public void TakeDamage(int damage)
        {
            Lives -= damage;
        }
    }

    class Stalker : Enemy
    {
        public Stalker()
        {
            Sprite = new Sprite('Z', ConsoleColor.Red);
            Damage = 1;
            Speed = 1;
        }

        public override Direction UpdateDirection(GameState state)
        {
            return (Direction)Random.Shared.Next(4);
        }
    }

    class Map
    {
        public Map()
        {
            string[] layout =
            {
                "#############################",
                "#P     #          #         #",
                "#      #                    #",
                "#   ###  ###  #  ###  ###   #",
                "#   ###  #   ###   #  ###   #",
                "#        ###  #  ###        #",
                "#        #  #####   #       #",
                "#   ###  #   ###   #  ###   #",
                "#                           #",
                "#   ###  ###  #  ###  ###   #",
                "#                           #",
                "#   ###  #  ###   #  ###    #",
                "#     ###           ###     E",
                "#############################"
                };

            int height = layout.Length;
            int width = layout[0].Length;

            Field = new char[height, width];


            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    char symbol = layout[y][x];

                    if (symbol == 'P')
                    {
                        PlayerStartPosition = new Position(x, y);
                        Field[y, x] = ' ';
                    }

                    else if (symbol == 'E')
                    {
                        Exit = new Position(x, y);
                        Field[y, x] = 'E';
                    }

                    else
                    {
                        Field[y, x] = symbol;
                    }
                }
            }
        }

        public char[,] Field { get; set; }
        public Position PlayerStartPosition { get; set; }
        public Position Exit { get; set; }
        public int Height => Field.GetLength(0);
        public int Width => Field.GetLength(1);

        public char GetCell(Position pos)
        {
            return Field[pos.Y, pos.X];
        }

        public void SetCell(Position pos, char value)
        {
            Field[pos.Y, pos.X] = value;
        }

        public bool IsInside(Position pos)
        {
            return (pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height);
        }
    }

    enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    struct Position
    {
        public int X;
        public int Y;

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Position other)
            {
                return (other.X == X && other.Y == Y);
            }
            return false;
        }

        public static bool operator ==(Position left, Position right)
        {
            return left.X == right.X && left.Y == right.Y;
        }

        public static bool operator !=(Position left, Position right)
        {
            return !(left == right);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
    }

    class MessageBus
    {
        private List<string> messages = new List<string>();

        public void Add(string message)
        {
            messages.Add(message);
        }
        public List<string> GetAll()
        {
            return new List<String>(messages);
        }
        public void Clear()
        { messages.Clear(); }
    }

    class GameState
    {
        public GameState()
        {
            Map = new Map();
        }
        public Player Player { get; set; }
        public List<Enemy> Enemies { get; set; } = new List<Enemy>();
        public Map Map { get; set; }
        public bool IsRunning { get; set; }
    }

    class MovementSystem
    {
        public void Update(GameState state)
        {
            MovePlayer(state);
            MoveEnemies(state);
        }
        public void MovePlayer(GameState state)
        {
            state.Player.NextPosition = CalculateNewPosition(
                    state.Player.Position,
                    state.Player.Direction,
                    state.Map);
        }
        public void MoveEnemies(GameState state)
        {
            foreach (var enemy in state.Enemies)
            {
                enemy.Direction = enemy.UpdateDirection(state);
                enemy.NextPosition = CalculateNewPosition(enemy.Position, enemy.Direction, state.Map);
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

            if (map.IsInside(newPos) && map.GetCell(newPos) != '#')
            {
                return newPos;
            }

            return current;
        }
    }
    abstract class Enemy : Entity
    {
        public Direction Direction { get; set; }
        public int Speed { get; set; }
        public int Damage { get; set; }
        abstract public Direction UpdateDirection(GameState state);
    }

    abstract class Entity
    {
        public Position Position { get; set; }
        public Position NextPosition { get; set; }
        public Sprite Sprite { get; set; }
    }

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
                    messageBus.Add("Zombie hits you");

                    if (state.Player.Lives <= 0)
                    {
                        state.IsRunning = false;
                        messageBus.Add("YOU DIED");
                    }
                }
            }
        }
    }

    class RenderSystem
    {
        public void DrawSprite(Sprite sprite)
        {
            Console.ForegroundColor = sprite.Color;
            Console.Write(sprite.Symbol);
            Console.ResetColor();
        }
        public void Render(GameState state, MessageBus messageBus)
        {
            Console.Clear();

            for (int y = 0; y < state.Map.Height; y++)
            {
                for (int x = 0; x < state.Map.Width; x++)
                {

                    if (x == state.Player.Position.X && y == state.Player.Position.Y)
                    {
                        DrawSprite(state.Player.Sprite);
                    }
                    else
                    {
                        bool isEnemyHere = false;
                        foreach (var enemy in state.Enemies)
                        {
                            if (enemy.Position.X == x && enemy.Position.Y == y)
                            {
                                DrawSprite(enemy.Sprite);
                                isEnemyHere = true;
                                break;
                            }
                        }
                        if (!isEnemyHere)
                        {
                            Console.Write(state.Map.GetCell(new Position(x, y)));
                        }
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Lives: {state.Player.Lives}");
            foreach (var msg in messageBus.GetAll())
            {
                Console.WriteLine(msg);
            }
            messageBus.Clear();
        }
    }
}
