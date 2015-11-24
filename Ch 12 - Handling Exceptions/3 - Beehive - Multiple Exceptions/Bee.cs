using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BeehiveManagement
{
    class Bee
    {
        private Stream hiveLogFile;

        public const double HoneyUnitsConsumedPerMg = 0.25;
        public double WeightMg { get; private set; }
        public int UnitsExpected { get; internal set; }

        public Bee(double weightMg)
        {
            WeightMg = weightMg;
        }

        virtual public double HoneyConsumptionRate()
        {
            return WeightMg * HoneyUnitsConsumedPerMg;
        }

        public NectarUnit[] EmptyVat(NectarVat vat)
        {
            NectarUnit[] vatUnits;

            if (vat.Units.Count > 0)
            {
                vatUnits = new NectarUnit[vat.Units.Count];
                for (int i = 0; i < vatUnits.Length; i++)
                {
                    vatUnits[i] = vat.Units[i];
                }
                return vatUnits;
            }
            else
            {
                throw new VatEmptyException("The vat has been emptied!");
            }
        }

        internal void AlertQueen(string message)
        {
            MessageBox.Show("Alerting Queen: \r\n" + message);
        }

        internal void FinishedJob()
        {
            MessageBox.Show("Job is finished!");
        }

        internal void AddLogEntry(Stream hiveLogFile)
        {
            this.hiveLogFile = hiveLogFile;
        }
    }
}
