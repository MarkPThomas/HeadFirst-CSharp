using System;
using System.Drawing;

namespace TheQuest
{
    abstract class Enemy : Mover
    {
        #region Properties and Fields

        /// <summary>
        /// Distance within which an enemy can attack a player.
        /// </summary>
        private const int NearPlayerDistance = 25;

        public int HitPoints { get; private set; }
        public bool Dead
        {
            get
            {
                if (HitPoints <= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                };
            }
        }

        #endregion

        #region Initialization
        public Enemy(Game game, Point location, int hitPoints)
       : base(game, location)
        {
            HitPoints = hitPoints;
        }
        #endregion

        #region Movement
        public abstract void Move(Random random);


        protected bool NearPlayer()
        {
            return (Nearby(game.PlayerLocation, NearPlayerDistance));
        }

        protected Direction FindPlayerDirection(Point playerLocation)
        {
            Direction directionToMove;
            if (playerLocation.X > location.X + 10)
            {
                directionToMove = Direction.Right;
            }
            else if (playerLocation.X < location.X - 10)
            {
                directionToMove = Direction.Left;
            }
            else if (playerLocation.Y < location.Y - 10)
            {
                directionToMove = Direction.Up;
            }
            else
            {
                directionToMove = Direction.Down;
            }

            return directionToMove;
        }
        #endregion

        #region Action
        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }
        #endregion
    }
}
