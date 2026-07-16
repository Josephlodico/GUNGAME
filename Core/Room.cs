using System;
using System.IO;

namespace GunGame.Core
{
    public abstract class Room
    {
        public abstract void Play(GameContext context);

        public static int ReadInt(int min, int max)
        {
            while (true)
            {
                if (int.TryParse(ReadLineOrExit(), out int value) && value >= min && value <= max)
                {
                    return value;
                }

                Console.WriteLine($"Invalid input. Please enter a number between {min} and {max}.");
            }
        }

        // Console.ReadLine() returns null at EOF (closed/redirected stdin). Without this,
        // callers that loop until valid input spin forever re-reading null and flooding output.
        public static string ReadLineOrExit()
        {
            string line = Console.ReadLine();
            if (line == null)
            {
                Console.WriteLine("Input stream closed. Exiting.");
                Environment.Exit(0);
            }

            return line;
        }

        // Console.Clear() throws IOException when there is no real console buffer
        // (redirected output, piped input, some terminal emulators). Swallow that
        // instead of crashing, since there's nothing meaningful to clear anyway.
        public static void SafeClear()
        {
            try
            {
                Console.Clear();
            }
            catch (IOException)
            {
            }
        }
    }
}
