using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BeehiveManagement
{
    class RoboBee : Robot, IWorker
    {
        private int shiftsToWork = 0;
        private int shiftsWorked = 0;
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
            shiftsToWork = shifts;
            throw new NotImplementedException();
        }

        public void WorkOneShift()
        {
            shiftsWorked++;
            throw new NotImplementedException();
        }
    }
}
