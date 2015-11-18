using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace GoFish
{
    class Game : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEvent = PropertyChanged;
            if (propertyChangedEvent != null)
            {
                propertyChangedEvent(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private List<Player> players;
        private Dictionary<Values, Player> books = new Dictionary<Values, Player>();
        private Deck stock = new Deck();

        public bool GameInProgress { get; private set; }
        public bool GameNotStarted { get { return !GameInProgress; } }
        public string PlayerName { get; set; }
        public ObservableCollection<string> Hand { get; private set; }
        public string Books { get { return DescribeBooks(); } }
        public string GameProgress { get; private set; }

        public Game()
        {
            PlayerName = "Ed";
            Hand = new ObservableCollection<string>();
            ResetGame();
        }

        public void UpdateHand()
        {
            Hand.Clear();
            foreach (string cardName in GetPlayerCardNames())
            {
                Hand.Add(cardName);
            }
            AddProgress(DescribePlayerHands());
        }

        public void StartGame()
        {
            ClearProgress();
            GameInProgress = true;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");

            Random random = new Random();

            players = new List<Player>();
            players.Add(new Player(PlayerName, random, this));
            players.Add(new Player("Bob", random, this));
            players.Add(new Player("Joe", random, this));

            Deal();
            players[0].SortHand();

            UpdateHand();
            if (!GameInProgress)
            {
                AddProgress(DescribePlayerHands());
            }
            OnPropertyChanged("Books");
        }

        public void AddProgress(string progress)
        {
            GameProgress = progress +
                Environment.NewLine +
                GameProgress;
            OnPropertyChanged("GameProgress");
        }

        public void ClearProgress()
        {
            GameProgress = string.Empty;
            OnPropertyChanged("GameProgress");
        }

        public void ResetGame()
        {
            GameInProgress = false;
            OnPropertyChanged("GameInProgress");
            OnPropertyChanged("GameNotStarted");

            books = new Dictionary<Values, Player>();
            stock = new Deck();

            Hand.Clear();
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

        public void PlayOneRound(int selectedPlayerCard)
        {
            ClearProgress();
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
                    AddProgress(players[playerIndex].Name + " drew a new hand.");
                    DrawHand(players[playerIndex]);
                }



                // Sort the human player's hand
                players[0].SortHand();

                if (stock.Count == 0)
                {
                    AddProgress("The stock is out of cards. Game over!");
                    AddProgress("The winner is... " + GetWinnerName());
                    ResetGame();
                    return;
                }
            }
            UpdateHand();
        }

        public bool PullOutBooks(Player player)
        {
            IEnumerable<Values> booksPulled = player.PullOutBooks();
            foreach (Values value in booksPulled)
            {
                books.Add(value, player);
            }
            OnPropertyChanged("Books");

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
                    if (!string.IsNullOrEmpty(winnerList))
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
