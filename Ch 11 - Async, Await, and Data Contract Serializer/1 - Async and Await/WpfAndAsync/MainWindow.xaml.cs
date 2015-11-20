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
using System.Threading;
using System.Windows.Threading;

namespace WpfAndAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromSeconds(0.1);
        }

        int i = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            progress.Text = (i++).ToString();
        }

        private async void countButton_Click(object sender, RoutedEventArgs e)
        {
            countButton.IsEnabled = false;
            timer.Start();
            if (useAwaitAsync.IsChecked == true)
            {
                await LongTaskAsync();
            }
            else
            {
                LongTask();
            }
        }

        private void LongTask()
        {
            Thread.Sleep(5000);
            timer.Stop();
            progress.Text = i.ToString();
            //UpdateLayout();
            countButton.IsEnabled = true;
        }

        private async Task LongTaskAsync()
        {
            await Task.Delay(5000);
            timer.Stop();
            countButton.IsEnabled = true;
        }

        private void doSomethingElse_Checked(object sender, RoutedEventArgs e)
        {
            otherButton.IsEnabled = false;
        }

        private void doSomethingElse_Unchecked(object sender, RoutedEventArgs e)
        {
            otherButton.IsEnabled = true;
        }

        private void otherButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SQUIRREL!!!");
        }

        private void useAwaitAsync_Checked(object sender, RoutedEventArgs e)
        {
            if (progress != null)
            {
                progress.Text = "";
                countButton.IsEnabled = true;
            }
        }

        private void useAwaitAsync_Unchecked(object sender, RoutedEventArgs e)
        {
            if (progress != null)
            {
                progress.Text = "";
                countButton.IsEnabled = true;
            }
        }
    }
}
