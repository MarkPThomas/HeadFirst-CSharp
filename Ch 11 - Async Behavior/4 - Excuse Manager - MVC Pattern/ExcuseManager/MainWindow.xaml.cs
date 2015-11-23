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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExcuseManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ExcuseManager excuseManager;
        public MainWindow()
        {
            InitializeComponent();
            excuseManager = FindResource("excuseManager") as ExcuseManager;

            menu.Height = 10;
            btnSave.IsEnabled = false;
            btnRandomExcuse.IsEnabled = false;
        }

        #region Form Behavior

        private void AnimateStackPanel(StackPanel myStackPanel)
        {
            int maxHeight = (int)btnNewExcuse.ActualHeight + 10;  //60;
            int minHeight = 10;
            int duration = 200;

            if (myStackPanel.Height != minHeight && myStackPanel.Height != maxHeight) { return; }

            Duration myDuration = new Duration(TimeSpan.FromMilliseconds(duration));
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();

            if (myStackPanel.Height == minHeight)
            {
                myDoubleAnimation = new DoubleAnimation()
                {
                    From = minHeight,
                    To = maxHeight,
                    Duration = myDuration
                };
            }
            else if (myStackPanel.Height == maxHeight)
            {
                myDoubleAnimation = new DoubleAnimation()
                {
                    From = maxHeight,
                    To = minHeight,
                    Duration = myDuration
                };
            }
            Storyboard myStoryBoard = new Storyboard()
            {
                Duration = myDuration,
            };
            myStoryBoard.Children.Add(myDoubleAnimation);
            Storyboard.SetTarget(myDoubleAnimation, myStackPanel);
            Storyboard.SetTargetProperty(myDoubleAnimation, new PropertyPath("(Height)"));
            myStoryBoard.Begin();
        }

        #endregion

        #region Form Controls

        private void menu_MouseEnter(object sender, MouseEventArgs e)
        {
            AnimateStackPanel(menu);
        }

        private void menu_MouseLeave(object sender, MouseEventArgs e)
        {
            AnimateStackPanel(menu);
        }

        private void btnOpen_MouseDown(object sender, MouseButtonEventArgs e)
        {
            excuseManager.OpenExcuseAsync();
        }

        private void btnSave_MouseDown(object sender, MouseButtonEventArgs e)
        {
            excuseManager.SaveCurrentExcuseAsync();
        }

        private void btnNewExcuse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            excuseManager.NewExcuseAysnc();
        }

        private void btnSaveAs_MouseDown(object sender, MouseButtonEventArgs e)
        {
            excuseManager.SaveCurrentExcuseAsAsync();
        }

        private void btnRandomExcuse_MouseDown(object sender, MouseButtonEventArgs e)
        {
            excuseManager.OpenRandomExcuseAsync();
        }

        private  void btnFolder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bool folderChosen = excuseManager.ChooseNewFolder();
            if (folderChosen)
            {
                btnSave.IsEnabled = true;
                btnRandomExcuse.IsEnabled = true;
            }
        }

        #endregion
    }
}
