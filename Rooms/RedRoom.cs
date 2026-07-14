using System;
using GunGame.Core;

namespace GunGame.Rooms
{
    public class RedRoom : Room
    {
        public override void Play(GameContext context)
        {
            var player = context.Player;
            var random = context.Random;

            Console.Clear();
            Console.WriteLine("You entered the red door.");
            Console.WriteLine("In front of you, you see a weird looking goblin!");

            var goblin = new Goblin();
            var blob = new Blob();
            var goomba = new Goomba();

            while (!goblin.IsDefeated && player.HP > 0)
            {
                Console.WriteLine("Would you like to attack the goblin?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                int action = Room.ReadInt(1, 2);

                if (action == 1)
                {
                    Console.Clear();
                    int randomDamage = player.Shoot(random);
                    Console.WriteLine("You shot at the goblin! You did " + randomDamage + " damage to the goblin.");
                    goblin.HP -= randomDamage;
                    Console.WriteLine("The enemy now has " + goblin.HP + " hit points left!");
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(" Too bad!");
                    Console.WriteLine("===============================================");
                }
                // Enemy's turn to attack
                int enemyRandomDamage = player.RollEnemyDamage(random);
                Console.WriteLine("The goblin attacks you and does " + enemyRandomDamage + " damage!");
                player.HP -= enemyRandomDamage;
                Console.WriteLine("the Goblin now has " + goblin.HP + " HP left ");
                Console.WriteLine("===============================================");
                Console.WriteLine("and NOW you have " + player.HP + " HP left ");
                Console.WriteLine("and  " + player.Bullets + " bullets left ");
                if (goblin.HP <= 0)
                {
                    Console.WriteLine("\n\n\tYou defeated the goblin!\n");
                    Console.WriteLine("===============================================");
                    Console.WriteLine("\nhere comes the Blob! NOW");
                }
            }

            if (player.HP <= 0)
            {
                return;
            }

            while (!blob.IsDefeated && player.HP > 0)
            {
                Console.WriteLine("Would you like to attack the blob?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                int action = Room.ReadInt(1, 2);

                if (action == 1)
                {
                    Console.Clear();
                    int randomDamage = player.Shoot(random);
                    Console.WriteLine("You shoot at the blob! You did " + randomDamage + " damage to the blob.");
                    blob.HP -= randomDamage;
                    Console.WriteLine("The enemy now has " + blob.HP + " hit points left!");
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(" Too bad!");
                    Console.WriteLine("===============================================");
                }
                // Enemy's turn to attack
                int enemyRandomDamage = player.RollEnemyDamage(random);
                Console.WriteLine("The blob attacks you and does " + enemyRandomDamage + " damage!");
                player.HP -= enemyRandomDamage;
                Console.WriteLine(" The blob now has " + blob.HP + " HP left ");
                Console.WriteLine("===============================================");
                Console.WriteLine("and NOW you have " + player.HP + " HP left ");
                Console.WriteLine(" and  " + player.Bullets + " bullets left ");

                if (blob.HP <= 0)
                {
                    Console.WriteLine("\n\n\tYou defeated the blob!\n");
                    Console.WriteLine("\nhere comes the Goomba! NOW");
                    Console.WriteLine("===============================================");
                    break;
                }
            }

            if (player.HP <= 0)
            {
                return;
            }

            while (!goomba.IsDefeated && player.HP > 0)
            {
                Console.WriteLine("Would you like to attack the goomba?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                int action = Room.ReadInt(1, 2);

                if (action == 1)
                {
                    Console.Clear();
                    int randomDamage = player.Shoot(random);
                    Console.WriteLine("You shoot at the goomba! You did " + randomDamage + " damage to the goomba.");
                    goomba.HP -= randomDamage;
                    Console.WriteLine("The enemy now has " + goomba.HP + " hit points left!");
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(" Too bad!");
                    Console.WriteLine("===============================================");
                }
                // Enemy's turn to attack
                int enemyRandomDamage = player.RollEnemyDamage(random);
                Console.WriteLine("The goomba attacks you and does " + enemyRandomDamage + " damage!");
                player.HP -= enemyRandomDamage;
                Console.WriteLine(" The Goomba now has " + goomba.HP + " HP left ");
                Console.WriteLine("===============================================");
                Console.WriteLine("You NOW have " + player.HP + " HP left ");
                Console.WriteLine("and " + player.Bullets + " bullets left ");

                if (goomba.HP <= 0)
                {
                    Console.WriteLine("\n\n\tYou defeated the Goomba! and you survived, GOOD WORK!\n");
                    Console.WriteLine(" YOU COMPLETED THE RED ROOM!");
                    Console.WriteLine("===============================================");
                    context.CompletedRooms.Add("red");
                    break;
                }
            }
        }
    }
}
