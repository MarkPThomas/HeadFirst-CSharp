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
            game = FindResource("game") as Game;
        }

        private void AskForACard()
        {
            if (cards.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a card");
                return;
            }

            game.PlayOneRound(cards.SelectedIndex);
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(game.PlayerName))
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
            }
            else
            {
                game.StartGame();
            }
        }

        private void askForACard_Click(object sender, RoutedEventArgs e)
        {
            AskForACard();
        }

        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            AskForACard();
        }
    }
}
