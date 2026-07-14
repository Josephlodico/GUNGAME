using System;
using System.Collections.Generic;

namespace GunGame
{
    public class GameContext
    {
        public GameContext(Player player, Random random, List<string> completedRooms)
        {
            Player = player;
            Random = random;
            CompletedRooms = completedRooms;
        }

        public Player Player { get; }
        public Random Random { get; }
        public List<string> CompletedRooms { get; }
    }
}
