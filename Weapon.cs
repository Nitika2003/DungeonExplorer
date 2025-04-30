using System;

namespace DungeonExplorer
{
    public class Weapon : Item
    {
        private int Damage { get; set; }

        public Weapon(string name, int damage) : base(name)
        {
            Damage = damage;
        }

        public override void Use(Creature user)
        {
            Console.WriteLine($"{user.Name} swings {Name} dealing {Damage} damage!");
            // Logic for attacking a monster can be added in game context
        }

        public int GetDamage()
        {
            return Damage;
        }
    }
}