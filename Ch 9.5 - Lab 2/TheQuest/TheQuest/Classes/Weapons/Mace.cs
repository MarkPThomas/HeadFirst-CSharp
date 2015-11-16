using System;
using System.Drawing;

namespace TheQuest
{
    class Mace : Weapon
    {
        #region Properties and Fields

        private const int radius = 20;
        private const int damage = 6;

        public override string Name { get { return "Mace"; } }
        #endregion

        #region Initialization
        public Mace(Game game, Point location)
            : base(game, location)
        { }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            // Swing in all directions
            DamageEnemy(Direction.Up, radius, damage, random);
            DamageEnemy(Direction.Left, radius, damage, random);
            DamageEnemy(Direction.Down, radius, damage, random);
            DamageEnemy(Direction.Right, radius, damage, random);
        }
        #endregion
    }
}
