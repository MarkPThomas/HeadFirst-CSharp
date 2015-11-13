using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheSwindlerRevealed
{
    class Program
    {
        static void Main(string[] args)
        {
            string programDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;
            programDirectory = Path.GetDirectoryName(programDirectory);

            SwindlerAction(programDirectory);
            SwindlerLeaked(programDirectory);
        }

        private static void SwindlerAction(string programDirectory)
        {
            StreamWriter sw = new StreamWriter(programDirectory + @"\secret_plan.txt");
            sw.WriteLine("How I'll defeat Captain Amazing");
            sw.WriteLine("Another genius secret plan by The Swindler");
            sw.Write("I'll create an army of clones and ");
            sw.WriteLine("unleash them upon the citizens of Objectville.");

            string location = "the mall";
            for (int number = 0; number <= 6; number++)
            {
                sw.WriteLine("Clone #{0} attacks {1}", number, location);
                if (location == "the mall") { location = "downtown"; }
                else { location = "the mall"; }
            }

            sw.Close();
        }

        private static void SwindlerLeaked(string programDirectory) {
            // string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folder = programDirectory;
            StreamReader reader = new StreamReader(folder + @"\secret_plan.txt");
            StreamWriter writer = new StreamWriter(folder + @"\emailToCaptainAmazing.txt");

            writer.WriteLine("To: CaptainAmazing@objectville.net");
            writer.WriteLine("From: Commissioner@objectville.net");
            writer.WriteLine("Subject: Can you save the day ... again?");
            writer.WriteLine();
            writer.WriteLine("We've discovered the Swindler's plan:");

            while (!reader.EndOfStream)
            {
                string lineFromThePlan = reader.ReadLine();
                writer.WriteLine("The plan -> " + lineFromThePlan);
            }
            writer.WriteLine();
            writer.WriteLine("Can you help us?");

            writer.Close();
            reader.Close();
        }
    }
}
