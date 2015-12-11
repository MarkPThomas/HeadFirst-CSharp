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

namespace Stopwatch.View
{
    /// <summary>
    /// Interaction logic for BasicStopwatch.xaml
    /// </summary>
    public partial class BasicStopwatch : UserControl
    {
        ViewModel.StopwatchViewModel viewModel;

        public BasicStopwatch()
        {
            InitializeComponent();

            viewModel = FindResource("viewModel") as ViewModel.StopwatchViewModel;
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Start();
        }

        private void stopButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Stop();
        }

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Reset();
        }

        private void lapButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.Lap();
        }
    }
}
