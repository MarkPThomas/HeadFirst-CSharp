using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Invaders.Model
{
    class Invader : Ship
    {
        public static Size InvaderSize = new Size(15, 15);
        public InvaderType InvaderType;
        public int Score;

        public static double invaderPixelsPerMove = 1.4 * InvaderSize.Width;

        public Invader(Point location)
            : base(location, InvaderSize)
        { }

        public Invader(Point location, InvaderType invaderType, int score)
            : base(location, InvaderSize)
        {
            InvaderType = invaderType;
            Score = score;
        }


        public override void Move(Direction direction, Size playAreaSize)
        {
            switch (direction)  
            {
                case Direction.Left:
                    if (Location.X - invaderPixelsPerMove >= 0) Location = new Point(Location.X - invaderPixelsPerMove, Location.Y);
                    break;
                case Direction.Right:
                    if (Location.X + Size.Width + invaderPixelsPerMove <= playAreaSize.Width) Location = new Point(Location.X + invaderPixelsPerMove, Location.Y);
                    break;
                case Direction.Up:
                    break;
                case Direction.Down:
                    if (Location.Y + Size.Height + invaderPixelsPerMove <= playAreaSize.Height) Location = new Point(Location.X, Location.Y + invaderPixelsPerMove);
                    break;
                default:
                    break;
            }
        }


    }
}
