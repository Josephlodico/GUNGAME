using System;
using static System.Collections.Specialized.BitVector32;
using System.Threading;
using System.Collections.Generic;
using System.Collections;


namespace NarrativeProject.Rooms
{
    public class Goblin
    {
        public int enemyHP = 50;
    }
    internal class redroom : Room
    {
        

        internal override string CreateDescription() =>
    @" You entered the red door,In front of you, you see a weird looking monster!    ";

        internal override void ReceiveTask(string choice)

        {
            int action;
            int playerHP = 100;
            int[] RandomDamage = { 28, 32, 12, 44, 50, 24 }; // This is for the Gun damage
            Random random = new Random();

            int[] EnemyDamage = { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

            Goblin goblin = new Goblin();

            while (goblin.enemyHP > 0)
            {
                Console.WriteLine("Would you like to attack?");
                Console.WriteLine("1- Yes");
                Console.WriteLine("2- No");
                action = Convert.ToInt32(Console.ReadLine());

                if (action == 1)
                {
                    Console.Clear();
                    int randomIndex = random.Next(RandomDamage.Length);
                    int randomDamage = RandomDamage[randomIndex];
                    Console.WriteLine("You shoot at the Monster! You did " + randomDamage + " damage to the monster.");
                    goblin.enemyHP -= randomDamage;
                    Console.WriteLine("The enemy now has " + goblin.enemyHP + " hit points left!");
                    Console.WriteLine("The goblin attacks you, he does" + EnemyDamage + " damage!");
                    playerHP = playerHP - EnemyDamage[randomIndex];
                    Console.WriteLine("you now have" + playerHP + "HP left ");

                    if (goblin.enemyHP <= 0)
                    {
                        Console.WriteLine("You defeated the monster!");
                        Console.WriteLine("You cleared the red room!");
                        // Add completed room to the list
                       //completedRooms.Add("red");
                    }

                    
                }

            }
        }






    }
}
    




