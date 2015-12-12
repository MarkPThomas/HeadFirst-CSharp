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
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace AnimatedBee.View
{
    /// <summary>
    /// Interaction logic for FlyingBees.xaml
    /// </summary>
    public partial class FlyingBees : Window
    {
        public FlyingBees()
        {
            InitializeComponent();

            //List<string> imageNames = new List<string>();
            //imageNames.Add("Bee animation 1.png");
            //imageNames.Add("Bee animation 2.png");
            //imageNames.Add("Bee animation 3.png");
            //imageNames.Add("Bee animation 4.png");

            //firstBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(50));
            //secondBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(10));
            //thirdBee.StartAnimation(imageNames, TimeSpan.FromMilliseconds(100));

            //Storyboard storyboard = new Storyboard();
            //DoubleAnimation animation = new DoubleAnimation();
            //Storyboard.SetTarget(animation, firstBee);
            //Storyboard.SetTargetProperty(animation, new PropertyPath(Canvas.LeftProperty));

            //// Note that the animation applies to the Canvas.Left property
            //animation.From = 50;
            //animation.To = 450;
            //animation.Duration = TimeSpan.FromSeconds(3);
            //animation.RepeatBehavior = RepeatBehavior.Forever;
            //animation.AutoReverse = true;

            //storyboard.Children.Add(animation);
            //storyboard.Begin();
        }
    }
}
