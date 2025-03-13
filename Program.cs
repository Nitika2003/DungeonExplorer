using System;

namespace DungeonExplorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game dungeon_game = new Game();
            dungeon_game.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}