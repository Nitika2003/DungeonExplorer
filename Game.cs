using System;
using System.Linq;

namespace DungeonExplorer
{
    internal class Game
    {
        private Player player;
        private Room currentRoom;
        private GameMap map;
        private bool isPlaying;

        public Game()
        {
            Console.WriteLine("Welcome to Dungeon Explorer!");
            Console.Write("Enter your player name: ");
            string playerName = Console.ReadLine();
            player = new Player(playerName, 100);
            map = new GameMap();
            currentRoom = map.GetRoom("Entrance");
            isPlaying = true;
        }

        public void Start()
        {
            while (isPlaying)
            {
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died.");
                    isPlaying = false;
                    break;
                }

                Console.WriteLine($"\nCurrent Room: {currentRoom.Name}");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. View Room Description");
                Console.WriteLine("2. Check Player Status");
                Console.WriteLine("3. Pick up an Item");
                Console.WriteLine("4. Use an Item");
                Console.WriteLine("5. Move to Another Room");
                Console.WriteLine("6. Attack Monster");
                Console.WriteLine("7. Exit Game");

                string userChoice = Console.ReadLine();

                try
                {
                    switch (userChoice)
                    {
                        case "1":
                            Console.WriteLine("Room Description: " + currentRoom.GetDescription());
                            DisplayRoomContents();
                            break;
                        case "2":
                            Console.WriteLine($"Player Name: {player.Name}");
                            Console.WriteLine($"Health: {player.Health}");
                            Console.WriteLine($"Inventory: {player.InventoryContents()}");
                            break;
                        case "3":
                            PickUpItem();
                            break;
                        case "4":
                            UseItem();
                            break;
                        case "5":
                            MoveToRoom();
                            break;
                        case "6":
                            AttackMonster();
                            break;
                        case "7":
                            Console.WriteLine("Exiting the game. Goodbye!");
                            isPlaying = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void DisplayRoomContents()
        {
            var items = currentRoom.GetItems();
            var monsters = currentRoom.GetMonsters();
            Console.WriteLine("Items in room: " + (items.Count > 0 ? string.Join(", ", items.Select(i => i.GetName())) : "None"));
            Console.WriteLine("Monsters in room: " + (monsters.Count > 0 ? string.Join(", ", monsters.Select(m => m.Name)) : "None"));
        }

        private void PickUpItem()
        {
            var items = currentRoom.GetItems();
            if (items.Count == 0)
            {
                Console.WriteLine("No items to pick up in this room.");
                return;
            }

            Console.WriteLine("Items available: " + string.Join(", ", items.Select(i => i.GetName())));
            Console.Write("Enter the name of the item to pick up: ");
            string itemName = Console.ReadLine();
            var item = items.Find(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null && player.PickUpItem(item))
            {
                currentRoom.RemoveItem(item);
            }
            else
            {
                Console.WriteLine("Item not found or inventory full!");
            }
        }

        private void UseItem()
        {
            Console.Write("Enter the name of the item to use: ");
            string itemName = Console.ReadLine();
            player.UseItem(itemName);
        }

        private void MoveToRoom()
        {
            var exits = map.GetExits(currentRoom.Name);
            if (exits.Count == 0)
            {
                Console.WriteLine("No exits available from this room.");
                return;
            }

            Console.WriteLine("Available directions: " + string.Join(", ", exits.Keys));
            Console.Write("Enter direction to move (e.g., north): ");
            string direction = Console.ReadLine().ToLower();
            string nextRoomName = map.GetConnectedRoom(currentRoom.Name, direction);
            if (nextRoomName != null)
            {
                currentRoom = map.GetRoom(nextRoomName);
                Console.WriteLine($"Moved to {currentRoom.Name}.");
            }
            else
            {
                Console.WriteLine("Cannot move in that direction!");
            }
        }

        private void AttackMonster()
        {
            var monsters = currentRoom.GetMonsters();
            if (monsters.Count == 0)
            {
                Console.WriteLine("No monsters to attack in this room.");
                return;
            }

            // Using LINQ to get the strongest monster
            var target = currentRoom.GetStrongestMonster();
            Console.WriteLine($"Attacking the strongest monster: {target.Name}");
            player.Attack(target);
            if (target.Health > 0)
            {
                target.Attack(player);
            }
            else
            {
                Console.WriteLine($"{target.Name} has been defeated!");
                currentRoom.RemoveMonster(target);
            }
        }
    }
}