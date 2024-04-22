using System;

namespace NarrativeProject.Rooms
{
    internal class redroom : Room
    {
            internal static bool isKeyCollected;

            internal override string CreateDescription() =>
        @" "; 

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    Game.Transition<blackroom>();
                    break;
                case "2":
                    Console.WriteLine("");
                    
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
