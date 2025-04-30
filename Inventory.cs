using System;
using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();
        private int MaxCapacity { get; set; }

        public Inventory(int capacity)
        {
            MaxCapacity = capacity;
        }

        public bool AddItem(Item item)
        {
            if (items.Count < MaxCapacity)
            {
                items.Add(item);
                Console.WriteLine($"Added {item.GetName()} to inventory.");
                return true;
            }
            Console.WriteLine("Inventory full! Cannot add item.");
            return false;
        }

        public void RemoveItem(string itemName)
        {
            var item = items.FirstOrDefault(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase));
            if (item != null)
            {
                items.Remove(item);
                Console.WriteLine($"Removed {itemName} from inventory.");
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory.");
            }
        }

        public Item GetItem(string itemName)
        {
            return items.FirstOrDefault(i => i.GetName().Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        // LINQ to filter weapons
        public List<Weapon> GetWeapons()
        {
            return items.OfType<Weapon>().ToList();
        }

        public string DisplayContents()
        {
            if (items.Count == 0) return "Inventory is empty.";
            return string.Join(", ", items.Select(i => i.GetName()));
        }
    }
}
