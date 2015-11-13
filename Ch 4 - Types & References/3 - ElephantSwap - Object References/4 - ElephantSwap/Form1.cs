using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElephantSwap
{
    public partial class Form1 : Form
    {
        Elephant lucinda = new Elephant() { Name="Lucinda", EarSize=33};
        Elephant lloyd = new Elephant() {Name="Lloyd", EarSize=40 };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLloyd_Click(object sender, EventArgs e)
        {
            lloyd.WhoAmI();
        }

        private void btnLucinda_Click(object sender, EventArgs e)
        {
            lucinda.WhoAmI();
        }

        private void btnSwap_Click(object sender, EventArgs e)
        {
            Elephant swap = lloyd;
            lloyd = lucinda;
            lucinda = swap;
            swap = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lloyd.TellMe("Hi", lucinda);
            lloyd.SpeakTo(lucinda, "Hello");

            lloyd = lucinda;
            lloyd.EarSize = 4321;
            lloyd.WhoAmI();
        }
    }
}
