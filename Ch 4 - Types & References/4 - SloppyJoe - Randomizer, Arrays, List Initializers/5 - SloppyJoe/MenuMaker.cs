using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SloppyJoe
{
    class MenuMaker
    {
        public Random Randomizer;

        string[] Meats = { "Roast Beef", "Salami", "Turkey", "Ham", "Pastrami" };
        string[] Condiments = { "Yellow Mustard", "Brown Mustard", "Honey Mustard", "Mayo", "Relish", "French Dressing" };
        string[] Breads = { "Rye", "White", "Wheat", "Pumpernickle", "Italian Bread", "A Roll" };

        public string GetMenuItem()
        {
            string randomMeat = Meats[Randomizer.Next(Meats.Length)];
            string randomCondiment = Condiments[Randomizer.Next(Condiments.Length)];
            string randomBread = Breads[Randomizer.Next(Breads.Length)];

            return randomMeat + " with " + randomCondiment + " on " + randomBread;
        }
    }
}
