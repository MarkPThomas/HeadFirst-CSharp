using System;
using System.Drawing;

namespace TheQuest
{
    class BattleAxe : Weapon
    {
        #region Properties and Fields

        private const int radius = 10;
        private const int damage = 8;

        public override string Name { get { return "Battle Axe"; } }
        #endregion

        #region Initialization
        public BattleAxe(Game game, Point location)
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
