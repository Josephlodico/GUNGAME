using NarrativeProject.Rooms;
using System;

namespace NarrativeProject
{
    
    // project name GUNGAME
        internal class program
        {
                static void Main(string[] args)
                {

                   //var goblin = new Goblin();
                   //goblin.Hp -= 200;
                   //Console.WriteLine(goblin.Hp);
                   //return;


                    var game = new Game();

                    game.Add(new blackroom());
                    game.Add(new greenroom());
                    game.Add(new redroom());
                    game.Add(new pinkroom());
                    game.Add(new blueroom());
            
                    
                    

                    while (!game.IsGameOver())
                    {
                        Console.WriteLine("--");
                        Console.WriteLine(game.CurrentRoomDescription);
                        string choice = Console.ReadLine().ToLower() ?? "";
                        Console.Clear();
                        game.ReceiveChoice(choice);
                    }

                    Console.WriteLine("END");
                    Console.ReadLine();
                    
                    
                } 
        }
}
    
//internal class Program
//{
//    internal class Goblin
//    {
//        //private field
//        //a field is a member variable that belongs to a class
//        private int hp;

//        public Goblin(int initialHp = 100)
//        {
//            hp = initialHp;
//        }

//        //public property
//        public int Hp
//        {
//            get => hp;
//            set
//            {
//                hp = value;
//                if (hp < 0)
//                {
//                    hp = 0;
//                }
//            }
//        }
//    }