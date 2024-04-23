using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NarrativeProject.Rooms
{
    internal class blueroom : Room
    {
        
        internal override string CreateDescription() =>
      @"";

        internal override void ReceiveTask(string choice)
        {
            switch (choice)
            {
                case "1":
                    Console.WriteLine("");
                    break;
                case "2":
                    Console.WriteLine("");
                    break;
                case "3":
                    Console.WriteLine("");
                    
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }
            
                
    }

}

