using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlanning
{
    class Party
    {
        public const int CostOfFoodPerPerson = 25;
        public int NumberOfPeople { get; set; }
        public bool FancyDecorations { get; set; }

        private decimal CalculateCostOfDecorations()
        {
            decimal costOfDecorations;
            if (FancyDecorations)
            {
                costOfDecorations = 50.00M + (15.00M * NumberOfPeople);
            }
            else
            {
                costOfDecorations = 30.00M + (7.50M * NumberOfPeople);
            }

            return costOfDecorations;
        }

        public virtual decimal Cost
        {
            get
            {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += (CostOfFoodPerPerson * NumberOfPeople);

                if (NumberOfPeople > 12)
                    totalCost += 100M;

                return totalCost;
            }
        }

    }
}
