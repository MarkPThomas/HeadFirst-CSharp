using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeehiveManagement
{
    class Nectar : IDisposable
    {
        private double amount;
        private BeeHive hive;
        private Stream hiveLog;

        public Nectar(double amount, BeeHive hive, Stream hiveLog)
        {
            this.amount = amount;
            this.hive = hive;
            this.hiveLog = hiveLog;
        }

        // One guide for implementation is that this method can be called multiple times without side effects.
        // Below is always called automatically at the end of a 'Using' statement.
        public void Dispose()
        {
            if (amount > 0)
            {
                hive.Add(amount);
                hive.WriteLog(hiveLog, amount + " mg nectar added to the hive");
                amount = 0;
                MessageBox.Show("Nectar disposed.");
            }
        }
    }
}
