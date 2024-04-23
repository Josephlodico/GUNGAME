using NarrativeProject.Rooms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;
//project name GUNGAME
namespace NarrativeProject
{

    //FOR HANDING IN TMR, WERE GONNA GET SAVE SYSTEM + FOR/FOR EACH LOOPS ALL GOOD :) :) :)

    internal class Program
    {
        [Serializable]
        public class GameState
        {
            public int Bullets { get; set; }
            public int PlayerHP { get; set; }
            public List<string> CompletedRooms { get; set; }
        }

        public enum RoomType
            {
                Red,
                Black,
                Green,
                Pink,
                Blue,
                Locked,
                Gold,
            }

            public enum PlayerAction
            {
                Yes = 1,
                No = 2,
            }

            class Enemy
            {
                public int monster = 0;

                public void attack()
                {
                    Console.WriteLine("they are attacking me");

                }

            }


            class Goomba : Enemy
            {
                public int enemyHP = 80;
            }
            class ShadowPL : Enemy
        {
           public int enemyHP = 200;
        }
            class blob : Enemy
            {
                public int enemyHP = 70;
            }
            public class Goblin
            {
                public int enemyHP = 60;

            }

            public class Monster
            {

                public int enemyHP = 50;
            }
            public class Medkit
            {
                public int Health { get; set; }

                public Medkit()
                {
                    Health = 100;
                }

                public void UseMedkit(ref int playerHP)
                {
                    playerHP += Health;
                    Console.WriteLine($"You used a medkit and restored {Health} health points. Your current health is {playerHP}.");

                    Medkit medkit = new Medkit();
                    medkit.UseMedkit(ref playerHP);
                }
            }
            

