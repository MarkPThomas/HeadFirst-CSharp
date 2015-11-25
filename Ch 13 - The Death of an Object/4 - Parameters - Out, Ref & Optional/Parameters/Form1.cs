using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parameters
{
    public partial class Form1 : Form
    {
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            int a;

            // 'out' arguments don't need to be assigned before being passed into the method.
            double b;
            int c;
            // 'out' must be explicitly written in the method call.
            a = ReturnThreeValues(out b, out c);

            Console.WriteLine("value = {0}, half = {1}, double = {2}", a, b, c);
        }

        public int ReturnThreeValues(out double half, out int twice)
        {
            int value = random.Next(1000);

            // All 'out' parameters must be set in the method.
            half = ((double)value) / 2;
            twice = value * 2;

            return value;
        }


        private void button2_Click(object sender, EventArgs e)
        {
            // 'ref' arguments must be defined before being passed in to the method.
            int q = 100;
            Button b = button2;
            // 'ref' must be explicitly written in the method call
            ModifyAnIntAndButton(ref q, ref b);

            Console.WriteLine("q = {0}, b.Text = {1}", q, b.Text);
        }

        public void ModifyAnIntAndButton(ref int value, ref Button button)
        {
            int i = value;
            i *= 5;

            // 'ref' parameters do not need to be set in the method
            value = i - 3;
            //button = button1;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            // Those values are fine for your average person
            CheckTemperature(101.3);

            // A dog's temperature should be between 100.5 and 102.5 Fahrenheit
            CheckTemperature(101.3, 102.5, 100.5);

            // Bob's temperature is always a little too low, so set tooLow to 95.5
            CheckTemperature(96.2, tooLow: 95.5);
        }

        private void CheckTemperature(double temperature, double tooHigh = 99.5, double tooLow = 96.5)
        {
            if (tooLow < temperature && temperature < tooHigh)
            {
                Console.WriteLine("Feeling good!");
            }
            else
            {
                Console.WriteLine("Uh-oh -- better see a doctor!");
            }
        }

    }
}
