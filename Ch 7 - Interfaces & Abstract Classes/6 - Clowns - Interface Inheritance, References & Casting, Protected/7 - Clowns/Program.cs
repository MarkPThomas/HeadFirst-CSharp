using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clowns
{
    class Program
    {
        static void Main(string[] args)
        {
            TallGuy tallGuy = new TallGuy() { Height = 74, Name = "Jimmy" };
            tallGuy.TalkAboutYourself();
            tallGuy.Honk();
            
            ScaryScary fingersTheClown = new ScaryScary("big shoes", 14);
            FunnyFunny someFunnyClown = fingersTheClown;
            IScaryClown someOtherScaryClown = someFunnyClown as ScaryScary;
            
            // Maintains `Honk` method though IScaryClown inheriting from IClown
            someOtherScaryClown.Honk();

            Console.WriteLine(someOtherScaryClown.ScaryThingIHave);
            someOtherScaryClown.ScareLittleChildren();

            Console.ReadKey();
        }
    }
}
