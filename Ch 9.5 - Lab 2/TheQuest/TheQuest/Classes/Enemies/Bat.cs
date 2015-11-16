using System;
using System.Drawing;

namespace TheQuest
{
    class Bat : Enemy
    {
        #region Properties and Fields

        private const int damage = 2;
        private const int hitPoints = 6;
        #endregion

        #region Initialization
        public Bat(Game game, Point location)
            : base(game, location, hitPoints)
        { }
        #endregion

        #region Movement
        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(2) == 0)
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            else
            {
                location = Move((Direction)random.Next(1, 4), game.Boundaries);
            }

            if (NearPlayer())
            {
                game.HitPlayer(damage, random);
            }
        }
        #endregion
    }
}
