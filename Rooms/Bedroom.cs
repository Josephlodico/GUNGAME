using System;


namespace NarrativeProject.Rooms
{
    internal class Bedroom : Room 
    { 
       
       
        internal override string CreateDescription() =>
@"You are in your bedroom.
The [door] in front of you leads to your living room.
Your private [bathroom] is to your left.
From your closet, you see the [attic].
";
        // A class that derives an abstract class
        // Must override every  abstract members
        // in order to be non-abstract
        internal override void ReceiveChoice(string choice)
        {
            switch (choice)
            {
                case "bathroom":
                    Console.WriteLine("You enter the bathroom.");
                    Game.Transition<Bathroom>();
                    break;
                case "door":
                    if (!AtticRoom.isKeyCollected)
                    {
                        Console.WriteLine("The door is locked.");
                    }
                    else
                    {
                        
                        Console.WriteLine("You open the door with the key and leave your bedroom.");
                        Game.Finish();
                    }
                    break;
                case "attic":
                    Console.WriteLine("You go up and enter your attic.");
                    Game.Transition<AtticRoom>();
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