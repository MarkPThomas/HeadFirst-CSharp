using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TheQuest
{
    class Wizard : Enemy
    {
        private const int damage = 8;
        private const int hitPoints = 15;

        public Wizard(Game game, Point location)
            : base(game, location, hitPoints)
        { }

        public override void Move(Random random)
        {
            if (Dead) { return; }

            if (random.Next(4) == 0)
            {
                // Wizard stands still
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
