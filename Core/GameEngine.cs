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
            GameData loadedData = SaveSystem.LoadGame();
            bool resuming = false;

            if (loadedData != null)
            {
                Console.WriteLine("A saved game was found: " + loadedData.playerHP + " HP, " + loadedData.bullets + " bullets, " + loadedData.completedRooms.Count + " room(s) completed.");
                Console.WriteLine("1- Continue saved game");
                Console.WriteLine("2- Start a new game");
                int resumeChoice = Room.ReadInt(1, 2);

                if (resumeChoice == 1)
                {
                    player.HP = loadedData.playerHP;
                    player.Bullets = loadedData.bullets;
                    player.MedkitPickedUp = loadedData.medkitPickedUp;
                    player.MedkitUsed = loadedData.medkitUsed;
                    completedRooms.Clear();
                    completedRooms.AddRange(loadedData.completedRooms);
                    resuming = true;
                }
                else
                {
                    SaveSystem.DeleteSave();
                }
            }

            Console.WriteLine("WELCOME TO GUNGAME");
            Console.WriteLine(" +--^----------,--------,-----,--------^-,\r\n | |||||||||   `--------'     |          O\r\n `+---------------------------^----------|\r\n   `\\_,---------,---------,--------------'\r\n     / XXXXXX /'|       /'\r\n    / XXXXXX /  `\\    /'\r\n   / XXXXXX /`-------'\r\n  / XXXXXX /\r\n / XXXXXX /\r\n(________(                \r\n `------'    ");
            Console.WriteLine("PRESS ENTER TO START THE GAME");
            Console.ReadLine();
            Room.SafeClear();

            if (!resuming)
            {
                while (true)
                {
                    Room.SafeClear();
                    Console.WriteLine("===============================================");
                    Console.WriteLine("You wake up in a room confused. In front of you there's a gun,Do you pick it up?");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("1- Yes");

                    int action = Room.ReadInt(1, 1);

                    if (action == 1)
                    {
                        Console.WriteLine("===============================================");
                        Console.WriteLine("You picked up the gun.");
                        Console.WriteLine("===============================================");
                        Thread.Sleep(1000);
                        Room.SafeClear();
                        break;
                    }
                }

                Room.SafeClear();
                Console.WriteLine("===============================================");
                Console.WriteLine("You notice how many bullets you have in total");
                Console.WriteLine("You have " + player.Bullets + " bullets");
                Console.WriteLine("You have " + player.HP + " hit points available");
                Console.WriteLine("===============================================");

                Thread.Sleep(4000);
                Room.SafeClear();
            }

            var context = new GameContext(player, random, completedRooms);

            bool escaped = false;

            while (!escaped)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("You see 6 doors in front of you, though the 6th door is Locked. ");
                Console.WriteLine("Once you complete the TASK in ALL the 5 main rooms, the Locked door will open. ");
                Console.WriteLine("Now Type the room color to  START, write gold to access your inventory, or write save to save your progress");

                Console.WriteLine("===============================================");
                WriteDoorOption("1- [red door]", "red");
                Console.WriteLine("===============================================");
                WriteDoorOption("2- [black door]", "black");
                Console.WriteLine("===============================================");
                WriteDoorOption("3- [green door]", "green");
                Console.WriteLine("===============================================");
                WriteDoorOption("4- [pink door]", "pink");
                Console.WriteLine("===============================================");
                WriteDoorOption("5- [blue door]", "blue");
                Console.WriteLine("===============================================");
                Console.WriteLine("6- [Locked door]");
                Console.WriteLine("===============================================");
                Console.WriteLine("7- [gold door(inventory)]");
                Console.WriteLine("===============================================");
                Console.WriteLine("8- [Save Game]");
                Console.WriteLine("===============================================");
                Console.WriteLine("Which door would you like to go in?");
                Console.WriteLine("===============================================");

                string room = Room.ReadLineOrExit().ToLower();

                if (completedRooms.Contains(room))
                {
                    Console.WriteLine("YOU HAVE ALREADY COMPLETED THIS ROOM. PLEASE CHOOSE ANOTHER ONE.");
                    Room.SafeClear();
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
                else if (room == "save")
                {
                    SaveSystem.SaveGame(new GameData
                    {
                        playerHP = player.HP,
                        bullets = player.Bullets,
                        medkitPickedUp = player.MedkitPickedUp,
                        medkitUsed = player.MedkitUsed,
                        completedRooms = new List<string>(completedRooms),
                    });
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
                    SaveSystem.DeleteSave();
                    return;
                }

                if (player.HP <= 0)
                {
                    Console.WriteLine("You have died. Game over.");
                    SaveSystem.DeleteSave();
                    return;
                }
            }
            Console.WriteLine("Congratulations! You have completed all the rooms!");
            SaveSystem.DeleteSave();
        }

        private void WriteDoorOption(string label, string roomKey)
        {
            if (completedRooms.Contains(roomKey))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(label);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(label);
            }
        }
    }
}
