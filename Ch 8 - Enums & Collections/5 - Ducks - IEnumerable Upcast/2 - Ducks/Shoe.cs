using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ducks
{
    class Shoe
    {
        public Style Style;
        public string Color;

        public override string ToString()
        {
            return "A pair of " + Color + " " + Style;
        }
    }
}
