using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlanning
{
    class DinnerParty
    {
        public const decimal CostOfFoodPerPerson = 25;
        public int NumberOfPeople{ get; set; }
        public bool FancyDecorations{ get; set; }
        public bool HealthyOption{ get; set; }

        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecorations;
            HealthyOption = healthyOption;
        }

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

        private decimal CalculateCostOfBeveragesPerPerson()
        {
            decimal costOfBeveragesPerPerson;
            if (HealthyOption)
	        {
		        costOfBeveragesPerPerson = 5.00M;
	        }
            else
            {
                costOfBeveragesPerPerson = 20.00M;
            }
            return costOfBeveragesPerPerson;
        }

        public decimal Cost
        {
            get {
                decimal totalCost = CalculateCostOfDecorations();
                totalCost += ((CalculateCostOfBeveragesPerPerson() +
                                CostOfFoodPerPerson) * NumberOfPeople);

                if (HealthyOption)
	            {
		            totalCost *= 0.95M;
	            }
                return totalCost;
            }
        }

    }
}
