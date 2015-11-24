using System;
using System.Collections.Generic;
using System.Windows;

namespace BeehiveManagement
{
    public class NectarVat
    {
        public List<NectarUnit> Units { get; set; }
        public bool Emptied { get; internal set; }

        public NectarVat()
        {
            Emptied = false;

            Units = new List<NectarUnit>();
            for (int i = 0; i < 5; i++)
            {
                Units.Add(new NectarUnit());
            }

        }

        internal void Seal()
        {
           MessageBox.Show("Vat sealed.");
        }
    }
}