using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void showCard_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int numberBetween0And3 = random.Next(4);
            int numberBetween1And13 = random.Next(1, 14);
        //    int anyRandomInteger = random.Next();

            Card card = new Card((Suits)numberBetween0And3, (Values)numberBetween1And13);
            string cardName = card.Name;

            MessageBox.Show(cardName);
        }
       
    }
}
