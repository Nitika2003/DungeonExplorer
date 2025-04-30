using System;

namespace DungeonExplorer
{
    public class Potion : Item
    {
        private int HealAmount { get; set; }

        public Potion(string name, int healAmount) : base(name)
        {
            HealAmount = healAmount;
        }

        public override void Use(Creature user)
        {
            user.ModifyHealth(HealAmount);
            Console.WriteLine($"{user.Name} drinks {Name} and heals for {HealAmount}! Health: {user.Health}");
        }
    }
}