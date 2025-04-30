namespace DungeonExplorer
{
    public abstract class Item : ICollectible
    {
        protected string Name { get; set; }

        protected Item(string name)
        {
            Name = name;
        }

        public string GetName()
        {
            return Name;
        }

        public abstract void Use(Creature user);
    }
}