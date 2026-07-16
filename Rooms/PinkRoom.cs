using System;
using System.Threading;
using GunGame.Core;

namespace GunGame.Rooms
{
    public class PinkRoom : Room
    {
        public override void Play(GameContext context)
        {
            var player = context.Player;

            Room.SafeClear();
            Console.WriteLine("===============================================");
            Console.WriteLine("You Enter the Pink Room...");
            Console.WriteLine("In this room, you will be shown 2 almost identical images  ");
            Console.WriteLine("Your job is to be able to tell the difference. Lets start");
            Console.WriteLine("===============================================");
            Thread.Sleep(2000);
            Room.SafeClear();
            Thread.Sleep(2000);

            Console.WriteLine("    0              0                         !                    0                 0\r\n                                             !       \r\n            I                                !\r\n[                      ]                     !                             I\r\n[                      ]                     !\r\n[----------------------]                     !                [                        ]\r\n                                             !                [                        ]\r\n                                             !                [------------------------]\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n                                             !\r\n\r\n");
            Thread.Sleep(4000);
            Room.SafeClear();
            Console.WriteLine("What is the difference?");
            Console.WriteLine("Was it: 1- the Spacing of the Nose.. 2- How long the mouth was   ... 3- One was sad, other was happy...");
            int drawAnswer = Room.ReadInt(1, 3);

            if (drawAnswer == 1)
            {
                Console.WriteLine("Correct!");
                Console.WriteLine("YOU HAVE COMPLETED THE PINK ROOM!");
                Console.WriteLine("===============================================");
                context.CompletedRooms.Add("pink");
            }
            if (drawAnswer == 2)
            {
                Console.WriteLine("Incorect, you lose!");
                player.HP = 0;
                return;
            }
            if (drawAnswer == 3)
            {
                Console.WriteLine("Incorect, you lose!");
                player.HP = 0;
                return;
            }
        }
    }
}
