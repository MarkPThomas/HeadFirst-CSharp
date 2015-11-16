using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    abstract class Mover
    {
        #region Properties and Fields
        /// <summary>
        /// Step size of the character.
        /// </summary>
        private const int MoveInterval = 10;

        protected Game game;

        protected Point location;
        public Point Location { get { return location; } }
        #endregion

        #region Initialization
        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }
        #endregion

        #region Movement
        /// <summary>
        /// Returns true if the location lies within a quadrant with 2*dimensions of the distance specified centered on the location given.
        /// </summary>
        /// <param name="locationToCheck"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public bool Nearby(Point locationToCheck, int distance)
        {
            if (Math.Abs(location.X - locationToCheck.X) < distance &&
                Math.Abs(location.Y - locationToCheck.Y) < distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns a point location that is one step in the direction specified. 
        /// If it hits a boundary, the point returned is at the same location as the original.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="boundaries"></param>
        /// <returns></returns>
        public Point Move(Direction direction, Rectangle boundaries)
        {
            Point newLocation = location;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                    {
                        newLocation.Y -= MoveInterval;
                    }
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Bottom)
                    {
                        newLocation.Y += MoveInterval;
                    }
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                    {
                        newLocation.X -= MoveInterval;
                    }
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Right)
                    {
                        newLocation.X += MoveInterval;
                    }
                    break;
                default:
                    break;
            }
            return newLocation;
        }

        public Direction Orient(Point locationOrient)
        {
            double degrees = Angle(location, locationOrient, 
                                    inDegrees: true, 
                                    isAlwaysPositive: true,
                                    pointsInScreenCoords: true);

            // Direction decided within 45-degree quadrants centered on left, right, up, down.
            if ((0 <= degrees && degrees <= 45) ||
                (315 <= degrees && degrees <= 360))
            {
                return Direction.Right;
            }
            else if (45 < degrees && degrees <135)
            {
                return Direction.Up;
            }
            else if (135 <= degrees && degrees <= 225)
            {
                return Direction.Left;
            }
            else if (225 < degrees && degrees < 315)
            {
                return Direction.Down;
            }
            else
            {
                return Direction.None;
            }
        }

        /// <summary>
        /// Returns the angle of the line connecting two points.
        /// </summary>
        /// <param name="firstPoint"></param>
        /// <param name="secondPoint"></param>
        /// <param name="inDegrees">Units will be in degrees. 
        /// Default is radians.</param>
        /// <param name="isAlwaysPositive">Values will be on a scale of 2*Pi (360 degrees). 
        /// Default is +/- values on a scale of Pi (180 degrees).</param>
        /// <param name="pointsInScreenCoords">Points assumed to have the y-axis origin start from the top and increase in value heading down. 
        /// Default uses standard convention of the y-axes origin starting from the bottom and increasing in value heading up.</param>
        /// <returns></returns>
        private double Angle(Point firstPoint, Point secondPoint, bool inDegrees = false, bool isAlwaysPositive = false, bool pointsInScreenCoords = false)
        {           
            // Determine signs of slope components
            int signDeltaX = Math.Sign((double)(secondPoint.X - firstPoint.X));
            int signDeltaY;
            if (pointsInScreenCoords)       // Reverse the sign of delta-y.
            {
                signDeltaY = Math.Sign((double)(firstPoint.Y - secondPoint.Y));
            }
            else
            {
                signDeltaY = Math.Sign((double)(secondPoint.Y - firstPoint.Y));
            }

            double angleRadians = Math.Atan(((double)(firstPoint.Y - secondPoint.Y) / (secondPoint.X - firstPoint.X)));

            // Correct for signs
            if (isAlwaysPositive)
            {
                if ((signDeltaX > 0) && (signDeltaY > 0))   // First quadrant.
                {
                    // No action needed.
                }
                else if((signDeltaX < 0) && (signDeltaY > 0) ||
                        ((signDeltaX < 0) && (signDeltaY < 0)))   // Second quadrant or Third quadrant.
                {
                    angleRadians = Math.PI + angleRadians;
                }
                else if ((signDeltaX > 0) && (signDeltaY < 0))  // Fourth quadrant.
                {
                    angleRadians = 2 * Math.PI + angleRadians;
                }
            }

            double angle = angleRadians;
            if (inDegrees)
            {
                angle *= 180 / Math.PI;
            }    

            return angle;
        }
        #endregion
    }
}
