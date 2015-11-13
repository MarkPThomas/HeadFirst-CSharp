using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanetMission
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mars mars = new Mars();
            MessageBox.Show(mars.FuelNeeded());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Venus venus = new Venus();
            MessageBox.Show(venus.FuelNeeded());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // The lines below will not compile for an abstract class.
            // If the class were not an abstract class, then there will be a divide-by-zero error
            // as the class does not have the fuel property initialized.

            // This class, as an abstract class, can be inherited by `Mars` and `Venus` but can never
            // itself be instantiated.
            
            // PlanetMission planetMission = new PlanetMission();
            // MessageBox.Show(planetMission.FuelNeeded());
        }
    }
}
