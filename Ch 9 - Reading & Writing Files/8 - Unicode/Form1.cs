using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Unicode
{
    public partial class Form1 : Form
    {
        private const string EUREKA_FILENAME = "eureka.txt";
        private const string SHALOM_FILENAME = "shalom.txt";
        private const string EUREKA_SHALOM_FILENAME = "eureka-shalom.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void writeEureka_Click(object sender, EventArgs e)
        {
            File.WriteAllText(EUREKA_FILENAME, "Eureka!");
            byte[] eurekaBytes = File.ReadAllBytes(EUREKA_FILENAME);
            foreach (byte b in eurekaBytes)
            {
                // Write to console in bytes
                Console.WriteLine("{0}", b);
            }
            Console.WriteLine();
        }

        private void bytesAsHexNumbers_Click(object sender, EventArgs e)
        {
            File.WriteAllText(EUREKA_FILENAME, "Eureka!");
            byte[] eurekaBytes = File.ReadAllBytes(EUREKA_FILENAME);
            foreach (byte b in eurekaBytes)
            {
                // Write to console in Hex
                Console.WriteLine("{0:x2}", b);
            }
            Console.WriteLine();
        }

        private void writeInHebrew_Click(object sender, EventArgs e)
        {
            File.WriteAllText(SHALOM_FILENAME, "לשלום!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.WriteAllText(EUREKA_FILENAME, "Eureka!");
            byte[] eurekaBytes = File.ReadAllBytes(EUREKA_FILENAME);

            File.WriteAllText(SHALOM_FILENAME, "לשלום!");
            byte[] shalomBytes = File.ReadAllBytes(SHALOM_FILENAME);

            using (StreamWriter writer = new StreamWriter(EUREKA_SHALOM_FILENAME))
            {
                writer.WriteLine("Eureka!");
                writer.WriteLine();
                writer.WriteLine("In bytes:");
                foreach (byte b in eurekaBytes)
                {
                    // Write to console in bytes
                    writer.WriteLine("{0}", b);
                }
                writer.WriteLine();
                writer.WriteLine("In Hex:");
                foreach (byte b in eurekaBytes)
                {
                    // Write to console in Hex
                    writer.WriteLine("{0:x2}", b);
                }

                writer.WriteLine();
                writer.WriteLine("לשלום! (Shalom!)");
                writer.WriteLine();
                writer.WriteLine("In bytes:");
                foreach (byte b in shalomBytes)
                {
                    // Write to console in bytes
                    writer.WriteLine("{0}", b);
                }
                writer.WriteLine();
                writer.WriteLine("In Hex:");
                foreach (byte b in shalomBytes)
                {
                    // Write to console in Hex
                    writer.WriteLine("{0:x2}", b);
                }
            }
        }
    }
}
