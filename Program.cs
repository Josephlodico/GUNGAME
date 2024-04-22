using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;

namespace NarrativeProject
{
    //[Serializable]
    //public class SaveData
    //{
    //    public int numberToSave;
    //    public string stringToSave;

    //    public SaveData(int numberToSave, string stringToSave)
    //    {
    //        this.numberToSave = numberToSave;
    //        this.stringToSave = stringToSave;
    //    }
        // project name GUNGAME
        internal class program
        {
            //static SaveData saveData;
            public class Goblin
            {
                public int enemyHP = 50;
            }
            public class Monster
            {
                public int enemyHP = 50;
            }
            static void Main(string[] args)
            {
                //const string SaveFile = "Save.txt";
                //if (!File.Exists(SaveFile))
                //{
                //    File.CreateText(SaveFile);
                //}
                //var bf = new BinaryFormatter();

                ////saveData = new SaveData( 200,"player");
                ////bf.Serialize(File.OpenWrite(SaveFile),saveData);

                //saveData = bf.Deserialize(File.OpenRead(SaveFile)) as SaveData;

                //Console.WriteLine($"{saveData.stringToSave} has{saveData.numberToSave}G");
                int action;
                int bullets = 150;
                int playerHP = 100;
                int shadowplayer = playerHP;
                Stopwatch stopwatch = new Stopwatch();


                int[] RandomDamage = { 28, 32, 12, 44, 50, 24 }; // This is for the Gun damage
                Random random = new Random();

                int[] EnemyDamage = { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

                Console.WriteLine("Welcome to Gun Game! Press Enter to start");
                Console.ReadLine();
                Console.Clear();

                while (true)
                {
                    Console.WriteLine("You wake up in a room confused. In front of you there's a gun, do you pick it up?");
                    Console.WriteLine("1- Yes");
                    Console.WriteLine("2- No");

                    action = Convert.ToInt32(Console.ReadLine());

                    if (action == 1)
                    {
                        Console.WriteLine("You picked up the gun.");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("You picked up the gun.");
                        break;
                    }

                    if (action == 2)
                    {
                        Console.WriteLine("You should really pick it up...");
                        Console.Clear();
                    }
                }

                Console.Clear();
                Console.WriteLine("You notice how many bullets you have in total");
                Console.WriteLine("You have " + bullets + " bullets");
                Console.WriteLine("You have " + playerHP + " hit points available");

                Thread.Sleep(1000);
                Console.Clear();

                List<string> completedRooms = new List<string>();
                string room;




                while (completedRooms.Count < 5) // Ensure loop runs until 5 rooms are completed
                {
                    Console.WriteLine("You see 6 doors in front of you, though one is locked. Once you complete a task in 5 rooms, " +
                        "the last door will open, enter the red room first to start");

                    var game = new Game();

                    game.Add(new redroom());
                    game.Add(new blackroom());
                    game.Add(new greenroom());
                    game.Add(new pinkroom());
                    game.Add(new blueroom());

                    Console.WriteLine("1- [red door]");
                    Console.WriteLine("2- [black door]");
                    Console.WriteLine("3- [green door]");
                    Console.WriteLine("4- [pink door]");
                    Console.WriteLine("5- [blue door]");
                    Console.WriteLine("6- [Locked door]");

                    Console.WriteLine("Which door would you like to go in?");
                    room = Console.ReadLine().ToLower();

                    if (completedRooms.Contains(room))
                    {
                        Console.WriteLine("You have already completed this room. Choose another one.");
                        continue;
                    }


                    if (room == "red")
                    {
                        // enter redroom
                    }
                    else if (room == "black")
                    {
                        // enter blackroom
                    }
                    else if (room == "green")
                    {
                        // enter greenroom
                    }
                    else if (room == "pink")
                    {
                        // enter pinkroom
                    }
                    else if (room == "blue")
                    {
                        // enter blueroom
                    }
                    else
                    {
                        Console.WriteLine("invalid input. please try again.");
                    }



                }




            }

        }
    }

        
        
               
            
        
    


    
