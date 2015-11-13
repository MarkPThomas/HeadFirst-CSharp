using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoFish
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
            InitializeNewGame();
        }

        private void InitializeNewGame()
        {
            buttonStart.Enabled = true;
            textName.Enabled = true;

            buttonAsk.Enabled = false;
            listHand.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textName.Text))
            {
                MessageBox.Show("Please enter your name", "Can't start the game yet");
            }
            else
            {
                game = new Game(textName.Text, new List<String> { "Joe", "Bob" }, textProgress);
                buttonStart.Enabled = false;
                textName.Enabled = false;
                buttonAsk.Enabled = true;
                listHand.Enabled = true;
                textProgress.Text = "";
                textBooks.Text = "";

                UpdateForm();
            }
        }

        private void UpdateForm()
        {
            listHand.Items.Clear();
            foreach (String cardName in game.GetPlayerCardNames())
            {
                listHand.Items.Add(cardName);
            }
            textBooks.Text = game.DescribeBooks();
            textProgress.Text += game.DescribePlayerHands() + Environment.NewLine;
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
        }

        private void buttonAsk_Click(object sender, EventArgs e)
        {
            textProgress.Text = "";
            if (listHand.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a card");
                return;
            }

            if (game.PlayOneRound(listHand.SelectedIndex))
            {
                textProgress.Text += "The winner is... " + game.GetWinnerName();
                textBooks.Text = game.DescribeBooks();

                InitializeNewGame();
            }
            else
            {
                UpdateForm();
            }
        }
    }
}
