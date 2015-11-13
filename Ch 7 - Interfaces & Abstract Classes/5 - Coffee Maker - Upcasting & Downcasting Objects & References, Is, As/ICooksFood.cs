using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appliances
{
    interface ICooksFood
    {
        double Capacity {get; set; }

        void HeatUp();

        void Reheat();
    }
}
