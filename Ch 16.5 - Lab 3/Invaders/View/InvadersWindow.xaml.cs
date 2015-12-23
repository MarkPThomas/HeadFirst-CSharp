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
using Invaders.ViewModel;

namespace Invaders.View
{
    /// <summary>
    /// Interaction logic for Invaders.xaml
    /// </summary>
    public partial class InvadersWindow : Window
    {
        private InvadersViewModel viewModel;

        public InvadersWindow()
        {
            InitializeComponent();

            viewModel = FindResource("viewModel") as InvadersViewModel;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdatePlayAreaSize(new Size(e.NewSize.Width, e.NewSize.Height - 160));
        }


        private void playArea_Loaded(object sender, RoutedEventArgs e)
        {
            UpdatePlayAreaSize(playArea.RenderSize);
        }

        private void UpdatePlayAreaSize(Size newPlayAreaSize)
        {
            // Maintain 4:3 aspect ratio
            double targetWidth;
            double targetHeight;
            if (newPlayAreaSize.Width > newPlayAreaSize.Height)
            {
                targetWidth = newPlayAreaSize.Height * 4 / 3;
                targetHeight = newPlayAreaSize.Height;
                double leftRightMargin = (newPlayAreaSize.Width - targetWidth) / 2;
                playArea.Margin = new Thickness(leftRightMargin, 0, leftRightMargin, 0);
            }
            else
            {
                targetHeight = newPlayAreaSize.Width * 3 / 4;
                targetWidth = newPlayAreaSize.Width;
                double topBottomMargin = (newPlayAreaSize.Height - targetHeight) / 2;
                playArea.Margin = new Thickness(topBottomMargin, 0, topBottomMargin, 0);
            }

            playArea.Width = targetWidth;
            playArea.Height = targetHeight;
            viewModel.PlayAreaSize = new Size(targetWidth, targetHeight);
        }


        private void Window_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            if (e.DeltaManipulation.Translation.X < -1)
            {
                viewModel.LeftGestureStarted();
            }
            else if (e.DeltaManipulation.Translation.X > 1)
            {
                viewModel.RightGestureStarted();
            }
        }

        private void Window_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            viewModel.LeftGestureCompleted();
            viewModel.RightGestureCompleted();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            viewModel.KeyDown(e);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            viewModel.KeyUp(e);
        }
    }
}
