namespace DungeonExplorer
{
    public interface ICollectible
    {
        string GetName();
        void Use(Creature user);
    }
}