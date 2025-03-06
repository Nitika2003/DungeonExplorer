using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class Player
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        private List<string> player_inventory = new List<string>();

        public Player(string name, int health)
        {
            Name = name;
            Health = health;
        }

        public void PickUpItem(string item)
        {
            if (player_inventory.Count == 0)
            {
                player_inventory.Add(item);
                Console.WriteLine($"You picked up: {item}");
            }
            else
            {
                Console.WriteLine("You can only carry one item at a time!");
            }
        }

        public string InventoryContents()
        {
            if (player_inventory.Count == 0)
            {
                return "Empty";
            }
            return string.Join(", ", player_inventory);
        }
    }
}