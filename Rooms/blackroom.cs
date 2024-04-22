using System;
using System.Diagnostics;


namespace NarrativeProject.Rooms
{
    internal class blackroom : Room 
    {

        
        internal override string CreateDescription() =>

@" You entered the black door.You only have 15 seconds to type this code in or you lose! 
241-124-7645-653";
        
        internal override void ReceiveTask(string choice)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string codeInput = Console.ReadLine(); // Prompt the player for input
            stopwatch.Stop();
            // Check if the player entered the correct code and did so within the time limit
            if (codeInput == "241-124-7645-653" && stopwatch.Elapsed.TotalSeconds <= 15)
            {
                Console.WriteLine("Code entered successfully within the time limit!");
                 // Add completed room to the list
            }
            else
            {
                Console.WriteLine("Sorry, you either entered the wrong code or took too long. You failed to complete the black room.");
            }

            stopwatch.Reset();
        }
    }
}
