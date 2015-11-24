using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeehiveManagement
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queen queen;

        public MainWindow()
        {
            InitializeComponent();

            workerBeeJob.SelectedIndex = 0;
            Worker[] workers = new Worker[4];
            workers[0] = new Worker(new string[] { "Nectar Collector", "Honey Manufacturing" }, 175);
            workers[1] = new Worker(new string[] { "Egg Care", "Baby Bee Tutoring" }, 114);
            workers[2] = new Worker(new string[] { "Hive Maintenance", "Sting Patrol" }, 149);
            workers[3] = new Worker(new string[] {"Nectar Collector", "Honey Manufacturing",
                "Egg Care", "Baby Bee Tutoring", "Hive Maintenance", "Sting Patrol"}, 155);

            queen = new Queen(workers, 275);
        }

        private void assignJob_Click(object sender, RoutedEventArgs e)
        {
            int shiftsNumber;
            bool isNumeric = int.TryParse(shifts.Text, out shiftsNumber);
            if (isNumeric)
            {
                if (queen.AssignWork(workerBeeJob.Text, shiftsNumber) == false)
                    MessageBox.Show("No workers are available to do the job `"
                        + workerBeeJob.Text + "`", "The queen bee says...");
                else
                    MessageBox.Show("The job `" + workerBeeJob.Text + "` will be done in "
                        + shifts.Text + " shifts", "The queen bee says...");
            }
            else
            {
                MessageBox.Show("Please enter an integer in the 'Shifts' textbox.");
            }
        }

        private void nextShift_Click(object sender, RoutedEventArgs e)
        {
            report.Content = queen.WorkTheNextShift();
        }

        private void consumeHoney_Click(object sender, RoutedEventArgs e)
        {
            HoneyDeliverySystem delivery = new HoneyDeliverySystem();
            try
            {
                delivery.FeedHOneyToEggs();
            }
            catch (OutOfHoneyException ex)
            {
                try
                {
                    MessageBox.Show(ex.Message, "Warning: Resetting Hive");
                    Hive.Reset();

                    // Adjust class to not throw another exception
                    delivery.HoneyLevel = 1;
                    delivery.FeedHOneyToEggs();
                }
                catch (OutOfHoneyException ex2)
                {
                    // This should not be triggered
                    MessageBox.Show(ex2.Message, "Still out of honey!");
                }
            }
        }

        private void processNectar_Click(object sender, RoutedEventArgs e)
        {
            NectarVat vat = new NectarVat();
            Bee bee = new Bee(15);
            HiveLog log = new HiveLog();


            ProcessNectar(vat, bee, log);
        }

        private void processNectarVatEmpty_Click(object sender, RoutedEventArgs e)
        {
            NectarVat vat = new NectarVat();
            Bee bee = new Bee(15);
            HiveLog log = new HiveLog();

            vat.Units.Clear();

            ProcessNectar(vat, bee, log);
        }

        private void processNectarLogError_Click(object sender, RoutedEventArgs e)
        {
            NectarVat vat = new NectarVat();
            Bee bee = new Bee(15);
            HiveLog log = new HiveLog();

            bee.UnitsExpected = 2;
            log.ThrowHiveLogException = true;

            ProcessNectar(vat, bee, log);
        }

        private void processNectarIOProblem_Click(object sender, RoutedEventArgs e)
        {
            NectarVat vat = new NectarVat();
            Bee bee = new Bee(15);
            HiveLog log = new HiveLog();

            bee.UnitsExpected = 2;
            log.OpenNonExistingFile = true;

            ProcessNectar(vat, bee, log);
        }

        private void ProcessNectar(NectarVat vat, Bee bee, HiveLog log)
        {
            try
            {
                queen.ProcessNectar(vat, bee, log);
            }
            catch (HiveLogException)
            {
                MessageBox.Show("There was a problem in the hive log.");
            }
        }

        private void usingNectar_Click(object sender, RoutedEventArgs e)
        {
            BeeHive hive = new BeeHive();

            using (Stream hiveLog = File.Create("hiveLog.txt"))
            using (Nectar nectar = new Nectar(20, hive, hiveLog))
            {
                MessageBox.Show("Using Stream and Nectar objects.");
            }
        }
    }
}
