using System;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room current_room;
        private bool is_playing;
        public Game()
        {
            // Initialize the game with one room and one player
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.Write("Enter your player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100);

            current_room = new Room("A dark, damp room with a faint smell of moss.");
            is_playing = true;
        }

        public void Start()
        {
            while (is_playing)
            {
                Console.WriteLine("\nWhat would you like to do?");
                Console.WriteLine("1. View Room Description");
                Console.WriteLine("2. Check Player Status");
                Console.WriteLine("3. Pick up an item");
                Console.WriteLine("4. Exit Game");

                string user_choice = Console.ReadLine();

                switch (user_choice)
                {
                    case "1":
                        Console.WriteLine("Room Description: " + current_room.GetDescription());
                        break;
                    case "2":
                        Console.WriteLine($"Player Name: {player.Name}");
                        Console.WriteLine($"Health: {player.Health}");
                        Console.WriteLine($"Inventory: {player.InventoryContents()}");
                        break;
                    case "3":
                        Console.Write("Enter the name of the item to pick up: ");
                        string item_name = Console.ReadLine();
                        player.PickUpItem(item_name);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the game. Goodbye!");
                        is_playing = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}