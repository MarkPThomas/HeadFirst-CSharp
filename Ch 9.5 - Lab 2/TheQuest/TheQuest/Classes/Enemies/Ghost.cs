using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Ghost : Enemy
    {
        private const int damage = 3;
        private const int hitPoints = 8;

        public Ghost(Game game, Point location)
            : base(game, location, hitPoints)
        { }

        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(3) == 0)
            {
                Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
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
    }
}
