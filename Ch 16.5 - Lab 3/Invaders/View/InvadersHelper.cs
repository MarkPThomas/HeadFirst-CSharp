using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace Invaders.View
{
    class InvadersHelper
    {
        static public Shape StarControlFactory(double scale)
        {
            Random _random = new Random();
            int selection = _random.Next(3);

            switch (selection)
            {
                case 0:
                    Rectangle rectangleStar = new Rectangle();
                    rectangleStar.Width = 5 * scale;
                    rectangleStar.Height = 5 * scale;
                    rectangleStar.Fill = ColorFactory();

                    return rectangleStar;
                case 1:
                    Ellipse ellipseStar = new Ellipse();
                    ellipseStar.Width = 5 * scale;
                    ellipseStar.Height = 5 * scale;
                    ellipseStar.Fill = ColorFactory();

                    return ellipseStar;
                case 2:
                    BigStar bigStar = new BigStar();
                    bigStar.Width = 10 * scale;
                    bigStar.Height = 10 * scale;
                    bigStar.SetFill(ColorFactory());

                    return bigStar.polygon;
                default:
                    return new Rectangle();
            }
        }

        static private SolidColorBrush ColorFactory()
        {
            Random _random = new Random();
            int selection = _random.Next(4);

            switch (selection)
            {
                case 0:
                    return new SolidColorBrush(Colors.White);
                case 1:
                    return new SolidColorBrush(Colors.Yellow);
                case 2:
                    return new SolidColorBrush(Colors.LightBlue);
                case 3:
                    return new SolidColorBrush(Colors.GreenYellow);
                default:
                    return new SolidColorBrush(Colors.White);
            }
        }

        static public Rectangle ScanLineFactory(int yPosition, int width, double scale)
        {
            Rectangle scanLine = new Rectangle();
            scanLine.Fill = new SolidColorBrush(Colors.White);
            scanLine.Height = 2 * scale;
            scanLine.Width = width * scale;
            scanLine.Opacity = 1;

            TranslateTransform myTranslate = new TranslateTransform();
            myTranslate.X = 0;
            myTranslate.Y = yPosition;
            scanLine.RenderTransform = myTranslate;

            return scanLine;
        }

        public static Shape ShotFactory(double width, double height, double scale, TimeSpan moveInterval)
        {
            Rectangle shot = new Rectangle();
            shot.Fill = new SolidColorBrush(Colors.White);
            shot.Height = height * scale;
            shot.Width = width * scale;

            return shot;
        }

        public static AnimatedImage InvaderFactory(int invaderType, double width, double height, double scale, TimeSpan moveInterval)
        {
            List<string> imageNames = new List<string>();
            string fileName = "";
            switch (invaderType)
            {
                case 0:
                    fileName = "star";
                    break;
                case 1:
                    fileName = "satellite";
                    break;
                case 2:
                    fileName = "flyingsaucer";
                    break;
                case 3:
                    fileName = "bug";
                    break;
                case 4:
                    fileName = "spaceship";
                    break;
                default:
                    fileName = "star";
                    break;
            }

            imageNames.Add(fileName + "1.png");
            imageNames.Add(fileName + "2.png");
            imageNames.Add(fileName + "3.png");
            imageNames.Add(fileName + "4.png");

            AnimatedImage invader = new AnimatedImage(imageNames, moveInterval);
            invader.Width = width * scale;
            invader.Height = height * scale;
            return invader;
        }

        public static AnimatedImage PlayerFactory(double width, double height, double scale, TimeSpan moveInterval)
        {
            List<string> imageNames = new List<string>();
            imageNames.Add("player.png");

            AnimatedImage player = new AnimatedImage(imageNames, moveInterval);
            player.Width = width * scale;
            player.Height = height * scale;
            return player;
        }

        public static void SetCanvasLocation(UIElement control, double x, double y, double scale)
        {
            Canvas.SetLeft(control, x * scale);
            Canvas.SetTop(control, y * scale);
        }

        public static void MoveElementOnCanvas(UIElement uiElement, double toX, double toY, double scale)
        {
            double fromX = Canvas.GetLeft(uiElement);
            double fromY = Canvas.GetTop(uiElement);

            Storyboard storyboard = new Storyboard();
            DoubleAnimation animationX = CreateDoubleAnimation(uiElement, fromX, toX, scale, new PropertyPath(Canvas.LeftProperty));
            DoubleAnimation animationY = CreateDoubleAnimation(uiElement, fromY, toY, scale, new PropertyPath(Canvas.TopProperty));

            storyboard.Children.Add(animationX);
            storyboard.Children.Add(animationY);
            storyboard.Begin();
        }

        public static DoubleAnimation CreateDoubleAnimation(UIElement uiElement, double from, double to, double scale, PropertyPath propertyToAnimate)
        {
            DoubleAnimation animation = new DoubleAnimation();

            Storyboard.SetTarget(animation, uiElement);
            Storyboard.SetTargetProperty(animation, propertyToAnimate);

            // Note that the animation applies to the Canvas.Left property
            animation.From = from * scale;
            animation.To = to * scale;
            animation.Duration = TimeSpan.FromSeconds(3);

            return animation;
        }

        internal static void ResizeElement(AnimatedImage uiElement, double width, double height, double scale)
        {
            uiElement.Width = width * scale;
            uiElement.Height = height * scale;
        }
    }
}
