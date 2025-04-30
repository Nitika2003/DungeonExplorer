using System;

namespace DungeonExplorer
{
    public class Dragon : Monster
    {
        public Dragon() : base("Dragon", 100, 25) { }

        public override void Attack(Creature target)
        {
            Console.WriteLine($"{Name} breathes fire!");
            target.TakeDamage(AttackPower);
        }
    }
}