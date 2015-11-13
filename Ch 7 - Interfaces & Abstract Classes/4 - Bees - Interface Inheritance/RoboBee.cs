using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeesInterfaceInheritance
{
    class RoboBee : Robot, IWorker
    {
        private int shiftsToWork;
        private int shiftsWorked;
        public int ShiftsLeft
        {
            get
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        public string Job { get; private set; }



        public void DoThisJob(string job, int shifts)
        {
            throw new NotImplementedException();
        }

        public void WorkOneShift()
        {
            throw new NotImplementedException();
        }
    }
}
