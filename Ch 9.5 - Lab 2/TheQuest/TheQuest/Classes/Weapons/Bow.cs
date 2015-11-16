using System;
using System.Drawing;

namespace TheQuest
{
    class Bow : Weapon
    {
        #region Properties and Fields

        private const int radius = 30;
        private const int damage = 1;

        public override string Name { get { return "Bow"; } }
        #endregion

        #region Initialization
        public Bow(Game game, Point location)
            : base(game, location)
        { }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            if (DamageEnemy(direction, radius, damage, random)) { return; }
        }
        #endregion
    }
}
