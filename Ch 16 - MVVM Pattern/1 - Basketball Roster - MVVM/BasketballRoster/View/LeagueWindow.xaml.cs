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
using BasketballRoster.ViewModel;

namespace BasketballRoster.View
{
    /// <summary>
    /// Interaction logic for LeagueWindow.xaml
    /// </summary>
    public partial class LeagueWindow : Window
    {
        private LeagueViewModel leagueViewModel;
        public LeagueWindow()
        {
            InitializeComponent();

            leagueViewModel = FindResource("LeagueViewModel") as LeagueViewModel;
        }
    }
}
