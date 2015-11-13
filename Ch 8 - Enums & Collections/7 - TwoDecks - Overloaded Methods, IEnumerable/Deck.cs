using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoDecks
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private Random random = new Random();

        public Deck()
        {
            cards = new List<Card>();
            for (int suit = 0; suit <= 3; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    cards.Add(new Card((Suits)suit, (Values)value));
                }
            }
        }
        public Deck(IEnumerable<Card> initialCards)
        {
            cards = new List<Card>(initialCards);
        }

        public int Count
        {
            get
            {
                return cards.Count;
            }
        }

        public void Add(Card cardToAdd)
        {
            cards.Add(cardToAdd);
        }

        public Card Deal(int index)
        {
            if (index >= 0 && index < cards.Count)
            {
                Card CardToDeal = cards[index];
                cards.RemoveAt(index);
                return CardToDeal;
            }
            else
            {
                return null;
            }
        }

        public void Shuffle()
        {
            List<Card> shuffledCards = new List<Card>();

            while (cards.Count > 0)
            {
                Card drawnCard = Deal(random.Next(cards.Count));
                shuffledCards.Add(drawnCard);
            } ;

            cards = shuffledCards;
        }

        public IEnumerable<string> GetCardNames()
        {
            // returns a string array that contains each card's name
            string[] CardNames = new string[cards.Count];

            for (int i = 0; i < cards.Count; i++)
            {
                CardNames[i] = cards[i].Name;
            }

            return CardNames;
        }

        public void Sort()
        {
            cards.Sort(new CardComparer_bySuit());
        }


    }
}
