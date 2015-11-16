using System;
using System.Drawing;

namespace TheQuest
{
    class Wizard : Enemy
    {
        #region Properties and Fields

        private const int damage = 8;
        private const int hitPoints = 15;
        #endregion

        #region Initialization
        public Wizard(Game game, Point location)
            : base(game, location, hitPoints)
        { }
        #endregion

        #region Movement
        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(4) == 0)
            {
                // Wizard stands still
            }
            else
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }

            if (NearPlayer())
            {
                game.HitPlayer(damage, random);
            }
        }
        #endregion
    }
}
