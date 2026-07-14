using System;
using System.Collections.Generic;
using System.Threading;
using GunGame.Rooms;

namespace GunGame.Core
{
    public class GameEngine
    {
        private readonly Random random = new Random();
        private readonly List<string> completedRooms = new List<string>();
        private readonly Player player = new Player();
        private readonly Dictionary<string, Room> rooms;

        public GameEngine()
        {
            rooms = new Dictionary<string, Room>
            {
                ["red"] = new RedRoom(),
                ["black"] = new BlackRoom(),
                ["green"] = new GreenRoom(),
                ["pink"] = new PinkRoom(),
                ["blue"] = new BlueRoom(),
            };
        }

        public void Run()
        {
            player.MedkitPickedUp = false;

            Console.WriteLine(" here is your saved progress");

            GameData gameData = new GameData();
            gameData.playerHP = 0;
            gameData.bullets = 0;

            SaveSystem.SaveGame(gameData);

            GameData loadedData = SaveSystem.LoadGame();

            if (loadedData != null)
            {
                Console.WriteLine("Loaded Player Name: " + loadedData.bullets);
                Console.WriteLine("Loaded Player Score: " + loadedData.playerHP);
            }

            Console.ReadLine();

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

                int action = Convert.ToInt32(Console.ReadLine());

                if (action == 1)
                {
                    Console.WriteLine("===============================================");
                    Console.WriteLine("You picked up the gun.");
                    Console.WriteLine("===============================================");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
                }
            }

            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("You notice how many bullets you have in total");
            Console.WriteLine("You have " + player.Bullets + " bullets");
            Console.WriteLine("You have " + player.HP + " hit points available");
            Console.WriteLine("===============================================");

            Thread.Sleep(4000);
            Console.Clear();

            var context = new GameContext(player, random, completedRooms);

            bool escaped = false;

            while (!escaped)
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

                string room = Console.ReadLine().ToLower();

                if (completedRooms.Contains(room))
                {
                    Console.WriteLine("YOU HAVE ALREADY COMPLETED THIS ROOM. PLEASE CHOOSE ANOTHER ONE.");
                    Console.Clear();
                    continue;
                }

                if (rooms.TryGetValue(room, out Room selectedRoom))
                {
                    selectedRoom.Play(context);
                }
                else if (room == "locked")
                {
                    if (completedRooms.Count == 5)
                    {
                        Console.WriteLine(" .--.\r\n              /.-. '----------.\r\n              \\ '-' .--\"--\"\"-\"-'");
                        Console.WriteLine("Congratulations! You now have the key to escape,");
                        escaped = true;
                    }
                    else
                    {
                        Console.WriteLine("The Door is locked");
                    }
                }
                else if (room == "gold")
                {
                    Console.WriteLine("You see a chest with stuff inside.");
                    if (!player.MedkitPickedUp)
                    {
                        Console.WriteLine("You found a medkit!");
                        player.MedkitPickedUp = true;
                    }
                    else
                    {
                        Console.WriteLine("You've already picked up the medkit.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid action. Please choose again.");
                }

                if (escaped)
                {
                    break;
                }

                if (player.Bullets <= 0)
                {
                    Console.WriteLine("you ran out of bullets, Game over");
                    return;
                }

                if (player.HP <= 0)
                {
                    Console.WriteLine("You have died. Game over.");
                    return;
                }
            }
            Console.WriteLine("Congratulations! You have completed all the rooms!");
        }
    }
}
