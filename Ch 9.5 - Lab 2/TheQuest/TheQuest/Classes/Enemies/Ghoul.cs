using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Ghoul : Enemy
    {
        private const int damage = 4;
        private const int hitPoints = 10;

        public Ghoul(Game game, Point location)
            : base(game, location, hitPoints)
        { }

        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(3) == 0)
            {
                // Ghoul stands still
            }
            else
            {
                Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }

            if (NearPlayer())
            {
                game.HitPlayer(damage, random);
            }
        }
    }
}
