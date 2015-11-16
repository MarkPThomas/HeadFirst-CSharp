using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoFish
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Game game;

        public MainWindow()
        {
            InitializeComponent();
            InitializeNewGame();
        }

        private void InitializeNewGame()
        {
            startButton.IsEnabled = true;
            playerName.IsEnabled = true;

            askForACard.IsEnabled = false;
            cards.IsEnabled = false;
        }


        private void UpdateForm()
        {
            cards.Items.Clear();
            foreach (string cardName in game.GetPlayerCardNames())
            {
                cards.Items.Add(cardName);
            }
            gameBooks.Content = game.DescribeBooks();
            gameProgress.Content += game.DescribePlayerHands() + Environment.NewLine;
            gameProgress.ScrollToEnd();
        }


        private void startButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(playerName.Text))
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
            }
            else
            {
                game = new Game(playerName.Text, new List<string> { "Joe", "Bob" }, gameProgress);
                startButton.IsEnabled = false;
                playerName.IsEnabled = false;
                askForACard.IsEnabled = true;
                cards.IsEnabled = true;
                gameProgress.Content = "";
                gameBooks.Content = "";

                UpdateForm();
            }
        }

        private void askForACard_Click_1(object sender, RoutedEventArgs e)
        {
            gameProgress.Content = "";
            if (cards.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a card");
                return;
            }

            if (game.PlayOneRound(cards.SelectedIndex))
            {
                gameProgress.Content += "The winner is... " + game.GetWinnerName();
                gameBooks.Content = game.DescribeBooks();

                InitializeNewGame();
            }
            else
            {
                UpdateForm();
            }
        }
    }
}
