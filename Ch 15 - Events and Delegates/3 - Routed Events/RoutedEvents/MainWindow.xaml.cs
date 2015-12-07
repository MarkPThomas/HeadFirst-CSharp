using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RoutedEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<string> outputItems = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();

            output.ItemsSource = outputItems;
        }

        // A routed event first fires te event handler for the control that originates the event,
        // and then bubbles up through the control hierarchy until it hits the top -
        // or an event handler sets e.handled to true.

        // If sender == e.Original source, then the current event handler is the event that started
        // the event bubbling. If not, then the event was caused by a child event.

        private void grayRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource)
            {
                outputItems.Clear();
            }
            outputItems.Add("The rectangle was pressed.");
            if (rectangleSetsHandled.IsChecked == true)
            {
                e.Handled = true;
            }

        }

        private void Ellipse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource)
            {
                outputItems.Clear();
            }
            outputItems.Add("The ellipse was pressed.");
            if (ellipseSetsHandled.IsChecked == true)
            {
                e.Handled = true;
            }
        }

        private void grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource)
            {
                outputItems.Clear();
            }
            outputItems.Add("The grid was pressed.");
            if (gridSetsHandled.IsChecked == true)
            {
                e.Handled = true;
            }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource)
            {
                outputItems.Clear();
            }
            outputItems.Add("The border was pressed.");
            if (borderSetsHandled.IsChecked == true)
            {
                e.Handled = true;
            }
        }

        private void panel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == e.OriginalSource)
            {
                outputItems.Clear();
            }
            outputItems.Add("The panel was pressed.");
        }

        private void UpdateHitTestButton(object sender, RoutedEventArgs e)
        {
            grayRectangle.IsHitTestVisible = (bool)newHitTestVisibleValue.IsChecked;
        }
    }
}
