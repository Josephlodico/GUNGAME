using System;

namespace GunGame.Core
{
    public class Player
    {
        private static readonly int[] GunDamage = { 21, 31, 22, 30, 19, 25, 71, 37, 27, 24, 55, 100, 22, 26, 100 };
        private static readonly int[] EnemyDamage = { 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 };

        public int HP { get; set; } = 200;
        public int Bullets { get; set; } = 250;
        public bool MedkitPickedUp { get; set; }
        public bool MedkitUsed { get; set; }

        public int Shoot(Random random)
        {
            int damage = GunDamage[random.Next(GunDamage.Length)];
            Bullets -= 20;
            return damage;
        }

        public int RollEnemyDamage(Random random)
        {
            return EnemyDamage[random.Next(EnemyDamage.Length)];
        }

        public void UseMedkit()
        {
            if (!MedkitPickedUp)
            {
                Console.WriteLine("You don't have a medkit to use.");
            }
            else if (!MedkitUsed)
            {
                MedkitUsed = true;
                HP += 55;
                Console.WriteLine("You healed yourself for 55 HP! you now have " + HP + " Health!");
            }
            else
            {
                Console.WriteLine("You've already used the medkit.");
            }
        }
    }
}
