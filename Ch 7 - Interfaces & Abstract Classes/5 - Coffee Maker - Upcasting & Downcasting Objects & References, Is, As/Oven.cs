using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    class Oven : Appliance, ICooksFood
    {
        public double Capacity
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public void Preheat() { }
        public void HeatUp() { }
        public void Reheat() { }
    }
}
