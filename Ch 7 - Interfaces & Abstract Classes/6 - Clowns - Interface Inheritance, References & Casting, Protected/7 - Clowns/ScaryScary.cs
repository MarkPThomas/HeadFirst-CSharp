using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clowns
{
    class ScaryScary : FunnyFunny, IScaryClown
    {
        private int numberOfScaryThings;
        public string ScaryThingIHave { get { return "I have " + numberOfScaryThings + " spiders"; } }

        public ScaryScary(string funnyThingIHave, int numberOfScaryThings)
            :base(funnyThingIHave)
        {
            this.numberOfScaryThings = numberOfScaryThings;
        }

        public void ScareLittleChildren()
        {
            // Would need `this.funnyThingIHave` if it were `Private` instead of `Protected`
            Console.WriteLine("You can't have my " + funnyThingIHave);
        }

    }
}
