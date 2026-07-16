using System;
using System.Threading;
using GunGame.Core;

namespace GunGame.Rooms
{
    public class GreenRoom : Room
    {
        public override void Play(GameContext context)
        {
            var player = context.Player;

            Room.SafeClear();
            Console.WriteLine("===============================================");
            Console.WriteLine("You Entered the green room...");
            Console.WriteLine("Solve the True or false questions to complete this room...");
            Console.WriteLine("===============================================");
            Thread.Sleep(2000);
            Room.SafeClear();
            Console.WriteLine("===============================================");
            Console.WriteLine("1- True or false: Lasalle video Game DEC is 2 years");
            Console.WriteLine("Type 1 for True, 2 for False..");
            Console.WriteLine("===============================================");

            int answer = Room.ReadInt(1, 2);

            if (answer == 1)
            {
                Console.WriteLine("You got it wrong, you DIED!");
                player.HP = 0;
                return;
            }
            if (answer == 2)
            {
                Console.WriteLine("Ding Ding! You got it right. Now, next question!");
                Thread.Sleep(2000);
                Room.SafeClear();

                Console.WriteLine("1- True or false: The mona lisa was painted by leanardo Da vinci ");
                Console.WriteLine("Type 1 for True, 2 for False..");
                answer = Room.ReadInt(1, 2);

                if (answer == 1)
                {
                    Console.WriteLine("Ding Ding! You got it right");
                    Console.WriteLine("YOU HAVE COMPLETE THE GREEN ROOM!");
                    Console.WriteLine("===============================================");
                    context.CompletedRooms.Add("green");
                }
                if (answer == 2)
                {
                    Console.WriteLine("You Died!!! Wronggg");
                    player.HP = 0;
                    return;
                }
            }
        }
    }
}
