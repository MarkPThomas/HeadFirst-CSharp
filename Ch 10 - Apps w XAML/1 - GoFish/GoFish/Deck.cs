using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoFish
{
    public class Deck
    {
        private List<Card> cards;
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

        public Card Deal()
        {
            return Deal(0);
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
            List<Card> shuffledCards = new List<Card>(cards.Count);

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

        public Card Peek(int cardNumber)
        {
            return cards[cardNumber];
        }

        public bool ContainsValue(Values value)
        {
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    return true;
                }
            }
            return false;
        }

        public Deck PullOutValues(Values value)
        {
            Deck deckToReturn = new Deck(new Card[] { });
            for (int i = cards.Count-1; i >= 0 ; i--)
            {
                if (cards[i].Value == value)
                {
                    deckToReturn.Add(Deal(i));
                }
            }
            return deckToReturn;
        }

        public bool HasBook(Values value)
        {
            int NumberOfCards = 0;
            foreach (Card card in cards)
            {
                if (card.Value == value)
                {
                    NumberOfCards++;
                }
            }
            if (NumberOfCards == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SortByValue()
        {
            cards.Sort(new CardComparer_byValue());
        }
    }
}
