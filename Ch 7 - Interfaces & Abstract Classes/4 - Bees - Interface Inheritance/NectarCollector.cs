using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesInterfaceInheritance
{
    class NectarCollector: Worker, INectarCollector
    {
        public int Nectar { get; set; }

        public string Job
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public NectarCollector(double weightMG)
            : base(new string[] { "Nectar Collector" }, weightMG)
        {

        }

        public void FindFlowers() { }

        public void GatherNectar() { }

        public void ReturnToHive() { }

        void IWorker.DoThisJob(string job, int shifts)
        {
            throw new NotImplementedException();
        }

        public void WorkOneShift()
        {
            throw new NotImplementedException();
        }
    }
}
