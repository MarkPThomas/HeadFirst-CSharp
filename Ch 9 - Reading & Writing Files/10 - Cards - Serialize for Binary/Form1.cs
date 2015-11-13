using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CardsSerializeDeserialize
{
    public partial class Form1 : Form
    {
        private const string fileDeck1 = "Deck1.dat";
        private const string fileDeck2 = "Deck2.dat";
        private const string fileThreeClubs = "three-c.dat";
        private const string fileSixHearts = "six-h.dat";
        private const string fileKingSpades = "king-s.dat";

        Random random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private Deck RandomDeck(int number)
        {
            Deck myDeck = new Deck(new Card[] { });
            for (int i = 0; i < number; i++)
            {
                myDeck.Add(new Card(
                    (Suits)random.Next(4),
                    (Values)random.Next(1, 14)));
            }
            return myDeck;
        }

        private void DealCards(Deck deckToDeal, string title)
        {
            Console.WriteLine(title);
            while (deckToDeal.Count > 0)
            {
                Card nextCard = deckToDeal.Deal(0);
                Console.WriteLine(nextCard.Name);
            }
            Console.WriteLine("------------------");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Deck deckToWrite = RandomDeck(5);
            using (Stream output = File.Create(fileDeck1))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, deckToWrite);
            }
            DealCards(deckToWrite, "What I just wrote to the file:");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead(fileDeck1))   
            {
                BinaryFormatter bf = new BinaryFormatter();
                Deck deckFromFile = (Deck)bf.Deserialize(input);
                DealCards(deckFromFile, "What I read from the file:");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (Stream output = File.Create(fileDeck2))
            {
                BinaryFormatter bf = new BinaryFormatter();
                for (int i = 0; i <= 5 ; i++)
                {
                    Deck deckToWrite = RandomDeck(random.Next(1,10));
                    bf.Serialize(output, deckToWrite);
                    DealCards(deckToWrite, "Deck #" + i + " written:");
                }
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (Stream input = File.OpenRead(fileDeck2))
            {
                BinaryFormatter bf = new BinaryFormatter();
                for (int i = 0; i <= 5; i++)
                {
                    Deck deckToRead = (Deck)bf.Deserialize(input);
                    DealCards(deckToRead, "Deck #" + i + " read:");
                }
            }
        }

        private void serializeThreeOfClubs_Click(object sender, EventArgs e)
        {
            Card threeClubs = new Card(Suits.Clubs, Values.Three);

            using (Stream output = File.Create(fileThreeClubs))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, threeClubs);
            }
        }

        private void serializeSixOfHearts_Click(object sender, EventArgs e)
        {
            Card sixHearts = new Card(Suits.Hearts, Values.Six);

            using (Stream output = File.Create(fileSixHearts))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output, sixHearts);
            }
        }

        private void compareBinary_Click(object sender, EventArgs e)
        {
            byte[] firstFile = File.ReadAllBytes(fileThreeClubs);
            byte[] secondFile = File.ReadAllBytes(fileSixHearts);
            for (int i = 0; i < firstFile.Length; i++)
            {
                if (firstFile[i] != secondFile[i])
                {
                    Console.WriteLine("Byte #{0}: {1} versus {2}",
                        i, firstFile[i], secondFile[i]);
                }
            }
        }

        private void binaryKingOfSpades_Click(object sender, EventArgs e)
        {
            byte[] firstFile = File.ReadAllBytes(fileThreeClubs);
            byte[] secondFile = File.ReadAllBytes(fileSixHearts);

            // First byte that differed in method "compareBinary"
            firstFile[315] = (byte)Suits.Spades;

            // Second byte that differed in method "compareBinary"
            firstFile[375] = (byte)Values.King;

            File.Delete(fileKingSpades);
            File.WriteAllBytes(fileKingSpades, firstFile);

            using (Stream input = File.OpenRead(fileKingSpades))
            {
                BinaryFormatter bf = new BinaryFormatter();
                Card cardToRead = (Card)bf.Deserialize(input);
                Console.WriteLine("Card {0}", cardToRead.Name);
            }
        }
    }
}
