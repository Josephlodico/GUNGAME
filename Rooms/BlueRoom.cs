using System;
using System.Threading;
using GunGame.Core;

namespace GunGame.Rooms
{
    public class BlueRoom : Room
    {
        public override void Play(GameContext context)
        {
            var player = context.Player;
            var random = context.Random;

            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("You Entered the blue room...");
            Console.WriteLine("In the room, you see an exact copy.. of you! He has the same HP and Attack power, Defeat Him!!");
            Console.WriteLine("===============================================");
            Console.WriteLine("           __.......__\r\n            .-:::::::::::::-.\r\n          .:::''':::::::''':::.\r\n        .:::'     `:::'     `:::. \r\n   .'\\  ::'   ^^^  `:'  ^^^   '::  /`.\r\n  :   \\ ::   _.__       __._   :: /   ;\r\n :     \\`: .' ___\\     /___ `. :'/     ; \r\n:       /\\   (_|_)\\   /(_|_)   /\\       ;\r\n:      / .\\   __.' ) ( `.__   /. \\      ;\r\n:      \\ (        {   }        ) /      ; \r\n :      `-(     .  ^\"^  .     )-'      ;\r\n  `.       \\  .'<`-._.-'>'.  /       .'\r\n    `.      \\    \\;`.';/    /      .'\r\n   `._    `-._       _.-'    _.'\r\n       .'`-.__ .'`-._.-'`. __.-'`.\r\n     .'       `.         .'       `.\r\n   .'           `-.   .-'           `.");
            Thread.Sleep(3000);
            Console.Clear();

            var shadowClone = new ShadowClone();

            while (!shadowClone.IsDefeated && player.HP > 0)
            {
                Console.WriteLine("===============================================");
                Console.WriteLine("Would you like to attack?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                Console.WriteLine("3- Medkit");
                Console.WriteLine("===============================================");

                // Read user input and handle errors
                bool validInput = int.TryParse(Console.ReadLine(), out int userAction);

                if (!validInput || userAction < 1 || userAction > 3)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                    continue; // Skip the rest of the loop and prompt again
                }

                if (userAction == 1)
                {
                    Console.Clear();
                    int randomDamage = player.Shoot(random);
                    Console.WriteLine("You shoot at the SHADOW! You did " + randomDamage + " damage to the SHADOW.");
                    shadowClone.HP -= randomDamage;
                    if (shadowClone.HP > 0)
                    {
                        Console.WriteLine("The enemy now has " + shadowClone.HP + " hit points left!");
                    }
                    Thread.Sleep(3000);
                    Console.Clear();

                    if (shadowClone.HP <= 0)
                    {
                        Console.WriteLine("You defeated THE SHADOW!");
                        Console.WriteLine("YOU HAVE COMPLETED THE BLUE ROOM!");
                        Console.WriteLine("===============================================");
                        context.CompletedRooms.Add("blue");
                    }
                    else
                    {
                        int enemyDamage = player.RollEnemyDamage(random);
                        Console.WriteLine("The SHADOW Attacks You, he does " + enemyDamage + " To You!");
                        player.HP -= enemyDamage;
                        Console.WriteLine("You Now have " + player.HP + " Hp Left!");
                    }
                }
                else if (userAction == 3)
                {
                    player.UseMedkit();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wait, He's FAST!");
                    int enemyDamage = player.RollEnemyDamage(random);
                    Console.WriteLine("The SHADOW Attacks You, he does " + enemyDamage + " To You!");
                    player.HP -= enemyDamage;
                    Console.WriteLine("You Now have " + player.HP + " Hp Left!");
                }

                if (player.HP <= 0)
                {
                    Console.WriteLine("You died! Game over.");
                    break;
                }
            }
        }
    }
}
