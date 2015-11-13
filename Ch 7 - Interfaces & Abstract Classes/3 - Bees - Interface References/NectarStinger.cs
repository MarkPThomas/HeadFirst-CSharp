using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesInterfaceReference
{
    class NectarStinger: Worker, INectarCollector, IStingPatrol
    {
        public NectarStinger(double weightMG)
            : base(new string[] { "Nectar Collector" , "String Patrol"}, weightMG)
        {

        }

        public int AlertLevel
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public int StingerLength
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void FindFlowers()
        {
            throw new NotImplementedException();
        }

        public void GatherNectar()
        {
            throw new NotImplementedException();
        }

        public bool LookForEnemies()
        {
            throw new NotImplementedException();
        }

        public void ReturnToHive()
        {
            throw new NotImplementedException();
        }

        public bool SharpenStinger(int length)
        {
            throw new NotImplementedException();
        }
    }
}
