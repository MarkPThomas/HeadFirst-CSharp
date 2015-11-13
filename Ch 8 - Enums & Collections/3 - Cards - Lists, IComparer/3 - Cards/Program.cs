using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Card> Cards = new List<Card>();
            CardComparer_byValue comparer = new CardComparer_byValue();
            int numberOfRandomCards = 10;

            for (int i = 0; i < numberOfRandomCards; i++)
			{
			     int numberBetween0And3 = random.Next(4);
                 int numberBetween1And13 = random.Next(1, 14);

                 Card card = new Card((Suits)numberBetween0And3, 
                                      (Values)numberBetween1And13);
                 Cards.Add(card);
			}

            Console.WriteLine(numberOfRandomCards + " random cards: ");
            foreach (var item in Cards)
            {
                Console.WriteLine(item.Name);
            }

            Cards.Sort(comparer);

            Console.WriteLine("\n\r" + "The same " + numberOfRandomCards + " cards, sorted: ");
            foreach (var item in Cards)
	        {
		         Console.WriteLine(item.Name);
	        }
            
            Console.ReadKey();
        }
    }
}
