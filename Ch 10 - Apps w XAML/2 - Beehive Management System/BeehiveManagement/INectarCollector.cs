using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeehiveManagement
{
    interface INectarCollector : IWorker
    {
        void FindFlowers();
        void GatherNectar();
        void ReturnToHive();
    }
}
