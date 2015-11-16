using System;
using System.Drawing;

namespace TheQuest
{
    class Quiver : Weapon
    {
        #region Properties and Fields

        private const int radius = 30;
        private const int damage = 1;

        public override string Name { get { return "Quiver"; } }
        #endregion

        #region Initialization
        public Quiver(Game game, Point location)
            : base(game, location)
        { }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            // Shoot in all directions
            DamageEnemy(Direction.Up, radius, damage, random);
            DamageEnemy(Direction.Left, radius, damage, random);
            DamageEnemy(Direction.Down, radius, damage, random);
            DamageEnemy(Direction.Right, radius, damage, random);
        }
        #endregion
    }
}
