using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;

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
                    rectangleStar.Width = 5;
                    rectangleStar.Height = 5;
                    rectangleStar.Fill = ColorFactory(scale);

                    return rectangleStar;
                case 1:
                    Ellipse ellipseStar = new Ellipse();
                    ellipseStar.Width = 5;
                    ellipseStar.Height = 5;
                    ellipseStar.Fill = ColorFactory(scale);

                    return ellipseStar;
                case 2:
                    BigStar bigStar = new BigStar();
                    bigStar.Width = 10;
                    bigStar.Height = 10;
                    bigStar.SetFill(ColorFactory(scale));

                    return bigStar.polygon;
                default:
                    return new Rectangle();
            }
        }

        static private SolidColorBrush ColorFactory(double scale)
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
            scanLine.Height = 2;
            scanLine.Width = width * scale;
            scanLine.Opacity = 1;

            scanLine.RenderTransform  = yPosition;

            return scanLine;
        }
    }
}
