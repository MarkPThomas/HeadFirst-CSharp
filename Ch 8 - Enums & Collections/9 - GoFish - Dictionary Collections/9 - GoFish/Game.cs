using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    class Game
    {
        private List<Player> players;
        private Dictionary<Values, Player> books;
        private Deck stock;
        private TextBox textBoxOnForm;

        public Game(string playerName, IEnumerable<string> opponentNames, TextBox textBoxOnForm)
        {
            Random random = new Random();
            this.textBoxOnForm = textBoxOnForm;
            players = new List<Player>();
            players.Add( new Player(playerName, random, textBoxOnForm));
            foreach (string player in opponentNames)   
            {
                players.Add(new Player(player, random, textBoxOnForm));
            }
            books = new Dictionary<Values,Player>();
            stock = new Deck();
            Deal();
            players[0].SortHand();
        }

        private void Deal()
        {
            stock.Shuffle();

            foreach (Player player in players)
            {
                DrawHand(player);
                PullOutBooks(player);
            }
        }

        private void DrawHand(Player player)
        {
            for (int i = 0; i < Math.Min(5, stock.Count); i++)
            {
                player.TakeCard(stock.Deal());
            }
        }

        public bool PlayOneRound(int selectedPlayerCard)
        {   
            for (int playerIndex = 0; playerIndex < players.Count; playerIndex++)
            {              
                if (playerIndex == 0)
                {
                    // Ask for the human player's selected value
                    Values valuePeeked = players[0].Peek(selectedPlayerCard).Value;
                    players[0].AskForACard(players, 0, stock, valuePeeked);
                }
                else
                {
                    // Other players ask for their values
                    players[playerIndex].AskForACard(players, playerIndex, stock);
                }
                     
                if (PullOutBooks(players[playerIndex]))
                {
                    textBoxOnForm.Text += players[playerIndex].Name + " drew a new hand." + Environment.NewLine;
                    DrawHand(players[playerIndex]);
                }

                // Sort the human player's hand
                players[0].SortHand();

                if (stock.Count == 0)
                {
                    textBoxOnForm.Text = "The stock is out of cards. Game over!" + Environment.NewLine;
                    return true;
                }
            }
            return false;
        }

        public bool PullOutBooks(Player player)
        {
            IEnumerable<Values> booksPulled = player.PullOutBooks();
            foreach (Values value in booksPulled)
            {
                books.Add(value, player);
            }

            if (player.CardCount == 0)
            {
                return true;   
            }
            else
            {
                return false;
            }
        }

        public string DescribeBooks()
        {
            string whoHasWhichBooks = "";

            foreach (Values value in books.Keys)
            {
                Player player = books[value];
                whoHasWhichBooks += player.Name + " has a book of " + Card.Plural(value) + "." + Environment.NewLine;
            }

            return whoHasWhichBooks;
        }

        public string GetWinnerName()
        {
            Dictionary<string, int> winners = new Dictionary<string, int>();

            foreach (Values value in books.Keys)
            {
                string name = books[value].Name;
                if (winners.ContainsKey(name))
                {
                    winners[name]++;
                }
                else
                {
                    winners.Add(name, 1);
                }
            }

            int mostBooks = 0;
            foreach (string name in winners.Keys)
            {
                if (winners[name] > mostBooks)
                {
                    mostBooks = winners[name];
                }
            }

            bool tie = false;
            string winnerList = "";
            foreach (string name in winners.Keys)
            {
                if (winners[name] == mostBooks)
                {
                    if (!String.IsNullOrEmpty(winnerList))
                    {
                        winnerList += " and ";
                        tie = true;
                    }
                    winnerList += name;
                }
            }
            winnerList += " with " + mostBooks + " book";
            if (mostBooks > 1)
            {
                winnerList += "s";
            }
            winnerList += ".";
            if (tie)
            {
                return "A tie between " + winnerList;
            }
            else
            {
                return winnerList;
            }
        }

        public IEnumerable<string> GetPlayerCardNames()
        {
            return players[0].GetCardNames();
        }

        public string DescribePlayerHands()
        {
            string description = "";
            for (int i = 0; i < players.Count; i++)
            {
                description += players[i].Name + " has " + players[i].CardCount;
                if (players[i].CardCount == 1)
                {
                    description += " card." + Environment.NewLine;
                }
                else
                {
                    description += " cards." + Environment.NewLine;
                }
            }
            description += "The stock has " + stock.Count + " cards left.";
            return description;
        }

    }
}
