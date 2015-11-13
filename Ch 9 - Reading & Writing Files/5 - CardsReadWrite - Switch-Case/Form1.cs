using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TwoDecks
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        public Deck deck1;
        public Deck deck2;
        
        public Form1()
        {
            InitializeComponent();

            ResetDeck(1);
            ResetDeck(2);

            RedrawDeck(1);
            RedrawDeck(2);
        }

        private void moveToDeck2_Click(object sender, EventArgs e)
        {
            int drawnCardDeck1 = deckList1.SelectedIndex;
            Card drawnCard = deck1.Deal(drawnCardDeck1);
            if (drawnCard != null)
            {
                deck2.Add(drawnCard);
                RedrawDeck(1);
                RedrawDeck(2);
            }
        }

        private void moveToDeck1_Click(object sender, EventArgs e)
        {
            if (deckList2.SelectedIndex >=0 && deck2.Count > 0)
            {
                int drawnCardDeck2 = deckList2.SelectedIndex;
                Card drawnCard = deck2.Deal(drawnCardDeck2);
                if (drawnCard != null)
                {
                    deck1.Add(drawnCard);
                    RedrawDeck(1);
                    RedrawDeck(2);
                }
            }

            
        }

        private void reset1_Click(object sender, EventArgs e)
        {
            ResetDeck(1);
            RedrawDeck(1);
        }

        private void reset2_Click(object sender, EventArgs e)
        {
            ResetDeck(2);
            RedrawDeck(2);
        }

        private void shuffle1_Click(object sender, EventArgs e)
        {
            deck1.Shuffle();
            RedrawDeck(1);
        }

        private void shuffle2_Click(object sender, EventArgs e)
        {
            deck2.Shuffle();
            RedrawDeck(2);
        }

        public void ResetDeck(int deckNumber)
        {
            if (deckNumber == 1)
            {
                int numberOfCards = random.Next(1,11);
                List<Card> cards = new List<Card>();
                for (int i = 0; i < numberOfCards; i++)
                {
                    cards.Add(new Card((Suits)random.Next(4), (Values)random.Next(1,14)));
                }
                deck1 = new Deck(cards);
                deck1.Sort();
            }
            else 
            {
                deck2 = new Deck();
            }
        }

        public void RedrawDeck(int deckNumber)
        {
            if (deckNumber == 1)
            {
                deckList1.Items.Clear();
                foreach (string cardName in deck1.GetCardNames())
                {
                    deckList1.Items.Add(cardName);
                }
                labelDeck1.Text = "Deck #1 (" + deck1.Count + " cards)";
            }
            else
            {
                deckList2.Items.Clear();
                foreach (string cardName in deck2.GetCardNames())
                {
                    deckList2.Items.Add(cardName);
                }
                labelDeck2.Text = "Deck #2 (" + deck2.Count + " cards)";
            }
        }
    }
}
