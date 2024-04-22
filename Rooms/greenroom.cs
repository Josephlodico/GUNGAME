using System;

namespace NarrativeProject.Rooms
{
    internal class greenroom : Room
    {

        internal override string CreateDescription() =>
@" ";

        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    break;
                case "2":
                    Console.WriteLine("");
                    break;
                case "3":
                    Console.WriteLine("");
                    Game.Transition<blackroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
