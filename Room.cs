namespace DungeonExplorer
{
    public class Room
    {
        private string room_description;

        public Room(string description)
        {
            room_description = description;
        }

        public string GetDescription()
        {
            return room_description;
        }
    }
}