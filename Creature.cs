using System;

namespace DungeonExplorer
{
    public abstract class Creature
    {
        public string Name { get; protected set; }
        public int Health { get; set; }
        public int MaxHealth { get; protected set; }

        protected Creature(string name, int health)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
        }

        public void ModifyHealth(int amount)
        {
            Health += amount;
            if (Health > MaxHealth) Health = MaxHealth;
            if (Health < 0) Health = 0;
        }

        public abstract void TakeDamage(int damage);
        public abstract void Attack(Creature target);
    }
}