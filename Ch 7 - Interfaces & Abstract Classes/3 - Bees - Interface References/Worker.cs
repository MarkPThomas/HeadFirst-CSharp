using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeesInterfaceReference
{
    class Worker : Bee
    {
        public Worker(string[] jobsICanDo, double weightMG)
            : base(weightMG)
        {
            this.jobsICanDo = jobsICanDo;
        }

        public int ShiftsLeft
        {
            get 
            {
                return shiftsToWork - shiftsWorked;
            }
        }

        private string currentJob = "";
        public string CurrentJob
        {
            get
            {
                return currentJob;
            }
        }

        private string[] jobsICanDo;
        private int shiftsToWork;
        private int shiftsWorked;

        public bool DoThisJob(string job, int numberOfShifts)
        {
            if (!String.IsNullOrEmpty(CurrentJob))
                return false;
            for (int i = 0; i < jobsICanDo.Length; i++)
                if (jobsICanDo[i] == job)
                {
                    currentJob = job;
                    this.shiftsToWork = numberOfShifts;
                    shiftsWorked = 0;
                    return true;
                }
                return false;
        }

        public bool DidYouFinish()
        {
            if (String.IsNullOrEmpty(currentJob))
                return false;
            shiftsWorked++;
            if (shiftsWorked > shiftsToWork)
            {
                shiftsWorked = 0;
                shiftsToWork = 0;
                currentJob = "";
                return true;
            }
            else
                return false;
        }

        private const double honeyUnitsPerShiftWorked = 0.65;
        public override double HoneyConsumptionRate()
        {
            double honeyConsumptionRate = base.HoneyConsumptionRate();
            honeyConsumptionRate += honeyUnitsPerShiftWorked * shiftsWorked;
            return honeyConsumptionRate;
        }
    }
}
