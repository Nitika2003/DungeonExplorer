using System;

namespace DungeonExplorer
{
    public abstract class Monster : Creature, IDamageable
    {
        protected int AttackPower { get; set; }

        protected Monster(string name, int health, int attackPower) : base(name, health)
        {
            AttackPower = attackPower;
        }

        public override void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} took {damage} damage! Health remaining: {Health}");
        }
    }
}