using System;
using System.Drawing;

namespace TheQuest
{
    class Bomb : Weapon, IExplosive
    {
        #region Properties and Fields

        private const int radius = 30;
        private const int damage = 10;

        public override string Name { get { return "Bomb"; } }

        private bool exploded;
        public bool Exploded { get { return exploded; } }
        #endregion

        #region Initialization
        public Bomb(Game game, Point location)
            : base(game, location)
        {
            exploded = false;
        }
        #endregion

        #region Movement
        public override void Attack(Direction direction, Random random)
        {
            // Blows up in all directions
            DamageEnemy(Direction.Up, radius, damage, random);
            DamageEnemy(Direction.Left, radius, damage, random);
            DamageEnemy(Direction.Down, radius, damage, random);
            DamageEnemy(Direction.Right, radius, damage, random);

            // Player is also hurt
            game.HitPlayer(5, random);
            exploded = true;
        }
        #endregion
    }
}
