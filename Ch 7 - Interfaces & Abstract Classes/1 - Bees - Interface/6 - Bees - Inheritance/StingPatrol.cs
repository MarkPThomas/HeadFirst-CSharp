using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bees
{
    class StingPatrol: Worker, IStingPatrol
    {
        public int StingerLength { get; set; }
        public int AlertLevel
        {
            get; private set;
        }

        public StingPatrol(double weightMG)
            : base(new string[]{ "Sting Patrol"}, weightMG)
        {

        }

        public bool SharpenStinger(int length)
        {
            if (length < StingerLength)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool LookForEnemies()
        {
            return true;
        }

        public void Sting(string Enemy) { }
    }
}
