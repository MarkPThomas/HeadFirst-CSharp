using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaseClassConstructor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnBaseClass_Click(object sender, EventArgs e)
        {
            MyBaseClass myBaseClass = new MyBaseClass("Coffee!!!");
        }

        private void btnSubClass_Click(object sender, EventArgs e)
        {
            MySubclass mySubClass = new MySubclass("Candy!!!", 13);
        }
    }
}