            static void Main(string[] args)
            {
            
            var game = new Game();
                game.Add(new redroom());
                game.Add(new blackroom());
                game.Add(new greenroom());
                game.Add(new pinkroom());
                game.Add(new blueroom());



                int action;
                int bullets = 250;
                int playerHP = 200;
                
                //Medkit medkit = new Medkit();
                //List<string> inventory = new List<string>() { "medkit", "ammo" }; 
                Stopwatch stopwatch = new Stopwatch();
                List<string> completedRooms = new List<string>();
                string room;

            { 
            
            }


            
                int[] RandomDamage = { 21, 31, 22, 30, 19, 25, 71, 37, 27, 24, 55, 100, 22, 26, 100 }; // This is for the Gun damage
                Random random = new Random();

                int[] EnemyDamage = { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

                Console.WriteLine("Welcome to Gun Game! Press Enter to start");



            Console.WriteLine(" +--^----------,--------,-----,--------^-,\r\n | |||||||||   `--------'     |          O\r\n `+---------------------------^----------|\r\n   `\\_,---------,---------,--------------'\r\n     / XXXXXX /'|       /'\r\n    / XXXXXX /  `\\    /'\r\n   / XXXXXX /`-------'\r\n  / XXXXXX /\r\n / XXXXXX /\r\n(________(                \r\n `------'    ");
                Console.ReadLine();
                Console.Clear();

            while (true)
            {
                Console.WriteLine("You wake up in a room confused. In front of you there's a gun,Do you pick it up?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");

                action = Convert.ToInt32(Console.ReadLine());

                if (action == 1)
                {
                    Console.WriteLine("You picked up the gun.");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                    
                }
                else if (action == 2)
                {
                    Console.WriteLine("You should REALLY pick it up...");
                    Console.Clear();

                   

                }
            }

                Console.Clear();
                Console.WriteLine("You notice how many bullets you have in total");
                Console.WriteLine("You have " + bullets + " bullets");
                Console.WriteLine("You have " + playerHP + " hit points available");

                Thread.Sleep(3500);
                Console.Clear();


                while (completedRooms.Count < 6) // Change '>' to '<' to ensure loop runs until 5 rooms are completed
                {

                    Console.WriteLine("You see 6 doors in front of you, though the 6th door is Locked. ");
                    Console.WriteLine("Once you complete the TASK in ALL the 5 rooms, the Locked door will open. ");
                    Console.WriteLine("Now Type the room color to  START or write gold to access your inventory");

                    Console.WriteLine("1- [red door]");
                    Console.WriteLine("2- [black door]");
                    Console.WriteLine("3- [green door]");
                    Console.WriteLine("4- [pink door]");
                    Console.WriteLine("5- [blue door]");
                    Console.WriteLine("6- [Locked door]");
                    Console.WriteLine("7- [gold door(inventory)]");
                    Console.WriteLine("Save");



                Console.WriteLine("Which door would you like to go in?");
                  Console.WriteLine("===============================================");

                    room = Console.ReadLine().ToLower();

                    if (completedRooms.Contains(room))
                    {
                        Console.WriteLine("YOU HAVE ALREADY COMPLETED THIS ROOM. PLEASE CHOOSE ANOTHER ONE.");
                        continue;
                    }




                    switch (room.ToLower())
                    {
                        case "red":
                            Console.Clear();
                            Console.WriteLine("You entered the red door.");
                            Console.WriteLine("In front of you, you see a weird looking goblin!");


                            Goblin goblin = new Goblin();
                            blob blob = new blob();
                            Goomba goomba = new Goomba();

                            while (goblin.enemyHP > 0)
                            {
                                Console.WriteLine("Would you like to attack the goblin?");
                                Console.WriteLine("1- Yes");
                                Console.WriteLine("2- No");
                                action = Convert.ToInt32(Console.ReadLine());

                                if (action == 1)
                                {
                                    Console.Clear();
                                    int randomIndex = random.Next(RandomDamage.Length);
                                    int randomDamage = RandomDamage[randomIndex];
                                    Console.WriteLine("You shot at the goblin! You did " + randomDamage + " damage to the goblin.");
                                    bullets = bullets - 20;
                                    goblin.enemyHP -= randomDamage;
                                    Console.WriteLine("The enemy now has " + goblin.enemyHP + " hit points left!");
                                    Console.Clear();
                                }
                                else
                                {

                                    Console.Clear();
                                    Console.WriteLine(" Too bad!");
                                    Console.WriteLine("===============================================");
                                }
                                // Enemy's turn to attack
                                int enemyRandomIndex = random.Next(EnemyDamage.Length);
                                int enemyRandomDamage = EnemyDamage[enemyRandomIndex];
                                Console.WriteLine("The goblin attacks you and does " + enemyRandomDamage + " damage!");
                                playerHP = playerHP - enemyRandomDamage;
                            Console.WriteLine("the Goblin now has " + goblin.enemyHP  + " HP left ");
                            Console.WriteLine("===============================================");
                            Console.WriteLine("and NOW you have " + playerHP + " HP left ");
                                Console.WriteLine("and  " + bullets + " bullets left ");
                                if (goblin.enemyHP <= 0)
                                {
                                    Console.WriteLine("\n\n\tYou defeated the goblin!\n");
                                    Console.WriteLine("===============================================");
                                    Console.WriteLine("\nhere comes the Blob! NOW");
                                }
                            }
                            while (blob.enemyHP > 0)
                            {
                                Console.WriteLine("Would you like to attack the blob?");
                                Console.WriteLine("1- Yes");
                                Console.WriteLine("2- No");
                                action = Convert.ToInt32(Console.ReadLine());

                                if (action == 1)
                                {
                                    Console.Clear();
                                    int randomIndex = random.Next(RandomDamage.Length);
                                    int randomDamage = RandomDamage[randomIndex];
                                    Console.WriteLine("You shoot at the blob! You did " + randomDamage + " damage to the blob.");
                                    bullets = bullets - 20;
                                    blob.enemyHP -= randomDamage;
                                    Console.WriteLine("The enemy now has " + blob.enemyHP + " hit points left!");
                                    Console.Clear();
                                }
                                else
                                {


                                    Console.Clear();
                                    Console.WriteLine(" Too bad!");
                                    Console.WriteLine("===============================================");
                                }
                                // Enemy's turn to attack
                                int enemyRandomIndex = random.Next(EnemyDamage.Length);
                                int enemyRandomDamage = EnemyDamage[enemyRandomIndex];
                                Console.WriteLine("The blob attacks you and does " + enemyRandomDamage + " damage!");
                                playerHP = playerHP - enemyRandomDamage;
                            Console.WriteLine(" The blob now has " + blob.enemyHP  + " HP left ");
                            Console.WriteLine("===============================================");
                            Console.WriteLine("and NOW you have " + playerHP + " HP left ");
                                Console.WriteLine(" and  " + bullets + " bullets left ");

                                if (blob.enemyHP <= 0)
                                {
                                    Console.WriteLine("\n\n\tYou defeated the blob!\n");
                                    Console.WriteLine("\nhere comes the Goomba! NOW");
                                    Console.WriteLine("===============================================");
                                    break;



                                }
                            }
                            while (goomba.enemyHP > 0)
                            {
                                Console.WriteLine("Would you like to attack the goomba?");
                                Console.WriteLine("1- Yes");
                                Console.WriteLine("2- No");
                                action = Convert.ToInt32(Console.ReadLine());

                                if (action == 1)
                                {
                                    Console.Clear();
                                    int randomIndex = random.Next(RandomDamage.Length);
                                    int randomDamage = RandomDamage[randomIndex];
                                    Console.WriteLine("You shoot at the goomba! You did " + randomDamage + " damage to the goomba.");
                                    bullets = bullets - 20;
                                    goomba.enemyHP -= randomDamage;
                                    Console.WriteLine("The enemy now has " + goomba.enemyHP  + " hit points left!");
                                    Console.Clear();
                                }
                                else
                                {


                                    Console.Clear();
                                    Console.WriteLine(" Too bad!");
                                    Console.WriteLine("===============================================");
                                }
                                // Enemy's turn to attack
                                int enemyRandomIndex = random.Next(EnemyDamage.Length);
                                int enemyRandomDamage = EnemyDamage[enemyRandomIndex];
                                Console.WriteLine("The goomba attacks you and does " + enemyRandomDamage + " damage!");
                                playerHP = playerHP - enemyRandomDamage;
                            Console.WriteLine(" The Goomba now has " + goomba.enemyHP  + " HP left ");
                            Console.WriteLine("===============================================");
                            Console.WriteLine("You NOW have " + playerHP + " HP left ");
                                Console.WriteLine("and " + bullets + " bullets left ");

                                if (goomba.enemyHP <= 0)
                                {
                                    Console.WriteLine("\n\n\tYou defeated the Goomba! and you survived, GOOD WORK!\n");
                                    Console.WriteLine(" YOU COMPLETED THE RED ROOM!");
                                    Console.WriteLine("===============================================");
                                    completedRooms.Add("red");
                                    break;
                                }
                            

                        }



                            break;

                        case "black":
                            Console.Clear();
                            Console.WriteLine("You entered the black door.");
                            stopwatch.Start();
                            Console.WriteLine("You only have 15 seconds to type this code in or you lose!");
                            Console.WriteLine("241-124-7645-653");

                            string codeInput = Console.ReadLine(); 
                            stopwatch.Stop();

                            // Check if the player entered the correct code and did so within the time limit
                            if (codeInput == "241-124-7645-653" && stopwatch.Elapsed.TotalSeconds <= 15)
                            {
                                Console.WriteLine("Code entered successfully within the time limit! ");
                                Console.WriteLine(" YOU HAVE COMPLETED THE RED ROOM! ");
                                Console.WriteLine("===============================================");
                                completedRooms.Add("black"); // Add completed room to the list

                            }
                            else
                            {
                                Console.WriteLine("Sorry, you either entered the wrong code or took too long. You failed to complete the black room.");
                            }

                            stopwatch.Reset();
                            break;
                       

                        case "green":         
                            int awnser;

                            Console.WriteLine("You Enter the green room...");
                            Console.WriteLine("Solve the True or false questions to complete this room...");
                            Thread.Sleep(2000);
                            Console.Clear();

                            Console.WriteLine(" you restart the room if you get it wrong");
                            Console.WriteLine("1- True or false: Lasalle video Game DEC is 2 years");
                            Console.WriteLine("Type 1 for True, 2 for False..");

                            awnser = Convert.ToInt32(Console.ReadLine());

                            if (awnser == 1)
                            {
                                Console.WriteLine("You got it wrong, you DIED!");
                                break;

                            }
                            if (awnser == 2)
                            {
                                Console.WriteLine("Ding Ding! You got it right. Now, next question!");
                                Thread.Sleep(2000);
                                Console.Clear();

                                Console.WriteLine("1- True or false: The mona lisa was painted by leanardo Da vinci ");
                                Console.WriteLine("Type 1 for True, 2 for False..");
                                awnser = Convert.ToInt32(Console.ReadLine());

                                if (awnser == 1)
                                {
                                    Console.WriteLine("Ding Ding! You got it right");
                                    Console.WriteLine("YOU COMPLETD THE GREEN ROOM!");
                                    Console.WriteLine("===============================================");
                                    completedRooms.Add("green");
                                }
                                if (awnser == 2)
                                {
                                    Console.WriteLine("You Died!!! Wronggg");
                                    break;

                                }


                            }
                            break;


                        case "pink":
                            int DrawAwnser;
                            Console.Clear();
                            Console.WriteLine("You enter the Pink Room...");
                            Console.WriteLine("In this room, youll be shown 2 almost identical images  ");
                            Console.WriteLine("Your job is to be able to tell WHATS the difference. Lets start");
                            Thread.Sleep(4000);
                            Console.Clear();
                            Thread.Sleep(2500);


                            Console.WriteLine("    0              0                         !                    0                 0\r\n                                             !       \r\n            I                                !\r\n[                      ]                     !                             I\r\n[                      ]                     !\r\n[----------------------]                     !                [                        ]\r\n                                             !                [                        ]\r\n                                             !                [------------------------]\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n\r\n");
                            Thread.Sleep(4000);
                            Console.Clear();
                            Console.WriteLine("What is the difference?");
                            Console.WriteLine("Was it: 1- the Spacing of the Nose.. 2- How long the mouth was   ... 3- One was sad, other was happy...");
                            DrawAwnser = Convert.ToInt32(Console.ReadLine());



                            if (DrawAwnser == 1)
                            {
                                Console.WriteLine("Correct! ANSWER");
                                Console.WriteLine("YOU HAVE COMPLETED THE PINK ROOM!");
                            Console.WriteLine("===============================================");
                            completedRooms.Add("pink");
                            }
                            if (DrawAwnser == 2)
                            {
                                Console.WriteLine("Incorect, you lose!");
                            }
                            if (DrawAwnser == 3)
                            {
                                Console.WriteLine("Incorect, you lose!");

                            }
                            break;
                    case "blue":
                        Console.Clear();
                        Console.WriteLine("You enter the blue room...");
                        Console.WriteLine("In the room, you see an exact copy.. of you! He has the same HP and Attack power, Defeat Him!!");
                        Console.WriteLine("           __.......__\r\n            .-:::::::::::::-.\r\n          .:::''':::::::''':::.\r\n        .:::'     `:::'     `:::. \r\n   .'\\  ::'   ^^^  `:'  ^^^   '::  /`.\r\n  :   \\ ::   _.__       __._   :: /   ;\r\n :     \\`: .' ___\\     /___ `. :'/     ; \r\n:       /\\   (_|_)\\   /(_|_)   /\\       ;\r\n:      / .\\   __.' ) ( `.__   /. \\      ;\r\n:      \\ (        {   }        ) /      ; \r\n :      `-(     .  ^\"^  .     )-'      ;\r\n  `.       \\  .'<`-._.-'>'.  /       .'\r\n    `.      \\    \\;`.';/    /      .'\r\n jgs  `._    `-._       _.-'    _.'\r\n       .'`-.__ .'`-._.-'`. __.-'`.\r\n     .'       `.         .'       `.\r\n   .'           `-.   .-'           `.");
                        Thread.Sleep(3000);
                        Console.Clear();
                        ShadowPL ShadowPL = new ShadowPL();

                        while (ShadowPL.enemyHP > 0 && playerHP > 0)
                        {
                            Console.WriteLine("Your Medkit activated! ");
                            Console.WriteLine("Would you like to attack?");
                            Console.WriteLine("1- Yes");
                            Console.WriteLine("2- No");
                            Console.WriteLine("3- Medkit");
                            action = Convert.ToInt32(Console.ReadLine());

                            if (action == 1)
                            {
                                Console.Clear();
                                int randomIndex = random.Next(RandomDamage.Length);
                                int randomDamage = RandomDamage[randomIndex];
                                Console.WriteLine("You shoot at the SHADOW! You did " + randomDamage + " damage to the SHADOW.");
                                ShadowPL.enemyHP -= randomDamage;
                                Console.WriteLine("The enemy now has " + ShadowPL.enemyHP + " hit points left!");
                                Thread.Sleep(3000);
                                Console.Clear();
                                

                                if (ShadowPL.enemyHP <= 0)
                                {
                                    Console.WriteLine("You defeated SHADOW!");
                                    Console.WriteLine("YOU HAVE COMPLETED THE BLUE ROOM!");
                                    Console.WriteLine("===============================================");
                                    completedRooms.Add("blue");
                                }
                                else
                                {
                                    Console.WriteLine("The SHADOW Attacks You, he does " + EnemyDamage[random.Next(EnemyDamage.Length)] + " To You!");
                                    playerHP -= EnemyDamage[random.Next(EnemyDamage.Length)];
                                    Console.WriteLine("You Now have " + playerHP + " Hp Left!");
                                }
                            }
                            if (action == 3)
                            {
                                playerHP = playerHP + 45;
                                Console.WriteLine("You healed yourself for 45! you now have " + playerHP + " Health!");
                            }
                            else
                            {
                                Console.WriteLine("Wait, He's FAST!");
                                Console.WriteLine("The SHADOW Attacks You, he does " + EnemyDamage[random.Next(EnemyDamage.Length)] + " To You!");
                                playerHP -= EnemyDamage[random.Next(EnemyDamage.Length)];
                                Console.WriteLine("You Now have " + playerHP + " Hp Left!");
                            }

                            if (playerHP <= 0)
                            {
                                Console.WriteLine("You died! Game over.");
                                break;
                            }
                        }
                        break;

                    case "Save":

                        string path = "savefile.txt"; 

                        if (File.Exists(path))
                        {
                            // Open the text file using a stream reader.
                            using (StreamReader sr = new StreamReader(path))
                            {
                                // Read the stream to a string, and write the string to the console.
                                string line = sr.ReadToEnd();
                                Console.WriteLine(line);
                            }
                        }
                        else
                        {
                            Console.WriteLine("The file does not exist.");
                        }

                        break;

                        case "locked":


                        if (completedRooms.Count == 5)
                        {
                            Console.WriteLine("You have the Key!!");
                            Console.WriteLine(" .--.\r\n              /.-. '----------.\r\n              \\'-' .--\"--\"\"-\"-'\r\n           jgs '--'");
                            Console.WriteLine("Congratulations! You have completed all the rooms!");
                            Console.WriteLine("You were able to escape, nice!!!");
                            Console.WriteLine("                                 _       \r\n                                | |      \r\n  ___ ___  _ __   __ _ _ __ __ _| |_ ___ \r\n / __/ _ \\| '_ \\ / _` | '__/ _` | __/ __|\r\n| (_| (_) | | | | (_| | | | (_| | |_\\__ \\\r\n \\___\\___/|_| |_|\\__, |_|  \\__,_|\\__|___/\r\n                  __/ |                  \r\n                 |___/                   ");



                        }
                        
                        break;
                        

                        case "gold":
                        Console.WriteLine(" you see a Chest");
                        if (action == 1)
                        {
                            Console.WriteLine("");
                            
                            Console.WriteLine("You found a medkit!");
                            break;
                        }

                        if (action == 2)
                        {
                            Console.WriteLine("You should really pick it up...");
                            Console.Clear();
                        }
                            break;
                        default:
                            Console.WriteLine("Invalid action. Please choose again.");
                        break;
                    }

                    if (playerHP <= 0)
                    {
                        Console.WriteLine("you died Game over.");
                        break;
                    }
                    if (bullets <= 0)
                    {
                        Console.WriteLine("you ran out of bullets, Game over");
                        break;
                    }
                }
                Console.WriteLine("Congratulations! You have completed all the rooms!");
            }
        }
    }