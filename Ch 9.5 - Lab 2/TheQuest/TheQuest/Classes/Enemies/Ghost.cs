using System;
using System.Drawing;

namespace TheQuest
{
    class Ghost : Enemy
    {
        #region Properties and Fields

        private const int damage = 3;
        private const int hitPoints = 8;
        #endregion

        #region Initialization
        public Ghost(Game game, Point location)
            : base(game, location, hitPoints)
        { }
        #endregion

        #region Movement
        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(3) == 0)
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            else
            {
                // Ghost stands still
            }

            if (NearPlayer())
            {
                game.HitPlayer(damage, random);
            }
        }
        #endregion
    }
}
