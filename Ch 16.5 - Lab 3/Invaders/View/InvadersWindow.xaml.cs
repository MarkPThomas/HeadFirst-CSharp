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

            double cornerRadius = 10;
            playArea.CornerRadius = new CornerRadius(cornerRadius);
            playArea.Padding = new Thickness(cornerRadius * (1 - Math.Cos(Math.PI / 4)));
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // UpdatePlayAreaSize(new Size(e.NewSize.Width, e.NewSize.Height - gridTitle.ActualHeight));
            viewModel.PlayAreaSize = playArea.RenderSize;
        }


        private void playArea_Loaded(object sender, RoutedEventArgs e)
        {
            // TODO: Play area spills off of screen
            //UpdatePlayAreaSize(playArea.RenderSize);
           viewModel.PlayAreaSize = playArea.RenderSize;
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
                double leftRightMargin = Math.Min(5,(newPlayAreaSize.Width - targetWidth) / 2);
                playArea.Margin = new Thickness(leftRightMargin, 5, leftRightMargin, 5);
            }
            else
            {
                targetHeight = newPlayAreaSize.Width * 3 / 4;
                targetWidth = newPlayAreaSize.Width;
                double topBottomMargin = Math.Min(5,(newPlayAreaSize.Height - targetHeight) / 2);
                playArea.Margin = new Thickness(5, topBottomMargin, 5, topBottomMargin);
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
