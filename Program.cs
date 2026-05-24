using System.Timers;
using The_Sound.Core;
using The_Sound.Entities;
using The_Sound.Graphics;
using The_Sound.World;

namespace The_Sound
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Game game = new Game();
            game.Run();
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
}
