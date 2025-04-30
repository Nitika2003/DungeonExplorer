using System;
using System.Collections.Generic;

namespace DungeonExplorer
{
    public class GameMap
    {
        private Dictionary<string, Room> rooms = new Dictionary<string, Room>();
        private Dictionary<string, Dictionary<string, string>> connections = new Dictionary<string, Dictionary<string, string>>();

        public GameMap()
        {
            // Initialize some rooms
            AddRoom("Entrance", "A dark, damp room with a faint smell of moss.");
            AddRoom("Hallway", "A long, narrow hallway with flickering torches.");
            AddRoom("Treasure Room", "A glittering room filled with gold and jewels.");
            AddRoom("Dragon Lair", "A scorching hot cave with bones scattered around.");

            // Define connections (navigation paths)
            ConnectRooms("Entrance", "north", "Hallway");
            ConnectRooms("Hallway", "south", "Entrance");
            ConnectRooms("Hallway", "east", "Treasure Room");
            ConnectRooms("Treasure Room", "west", "Hallway");
            ConnectRooms("Hallway", "north", "Dragon Lair");
            ConnectRooms("Dragon Lair", "south", "Hallway");

            // Add items and monsters to rooms
            rooms["Entrance"].AddItem(new Weapon("Rusty Sword", 10));
            rooms["Treasure Room"].AddItem(new Potion("Health Potion", 30));
            rooms["Dragon Lair"].AddMonster(new Dragon());
            rooms["Hallway"].AddMonster(new Goblin());
        }

        public void AddRoom(string name, string description)
        {
            rooms[name] = new Room(name, description);
        }

        public void ConnectRooms(string room1, string direction, string room2)
        {
            if (!connections.ContainsKey(room1))
                connections[room1] = new Dictionary<string, string>();
            connections[room1][direction] = room2;
        }

        public Room GetRoom(string name)
        {
            return rooms.ContainsKey(name) ? rooms[name] : null;
        }

        public string GetConnectedRoom(string currentRoom, string direction)
        {
            if (connections.ContainsKey(currentRoom) && connections[currentRoom].ContainsKey(direction))
                return connections[currentRoom][direction];
            return null;
        }

        public Dictionary<string, string> GetExits(string roomName)
        {
            return connections.ContainsKey(roomName) ? connections[roomName] : new Dictionary<string, string>();
        }
    }
}
