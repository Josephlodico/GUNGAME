using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Xml.Serialization;
//project name GUNGAME
//Made by Joseph, Anthony
//Date:2024-04-23
//Description: using gitkraken and github and creating a game called GUNGAME.
namespace NarrativeProject
{
    [Serializable]
    public class GameData
    {
        
        public int playerHP;
        public int bullets;
        // Add more properties as needed
    }
    public class SaveSystem
    {
        private static string savePath = "saveData.txt";

        public static void SaveGame(GameData data)
        {
            // Serialize the game data
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Create(savePath);
            formatter.Serialize(fileStream, data);
            fileStream.Close();
            Console.WriteLine("Game saved successfully!");
        }
        public static GameData LoadGame()
        {
            if (File.Exists(savePath))
            {
                // Deserialize the game data
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream fileStream = File.Open(savePath, FileMode.Open);
                GameData data = (GameData)formatter.Deserialize(fileStream);
                fileStream.Close();
                Console.WriteLine("Game loaded successfully!");
                return data;
            }
            else
            {
                Console.WriteLine("No saved game found.");
                return null;
            }
        }
        internal class Program
        {
            private static bool medkitPickedUp = false;
            private static bool medkitUsed = false;
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
                public int playerHP { get; private set; }
                private bool used;

                public Medkit()
                {
                    playerHP = 0;
                    used = false;
                }

