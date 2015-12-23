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

namespace Invaders.View
{
    /// <summary>
    /// Interaction logic for BigStar.xaml
    /// </summary>
    public partial class BigStar : UserControl
    {
        public BigStar()
        {
            InitializeComponent();
        }

        public void SetFill(SolidColorBrush solidColorBrush)
        {
            polygon.Fill = solidColorBrush;
        }
    }
}
