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
    /// Interaction logic for AnalogStopwatch.xaml
    /// </summary>
    public partial class AnalogStopwatch : UserControl
    {
        ViewModel.StopwatchViewModel viewModel;

        public AnalogStopwatch()
        {
            InitializeComponent();

            viewModel = FindResource("viewModel") as ViewModel.StopwatchViewModel;
            AddMarkings();
        }

        private void AddMarkings()
        {
            for (int i = 0; i < 360; i+=3)
            {
                Rectangle rectangle = new Rectangle();
                // Modulo operator marks hours thicker than minutes. i % 30 only returns 0 if i is divisible by 30
                rectangle.Width = (i % 30 == 0) ? 3 : 1;
                rectangle.Height = 15;
                rectangle.Fill = new SolidColorBrush(Colors.Black);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);

                TransformGroup transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform() { Y = -140 });
                transforms.Children.Add(new RotateTransform() { Angle = i });

                rectangle.RenderTransform = transforms;
                baseGrid.Children.Add(rectangle);
            }
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
