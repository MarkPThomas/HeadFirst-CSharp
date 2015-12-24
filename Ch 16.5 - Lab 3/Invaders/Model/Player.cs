using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Invaders.Model
{
    class Player : Ship
    {
        /// <summary>
        /// In pixels.
        /// </summary>
        public static Size PlayerSize = new Size(25,15);
        private const double PlayerPixelsPerMove = 10; 

        public Player(Point location)
            : base(location, PlayerSize)
        {

        }

        public override void Move(Direction direction, Size playAreaSize)
        {
            // Player can only move left & right.
            switch (direction)
            {
                case Direction.Left:
                    if (Location.X - PlayerPixelsPerMove >= 0) Location = new Point(Location.X - PlayerPixelsPerMove, Location.Y);
                    break;
                case Direction.Right:
                    if (Location.X + Size.Width + PlayerPixelsPerMove <= playAreaSize.Width) Location = new Point(Location.X + PlayerPixelsPerMove, Location.Y);
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
