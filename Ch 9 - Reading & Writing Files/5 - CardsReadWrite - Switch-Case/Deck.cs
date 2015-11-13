using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
        public Deck(string filename) {
            cards = new List<Card>();
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    bool invalidCard = false;
                    string nextCard = reader.ReadLine();
                    string[] cardparts = nextCard.Split(new char[] { ' ' });

                    Values value = Values.Ace;
                    switch (cardparts[0])
                    {
                        case "Ace": value = Values.Ace; break;
                        case "Two": value = Values.Two; break;
                        case "Three": value = Values.Three; break;
                        case "Four": value = Values.Four; break;
                        case "Five": value = Values.Five; break;
                        case "Six": value = Values.Six; break;
                        case "Seven": value = Values.Seven; break;
                        case "Eight": value = Values.Eight; break;
                        case "Nine": value = Values.Nine; break;
                        case "Ten": value = Values.Ten; break;
                        case "Jack": value = Values.Jack; break;
                        case "Queen": value = Values.Queen; break;
                        case "King": value = Values.King; break;
                        default: invalidCard = true;
                            break;
                    }

                    Suits suit = Suits.Clubs;
                    switch (cardparts[2])
                    {
                        case "Spades": suit = Suits.Spades; break;
                        case "Clubs": suit = Suits.Clubs; break;
                        case "Hearts": suit = Suits.Hearts; break;
                        case "Diamonds": suit = Suits.Diamonds; break;
                        default: invalidCard = true;
                            break;
                    }

                    if (!invalidCard)
                    {
                        cards.Add(new Card(suit, value));
                    }
                }
            }
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

        public void WriteCards(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                for (int i = 0; i < cards.Count; i++)
                {
                    writer.WriteLine(cards[i].Name);
                }
            }
        }

    }
}
