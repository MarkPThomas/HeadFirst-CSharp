using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Sword : Weapon
    {
        private const int radius = 10;
        private const int damage = 3;

        public override string Name { get { return "Sword"; } }

        public Sword(Game game, Point location)
            : base(game, location)
        { }

        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, radius, damage, random)) { return; }

            // Try CW   
            if (DamageEnemy(CWDirection(direction), radius, damage, random)) { return; }

            // Try CCW
            if (DamageEnemy(CCWDirection(direction), radius, damage, random)) { return; }
        }

        private Direction CCWDirection(Direction direction)
        {
            Direction ccwDirection;
            if (direction -- >= 0)
            {
                ccwDirection = direction --;
            }
            else
            {
                ccwDirection = (Direction)3;
            }
            return ccwDirection;
        }

        private Direction CWDirection(Direction direction)
        {
            Direction cwDirection;
            if ((direction ++) <= (Direction)3)
            {
                cwDirection = direction ++;
            }
            else
            {
                cwDirection = 0;
            }
            return cwDirection;
        }
    }
}
