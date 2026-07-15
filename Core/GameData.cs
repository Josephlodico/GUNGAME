using System.Collections.Generic;

namespace GunGame.Core
{
    public class GameData
    {
        public int playerHP { get; set; }
        public int bullets { get; set; }
        public bool medkitPickedUp { get; set; }
        public bool medkitUsed { get; set; }
        public List<string> completedRooms { get; set; } = new List<string>();
    }
}
