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
        InvaderType InvaderType;
        int Score;

        public Invader(Point location)
            : base(location, InvaderSize)
        { }

        public Invader(Point location, InvaderType invaderType, int score)
            : base(location, InvaderSize)
        {
            InvaderType = invaderType;
            Score = score;
        }


        public override void Move(Direction direction)
        {
            switch (direction)  
            {
                case Direction.Left:
                    break;
                case Direction.Right:
                    break;
                case Direction.Up:
                    break;
                case Direction.Down:
                    break;
                default:
                    break;
            }
        }


    }
}
