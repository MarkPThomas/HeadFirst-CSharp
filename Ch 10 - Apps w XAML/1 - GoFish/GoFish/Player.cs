using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GoFish
{
    class Player
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        private Random random;
        private Deck cards;
        private ScrollViewer textBoxOnForm;

        public Player(String name, Random random, ScrollViewer textBoxOnForm)
        {
            this.name = name;
            this.random = random;
            this.textBoxOnForm = textBoxOnForm;
            this.cards = new Deck(new Card[] { });

            textBoxOnForm.Content += name + " has just joined the game." + Environment.NewLine;
        }

        public IEnumerable<Values> PullOutBooks()
        {
            List<Values> books = new List<Values>();
            for (int i = 1; i < 14; i++)
            {
                Values value = (Values)i;
                int howMany = 0;
                for (int card = 0; card < cards.Count; card++)
                {
                    if (cards.Peek(card).Value == value)
                    {
                        howMany++;
                    }
                }
                if (howMany == 4)
                {
                    books.Add(value);
                    cards.PullOutValues(value);
                }
            }
            return books;
        }

        public Values GetRandomValue()
        {
            Card randomCard = cards.Peek(random.Next(cards.Count));
            return randomCard.Value;
        }

        public Deck DoYouHaveAny(Values value)
        {
            Deck cardsIHave = cards.PullOutValues(value);

            textBoxOnForm.Content += name + " has " + cardsIHave.Count + " " + Card.Plural(value) + "." + Environment.NewLine ;

            return cardsIHave;
        }

        public void AskForACard(IEnumerable<Player> players, int myIndex, Deck stock)
        {
            List<Player> _players = (List<Player>)players;
            
            // Round is only played if the stock still has cards.
            if (stock.Count > 0)
            {
                // Player asking must have at least one card.'Player asking must have at least one card.
                if (cards.Count == 0)
                {
                    cards.Add(stock.Deal());
                }
                AskForACard(players, myIndex, stock, GetRandomValue());

                // As long as the stock still has cards after the last move, if the human player must have at least one card.
                // This is needed for the next round to be started. Cases of the AIs running out of cards is handled when they are asking for cards, above.
                if (stock.Count > 0 && _players[0].CardCount == 0)
                {
                    _players[0].cards.Add(stock.Deal());
                }    
            }
            
        }
        public void AskForACard(IEnumerable<Player> players, int myIndex, Deck stock, Values value)
        {
            List<Player> _players = (List<Player>)players;

            textBoxOnForm.Content +=  name + " asks if anyone has a " + value + "." + Environment.NewLine;

            int cardsAdded = 0;
            for (int playerIndex = 0; playerIndex < _players.Count; playerIndex++)
            {
                if (playerIndex != myIndex)
                {
                    Deck cardsGiven = _players[playerIndex].DoYouHaveAny(value);
                    if (cardsGiven.Count > 0)
                    {
                        while (cardsGiven.Count > 0)
                        {
                            cards.Add(cardsGiven.Deal());
                            cardsAdded++;
                        }
                    }
                }
            }
            textBoxOnForm.Content += Environment.NewLine;

            if (cardsAdded == 0 && stock.Count > 0)
            {
                textBoxOnForm.Content += name + " has to draw from the stock." + Environment.NewLine;
                cards.Add(stock.Deal());
            }
        }

        public int CardCount
        {
            get
            {
                return cards.Count;
            }
        }

        public void TakeCard(Card card)
        {
            cards.Add(card);
        }       

        public IEnumerable<string> GetCardNames()
        {
            return cards.GetCardNames();
        }

        public Card Peek(int cardNumber)
        {
            return cards.Peek(cardNumber);
        }

        public void SortHand()
        {
            cards.SortByValue();
        }
    }
}
