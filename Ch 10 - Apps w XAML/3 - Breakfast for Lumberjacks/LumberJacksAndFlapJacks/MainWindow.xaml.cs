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

namespace LumberjacksAndFlapjacks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Queue<Lumberjack> breakfastLine = new Queue<Lumberjack>();

        public MainWindow()
        {
            InitializeComponent();
            RedrawList();
        }

        private void addFlapjacks_Click(object sender, RoutedEventArgs e)
        {
            if (breakfastLine.Count == 0) return;
            Flapjack food  = Flapjack.None;
            string selection = flapJackOrder.SelectionBoxItem.ToString();
            if (selection == "Crispy")
            {
                food = Flapjack.Crispy;
            }
            else if (selection ==  "Checked")
            {
                food = Flapjack.Soggy;
            }
            else if (selection == "Browned")
            {
                food = Flapjack.Browned;
            }
            else if (selection == "Banana")
            {
                food = Flapjack.Banana;
            }

            if (food != Flapjack.None)
            {
                Lumberjack currentLumberjack = breakfastLine.Peek();
                int howManyNumber;
                if (int.TryParse(howMany.Text, out howManyNumber))
                {
                    currentLumberjack.TakeFlapjacks(food, howManyNumber);
                }

                RedrawList();
            }
        }

        private void addLumberjack_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(name.Text)) return;

            breakfastLine.Enqueue(new Lumberjack(name.Text));
            name.Text = "";
            RedrawList();
        }

        private void nextLumberjack_Click(object sender, RoutedEventArgs e)
        {
            if (breakfastLine.Count == 0) return;
            Lumberjack nextLumberjack = breakfastLine.Dequeue();
            nextLumberjack.EatFlapjacks();
            nextInLine.Content = "";
            RedrawList();
        }

        private void RedrawList()
        {
            int queueNumber = 1;
            line.Items.Clear();
            foreach (Lumberjack lumberjack in breakfastLine)
            {
                line.Items.Add(queueNumber + ". " + lumberjack.Name);
                queueNumber++;
            }

            if (breakfastLine.Count == 0)
            {
                spFeedALumberjack.IsEnabled = false;
                nextLumberjack.IsEnabled = false;
                nextInLine.Content = "";
            }
            else
            {
                spFeedALumberjack.IsEnabled = true;
                nextLumberjack.IsEnabled = true;
                Lumberjack currentLumberjack = breakfastLine.Peek();
                nextInLine.Content = currentLumberjack.Name + " has " + currentLumberjack.FlapjackCount + " flapjacks.";
            }
        }
    }
}
