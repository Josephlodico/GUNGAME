using System;


namespace NarrativeProject.Rooms
{
    internal class blackroom : Room 
    { 
       
       
        internal override string CreateDescription() =>
@" ";
        // A class that derives an abstract class
        // Must override every  abstract members
        // in order to be non-abstract
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    Game.Transition<greenroom>();
                    break;
                case "2":
                    if (!redroom.isKeyCollected)
                    {
                        Console.WriteLine("");
                    }
                    else
                    {
                        
                        Console.WriteLine("");
                        Game.Finish();
                    }
                    break;
                case "3":
                    Console.WriteLine("");
                    Game.Transition<redroom>();
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
    }
}
//interface A { }
//interface B { }
//interface C { }

//namespace NarrativeProject.Rooms
//{
//    internal class Bedroom : Room //C, A, B
//    {
//        // Expression-bodied member =>
//        int hello()
//        {
//            return 5;
//        }
//        int Hello2() => 5;