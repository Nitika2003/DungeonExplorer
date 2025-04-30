using System;

namespace DungeonExplorer
{
    public class Goblin : Monster
    {
        public Goblin() : base("Goblin", 50, 10) { }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} swings a rusty dagger!");
            target.TakeDamage(AttackPower);
        }
    }
}