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
using System.Windows.Media.Animation;

namespace Invaders.View
{
    /// <summary>
    /// Interaction logic for AnimatedImage.xaml
    /// </summary>
    public partial class AnimatedImage : UserControl
    {
        private Storyboard invaderShotStoryboard;
        private Storyboard flashStoryboard;

        public AnimatedImage()
        {
            InitializeComponent();
        }

        public void CreateFlashStoryBoard(TimeSpan interval)
        {
            flashStoryboard = new Storyboard();
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
            Storyboard.SetTarget(animation, image);
            Storyboard.SetTargetProperty(animation, new PropertyPath(image.Visibility));

            TimeSpan currentInterval = TimeSpan.FromMilliseconds(0);
            ObjectKeyFrame keyFrameVisible = new DiscreteObjectKeyFrame();
            keyFrameVisible.Value = Visibility.Visible;
            keyFrameVisible.KeyTime = currentInterval;

            animation.KeyFrames.Add(keyFrameVisible);
            currentInterval = currentInterval.Add(interval);

            ObjectKeyFrame keyFrameHidden = new DiscreteObjectKeyFrame();
            keyFrameHidden.Value = Visibility.Hidden;
            keyFrameHidden.KeyTime = currentInterval;

            animation.KeyFrames.Add(keyFrameHidden);
            currentInterval = currentInterval.Add(interval);
        }

        public void CreateInvaderShotStoryBoard()
        {
            invaderShotStoryboard = new Storyboard();
            DoubleAnimation animation = new DoubleAnimation();
            animation.From = 1;
            animation.To = 0;
            Storyboard.SetTarget(animation, image);
            Storyboard.SetTargetProperty(animation, new PropertyPath(image.Opacity));
        }

        public AnimatedImage(IEnumerable<string> imageNames, TimeSpan interval) 
            : this()
        {
            StartAnimation(imageNames, interval);
        }

        public void StartAnimation(IEnumerable<string> imageNames, TimeSpan interval)
        {
            Storyboard storyboard = new Storyboard();
            ObjectAnimationUsingKeyFrames animation = new ObjectAnimationUsingKeyFrames();
            Storyboard.SetTarget(animation, image);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Image.SourceProperty));

            TimeSpan currentInterval = TimeSpan.FromMilliseconds(0);
            foreach (string imageName in imageNames)
            {
                ObjectKeyFrame keyFrame = new DiscreteObjectKeyFrame();
                keyFrame.Value = CreateImageFromAssets(imageName);
                keyFrame.KeyTime = currentInterval;

                animation.KeyFrames.Add(keyFrame);
                currentInterval = currentInterval.Add(interval);
            }

            storyboard.RepeatBehavior = RepeatBehavior.Forever;
            storyboard.AutoReverse = true;
            storyboard.Children.Add(animation);
            storyboard.Begin();
        }

        private static BitmapImage CreateImageFromAssets(string imageFilename)
        {
            try
            {
                Uri uri = new Uri(imageFilename, UriKind.RelativeOrAbsolute);
                return new BitmapImage(uri);
            }
            catch (System.IO.IOException)
            {
                return new BitmapImage();
            }
        }

        public void InvaderShot()
        {
            invaderShotStoryboard.Begin();
        }

        public void StartFlashing()
        {
            flashStoryboard.Begin();
        }

        public void StopFlashing()
        {
            flashStoryboard.Stop();
        }
    }
}
