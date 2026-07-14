using System;

namespace GunGame.Core
{
    public abstract class Room
    {
        public abstract void Play(GameContext context);

        public static int ReadInt(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                {
                    return value;
                }

                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }
    }
}
