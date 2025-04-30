using System.Collections.Generic;
using System.Linq;

namespace DungeonExplorer
{
    public class Room
    {
        private string name;
        private string room_description;
        private List<Item> items = new List<Item>();
        private List<Monster> monsters = new List<Monster>();

        public Room(string name, string description)
        {
            this.name = name;
            room_description = description;
        }

        public string Name => name;

        public string GetDescription()
        {
            return room_description;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public List<Item> GetItems()
        {
            return items;
        }

        public void AddMonster(Monster monster)
        {
            monsters.Add(monster);
        }

        public void RemoveMonster(Monster monster)
        {
            monsters.Remove(monster);
        }

        public List<Monster> GetMonsters()
        {
            return monsters;
        }

        // LINQ to find strongest monster
        public Monster GetStrongestMonster()
        {
            return monsters.OrderByDescending(m => m.Health).FirstOrDefault();
        }
    }
}