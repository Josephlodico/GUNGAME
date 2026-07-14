using System;
using System.Diagnostics;

namespace GunGame.Rooms
{
    public class BlackRoom : Room
    {
        public override void Play(GameContext context)
        {
            string[] codes = { "241-124-7645-653" };
            var stopwatch = new Stopwatch();

            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("You entered the black room.");

            for (int i = 0; i < codes.Length; i++)
            {
                stopwatch.Start();
                Console.WriteLine("You only have 15 seconds to type this code in or you lose!");
                Console.WriteLine(codes[i]);
                Console.WriteLine("===============================================");
                string codeInput = Console.ReadLine();
                stopwatch.Stop();

                // Check if the player entered the correct code and did so within the time limit
                if (codeInput == codes[i] && stopwatch.Elapsed.TotalSeconds <= 15)
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("Code entered successfully within the time limit! ");
                    Console.WriteLine("YOU HAVE COMPLETED   THE BLACK ROOM!");
                    Console.WriteLine("===============================================");
                }
                else
                {
                    Console.WriteLine("Sorry, you either entered the wrong code or took too long. You failed to complete the black room.");
                    break;
                }

                stopwatch.Reset();
            }

            if (context.CompletedRooms != null && !context.CompletedRooms.Contains("black"))
            {
                context.CompletedRooms.Add("black"); // Add completed room to the list
            }
        }
    }
}
