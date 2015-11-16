using System;
using System.Collections.Generic;
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
    }
}
