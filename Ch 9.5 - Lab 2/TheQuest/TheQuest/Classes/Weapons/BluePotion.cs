using System;
using System.Drawing;

namespace TheQuest
{
    class BluePotion: Weapon, IPotion
    {
        #region Properties and Fields

        private const int health = 5;
        public override string Name { get { return "Blue Potion"; } }

        private bool used;
        public bool Used { get { return used; } }
        #endregion

        #region Initialization
        public BluePotion(Game game, Point location)
            : base(game, location)
        { }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            game.IncreasePlayerHealth(health, random);
            used = true;
        }
        #endregion
    }
}
