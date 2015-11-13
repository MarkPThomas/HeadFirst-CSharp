using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    abstract class Weapon: Mover
    {
        public bool PickedUp { get; private set; }

        public abstract string Name { get; }

        public Weapon(Game game, Point location)
            : base(game, location)
        {
            PickedUp = false;
        }

        public void PickUpWeapon()
        {
            PickedUp = true;
        }

        public abstract void Attack(Direction direction, Random random);
        
        protected bool DamageEnemy(Direction direction, int radius, 
                                int damage, Random random)
        {
            Point target = game.PlayerLocation;
            // Distance checked to 1/2 radius as it is checked from both the enemy & player
            for (int distance = 0; distance < radius/2; distance++)
            {
                // Strike at enemy if one is in range
                foreach (Enemy enemy in game.Enemies)
                {
                    if (Nearby(enemy.Location, target, distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
                }

                // Move in that direction if no enemy is in range?
                target = Move(direction, target, game.Boundaries);
            }
            return false;
        }

        public bool Nearby(Point locationToCheck, Point target, int distance)
        {
            if (Nearby(locationToCheck, distance) &&
                Nearby(target, distance))
            {
                return true;
            }
            return false;
        }

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            // TODO: Something is wrong here
            target = Move(direction, boundaries);
            return target;
        }
    }
}