                public void UseMedkit(ref int playerHP)
                {
                    if (!used)
                    {
                        playerHP += playerHP;
                        Console.WriteLine($"You used a medkit and restored {playerHP} health points. Your current health is {playerHP}.");
                        used = true;
                    }
                    else
                    {
                        Console.WriteLine("You've already used the medkit.");
                    }
                }
            }
            static void Main(string[] args)
            {
                medkitPickedUp = false;

                //var game = new Game();
                //    game.Add(new redroom());
                //    game.Add(new blackroom());
                //    game.Add(new greenroom());                    
                //    game.Add(new pinkroom());
                //    game.Add(new blueroom());

                int action;
                int bullets = 250;
                int playerHP = 200;

                //Medkit medkit = new Medkit();
                //List<string> inventory = new List<string>() { "medkit", "ammo" }; 
                Stopwatch stopwatch = new Stopwatch();
                List<string> completedRooms = new List<string>();
                string room;
                {
                    Console.WriteLine(" here is your saved progress");

                    GameData gameData = new GameData();
                    gameData.playerHP = 0;
                    gameData.bullets = 0;

                    // Save the game
                    SaveSystem.SaveGame(gameData);

                    // Load the game
                    GameData loadedData = SaveSystem.LoadGame();

                    if (loadedData != null)
                    {
                        Console.WriteLine("Loaded Player Name: " + loadedData.bullets) ;
                        Console.WriteLine("Loaded Player Score: " + loadedData.playerHP);
                    }

                    Console.ReadLine();
                }

                int[] RandomDamage = { 21, 31, 22, 30, 19, 25, 71, 37, 27, 24, 55, 100, 22, 26, 100 }; // This is for the Gun damage
                Random random = new Random();
               

                int[] EnemyDamage = { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

                Console.WriteLine("WELCOME TO GUNGAME");
                Console.WriteLine(" +--^----------,--------,-----,--------^-,\r\n | |||||||||   `--------'     |          O\r\n `+---------------------------^----------|\r\n   `\\_,---------,---------,--------------'\r\n     / XXXXXX /'|       /'\r\n    / XXXXXX /  `\\    /'\r\n   / XXXXXX /`-------'\r\n  / XXXXXX /\r\n / XXXXXX /\r\n(________(                \r\n `------'    ");
                Console.WriteLine("PRESS ENTER TO START THE GAME");
                Console.ReadLine();
                Console.Clear();

                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("===============================================");
                    Console.WriteLine("You wake up in a room confused. In front of you there's a gun,Do you pick it up?");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("1- Yes");


                    action = Convert.ToInt32(Console.ReadLine());

                    if (action == 1)
                    {
                        Console.WriteLine("===============================================");
                        Console.WriteLine("You picked up the gun.");
                        Console.WriteLine("===============================================");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                        ;

                    }

                }

                Console.Clear();
                Console.WriteLine("===============================================");
                Console.WriteLine("You notice how many bullets you have in total");
                Console.WriteLine("You have " + bullets + " bullets");
                Console.WriteLine("You have " + playerHP + " hit points available");
                Console.WriteLine("===============================================");

                Thread.Sleep(4000);
                Console.Clear();

                while (completedRooms.Count < 5) // Change '>' to '<' to ensure loop runs until 5 rooms are completed
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("You see 6 doors in front of you, though the 6th door is Locked. ");
                    Console.WriteLine("Once you complete the TASK in ALL the 5 main rooms, the Locked door will open. ");
                    Console.WriteLine("Now Type the room color to  START or write gold to access your inventory");

                    Console.WriteLine("===============================================");
                    Console.WriteLine("1- [red door]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("2- [black door]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("3- [green door]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("4- [pink door]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("5- [blue door]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("6- [Locked door]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("7- [gold door(inventory)]");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("Which door would you like to go in?");
                    Console.WriteLine("===============================================");
                    
                    room = Console.ReadLine().ToLower();

                    if (completedRooms.Contains(room))
                    {
                        Console.WriteLine("YOU HAVE ALREADY COMPLETED THIS ROOM. PLEASE CHOOSE ANOTHER ONE.");
                        Console.Clear();
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
                                Console.WriteLine("the Goblin now has " + goblin.enemyHP + " HP left ");
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
                                Console.WriteLine(" The blob now has " + blob.enemyHP + " HP left ");
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
                                    Console.WriteLine("The enemy now has " + goomba.enemyHP + " hit points left!");
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
                                Console.WriteLine(" The Goomba now has " + goomba.enemyHP + " HP left ");
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
                            string[] codes = { "241-124-7645-653" };
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

                            if (completedRooms != null && !completedRooms.Contains("black"))
                            {
                                completedRooms.Add("black"); // Add completed room to the list
                            }
                            break;
                        case "green":
                            int answer;
                            Console.Clear();
                            Console.WriteLine("===============================================");
                            Console.WriteLine("You Entered the green room...");
                            Console.WriteLine("Solve the True or false questions to complete this room...");
                            Console.WriteLine("===============================================");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Console.WriteLine("===============================================");
                            Console.WriteLine("1- True or false: Lasalle video Game DEC is 2 years");
                            Console.WriteLine("Type 1 for True, 2 for False..");
                            Console.WriteLine("===============================================");


                            answer = Convert.ToInt32(Console.ReadLine());

                            if (answer == 1)
                            {
                                Console.WriteLine("You got it wrong, you DIED!");
                                break;

                            }
                            if (answer == 2)
                            {
                                Console.WriteLine("Ding Ding! You got it right. Now, next question!");
                                Thread.Sleep(2000);
                                Console.Clear();

                                Console.WriteLine("1- True or false: The mona lisa was painted by leanardo Da vinci ");
                                Console.WriteLine("Type 1 for True, 2 for False..");
                                answer = Convert.ToInt32(Console.ReadLine());

                                if (answer == 1)
                                {

                                   
                                    Console.WriteLine("Ding Ding! You got it right");
                                    Console.WriteLine("YOU HAVE COMPLETE THE GREEN ROOM!");
                                    Console.WriteLine("===============================================");
                                    completedRooms.Add("green");
                                }
                                if (answer == 2)
                                {
                                    Console.WriteLine("You Died!!! Wronggg");
                                    break;

                                }


                            }
                            break;
                        case "pink":
                            int DrawAwnser;
                            Console.Clear();
                            Console.WriteLine("===============================================");
                            Console.WriteLine("You Enter the Pink Room...");
                            Console.WriteLine("In this room, you will be shown 2 almost identical images  ");
                            Console.WriteLine("Your job is to be able to tell the difference. Lets start");
                            Console.WriteLine("===============================================");
                            Thread.Sleep(2000);
                            Console.Clear();
                            Thread.Sleep(2000);


                            Console.WriteLine("    0              0                         !                    0                 0\r\n                                             !       \r\n            I                                !\r\n[                      ]                     !                             I\r\n[                      ]                     !\r\n[----------------------]                     !                [                        ]\r\n                                             !                [                        ]\r\n                                             !                [------------------------]\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n\r\n");
                            Thread.Sleep(4000);
                            Console.Clear();
                            Console.WriteLine("What is the difference?");
                            Console.WriteLine("Was it: 1- the Spacing of the Nose.. 2- How long the mouth was   ... 3- One was sad, other was happy...");
                            DrawAwnser = Convert.ToInt32(Console.ReadLine());



                            if (DrawAwnser == 1)
                            {
                                Console.WriteLine("Correct!");
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
                            Console.WriteLine("===============================================");
                            Console.WriteLine("You Entered the blue room...");
                            Console.WriteLine("In the room, you see an exact copy.. of you! He has the same HP and Attack power, Defeat Him!!");
                            Console.WriteLine("===============================================");
                            Console.WriteLine("           __.......__\r\n            .-:::::::::::::-.\r\n          .:::''':::::::''':::.\r\n        .:::'     `:::'     `:::. \r\n   .'\\  ::'   ^^^  `:'  ^^^   '::  /`.\r\n  :   \\ ::   _.__       __._   :: /   ;\r\n :     \\`: .' ___\\     /___ `. :'/     ; \r\n:       /\\   (_|_)\\   /(_|_)   /\\       ;\r\n:      / .\\   __.' ) ( `.__   /. \\      ;\r\n:      \\ (        {   }        ) /      ; \r\n :      `-(     .  ^\"^  .     )-'      ;\r\n  `.       \\  .'<`-._.-'>'.  /       .'\r\n    `.      \\    \\;`.';/    /      .'\r\n jgs  `._    `-._       _.-'    _.'\r\n       .'`-.__ .'`-._.-'`. __.-'`.\r\n     .'       `.         .'       `.\r\n   .'           `-.   .-'           `.");
                            Thread.Sleep(3000);
                            Console.Clear();
                            ShadowPL shadowPL = new ShadowPL();
                            bool medkitUsed = false;

                            while (shadowPL.enemyHP > 0 && playerHP > 0)
                            {

                                Console.WriteLine("===============================================");
                                Console.WriteLine("Would you like to attack?");
                                Console.WriteLine("1- Yes");
                                Console.WriteLine("2- No");
                                Console.WriteLine("3- Medkit");
                                Console.WriteLine("===============================================");


                                // Read user input and handle errors
                                int userAction;
                                bool validInput = int.TryParse(Console.ReadLine(), out userAction);

                                if (!validInput || userAction < 1 || userAction > 3)
                                {
                                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                                    continue; // Skip the rest of the loop and prompt again
                                }

                                if (userAction == 1)
                                {
                                    Console.Clear();
                                    int randomIndex = random.Next(RandomDamage.Length);
                                    int randomDamage = RandomDamage[randomIndex];
                                    Console.WriteLine("You shoot at the SHADOW! You did " + randomDamage + " damage to the SHADOW.");
                                    shadowPL.enemyHP -= randomDamage;
                                    Console.WriteLine("The enemy now has " + shadowPL.enemyHP + " hit points left!");
                                    Thread.Sleep(3000);
                                    Console.Clear();

                                    if (shadowPL.enemyHP <= 0)
                                    {
                                        Console.WriteLine("You defeated THE SHADOW!");
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
                                else if (userAction == 3)
                                {
                                    if (!medkitUsed)
                                    {
                                        medkitUsed = true; // Set medkitUsed to true to indicate it has been used
                                        playerHP = (playerHP + 55); // Ensure player HP doesn't exceed 100
                                        Console.WriteLine("You healed yourself for 55 HP! you now have " + playerHP + " Health!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("You've already used the medkit.");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
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
                        
                           
                            
                        case "locked":

                            if (completedRooms.Count == 5)

                            {
                                Console.WriteLine(" .--.\r\n              /.-. '----------.\r\n              \\ '-' .--\"--\"\"-\"-'");
                                Console.WriteLine("Congratulations! You now have the key to escape,");


                            }
                            else if (completedRooms.Count < 5)
                            {
                                Console.WriteLine("The Door is locked");
                            }
                            break;
                        case "gold":
                            Console.WriteLine("You see a chest with stuff inside.");
                            if (!medkitPickedUp)
                            {
                                Console.WriteLine("You found a medkit!");
                                medkitPickedUp = true;
                            }
                            else
                            {
                                Console.WriteLine("You've already picked up the medkit.");
                            }
                            break;


                        default:
                            Console.WriteLine("Invalid action. Please choose again.");
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
}