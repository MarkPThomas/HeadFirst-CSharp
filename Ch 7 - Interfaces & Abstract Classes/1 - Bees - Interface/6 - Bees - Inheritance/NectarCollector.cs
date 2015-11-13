using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bees
{
    class NectarCollector: Worker, INectarCollector
    {
        public int Nectar { get; set; }

        public NectarCollector(double weightMG)
            : base(new string[] { "Nectar Collector" }, weightMG)
        {

        }

        public void FindFlowers() { }

        public void GatherNectar() { }

        public void ReturnToHive() { }
    }
}
