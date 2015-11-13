using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesInterfaceInheritance
{
    interface INectarCollector : IWorker
    {
        void FindFlowers();
        void GatherNectar();
        void ReturnToHive();
    }
}
