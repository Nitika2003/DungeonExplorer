using System;

namespace DungeonExplorer
{
    public class Player : Creature, IDamageable
    {
        private Inventory inventory;

        public Player(string name, int health) : base(name, health)
        {
            inventory = new Inventory(5); // Max 5 items
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} took {damage} damage! Health remaining: {Health}");
        }

        public override void Attack(Creature target)
        {
            int damage = 5; // Default unarmed damage
            var weapons = inventory.GetWeapons();
            if (weapons.Count > 0)
            {
                var weapon = weapons[0]; // Use first weapon
                damage = weapon.GetDamage();
                Console.WriteLine($"{Name} attacks with {weapon.GetName()}!");
            }
            else
            {
                Console.WriteLine($"{Name} punches with bare hands!");
            }
            target.TakeDamage(damage);
        }

        public bool PickUpItem(Item item)
        {
            return inventory.AddItem(item);
        }

        public void UseItem(string itemName)
        {
            var item = inventory.GetItem(itemName);
            if (item != null)
            {
                item.Use(this);
                if (!(item is Weapon)) // Remove potions after use, keep weapons
                    inventory.RemoveItem(itemName);
            }
            else
            {
                Console.WriteLine($"Item {itemName} not found in inventory!");
            }
        }

        public string InventoryContents()
        {
            return inventory.DisplayContents();
        }
    }
}