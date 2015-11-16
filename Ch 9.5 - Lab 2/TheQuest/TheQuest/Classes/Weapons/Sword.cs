using System;
using System.Drawing;

namespace TheQuest
{
    class Sword : Weapon
    {
        #region Properties and Fields

        private const int radius = 10;
        private const int damage = 3;

        public override string Name { get { return "Sword"; } }
        #endregion

        #region Initialization
        public Sword(Game game, Point location)
            : base(game, location)
        { }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, radius, damage, random)) { return; }

            // Try CW   
            if (DamageEnemy(CWDirection(direction), radius, damage, random)) { return; }

            // Try CCW
            if (DamageEnemy(CCWDirection(direction), radius, damage, random)) { return; }
        }

        private Direction CWDirection(Direction direction)
        {
            Direction cwDirection;
            if ((direction - 1) > 0)
            {
                cwDirection = direction - 1;
            }
            else
            {
                cwDirection = (Direction)4;
            }
            return cwDirection;
        }

        private Direction CCWDirection(Direction direction)
        {
            Direction ccwDirection;
            if ((direction + 1) <= (Direction)4)
            {
                ccwDirection = direction + 1;
            }
            else
            {
                ccwDirection = (Direction)1;
            }
            return ccwDirection;
        }
        #endregion
    }
}
