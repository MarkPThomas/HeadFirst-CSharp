using System;
using System.Drawing;

namespace TheQuest
{
    class Ghoul : Enemy
    {
        #region Properties and Fields

        private const int damage = 4;
        private const int hitPoints = 10;
        #endregion

        #region Initialization
        public Ghoul(Game game, Point location)
            : base(game, location, hitPoints)
        { }
        #endregion

        #region Movement
        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(3) == 0)
            {
                // Ghoul stands still
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
