using System;
using System.Drawing;

namespace TheQuest
{
    abstract class Weapon: Mover
    {
        #region Properties and Fields

        public bool PickedUp { get; private set; }

        public abstract string Name { get; }
        #endregion

        #region Initialization
        public Weapon(Game game, Point location)
            : base(game, location)
        {
            PickedUp = false;
        }
        #endregion

        #region Movement

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            location = target;
            target = Move(direction, boundaries);
            return target;
        }

        public abstract void Attack(Direction direction, Random random);

        public bool Nearby(Point locationToCheck, Point target, int distance)
        {
            // New distance is distance + difference in target to player location
            int totalDistance = distance;
            if (location.X == target.X)
            {
                totalDistance += Math.Abs(location.Y - target.Y);
            }
            else
            {
                totalDistance += Math.Abs(location.X - target.X);
            }

            if (Nearby(locationToCheck, totalDistance))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region Action
        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        protected bool DamageEnemy(Direction direction, int radius,
                                int damage, Random random)
        {
            Point target = game.PlayerLocation;
            // Distance checked to 1/2 radius as it is checked from both the enemy & player
            for (int distance = 0; distance < radius / 2; distance++)
            {
                // Strike at enemy if one is in range
                foreach (Enemy enemy in game.Enemies)
                {
                    if (!enemy.Dead && Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }

                // Move weapon in that direction if no enemy is in range
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }
        #endregion
    }
}
