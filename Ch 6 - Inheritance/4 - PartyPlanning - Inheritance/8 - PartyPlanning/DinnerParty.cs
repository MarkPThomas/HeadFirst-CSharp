﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyPlanning
{
    class DinnerParty : Party
    {
        public bool HealthyOption{ get; set; }

        public DinnerParty(int numberOfPeople, bool healthyOption, bool fancyDecorations)
        {
            NumberOfPeople = numberOfPeople;
            FancyDecorations = fancyDecorations;
            HealthyOption = healthyOption;
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

        public override decimal Cost
        {
            get {
                decimal totalCost = base.Cost;
                totalCost += (CalculateCostOfBeveragesPerPerson() * NumberOfPeople);

                if (HealthyOption)
	            {
		            totalCost *= 0.95M;
	            }
                return totalCost;
            }
        }

    }
}
