using System;
using System.Drawing;

namespace TheQuest
{
    class RedPotion : Weapon, IPotion
    {
        #region Properties and Fields

        private const int health = 10;

        public override string Name { get { return "Red Potion"; } }

        private bool used;
        public bool Used { get { return used; } }
        #endregion

        #region Initialization
        public RedPotion(Game game, Point location)
            : base(game, location)
        {
            used = false;
        }
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
