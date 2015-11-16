using System;
using System.Drawing;

namespace TheQuest
{
    class Shield : Weapon, IDefense
    {
        #region Properties and Fields

        private const int radius = 5;
        private const int damage = 1;

        public override string Name { get { return "Shield"; } }

        private const int defense = 1;
        public int Defense { get { return defense; } }
        #endregion

        #region Initialization
        public Shield(Game game, Point location)
            : base(game, location)
        { }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            // Shield provides passive defense
            DamageEnemy(direction, radius, damage, random);
        }
        #endregion
    }
}
